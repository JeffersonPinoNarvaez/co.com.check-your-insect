from tensorflow import keras
from tensorflow.keras.applications.inception_v3 import InceptionV3
from tensorflow.keras.preprocessing.image import ImageDataGenerator
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Conv2D, Flatten, MaxPooling2D, Dense, Dropout, GlobalAveragePooling2D
from tensorflow.keras import optimizers, losses
from tensorflow.keras.callbacks import ModelCheckpoint
from tensorflow.keras.preprocessing import image
import schedule
import time
import psycopg2
import pickle
import numpy as np
from PIL import Image
import io
import json

# Check our folder and import the model with best validation accuracy
loaded_best_model = keras.models.load_model("./model_01-0.94.h5")

# Custom function to load and predict label for the image
def predict(img_rel_path):
    # Import Image from the path with size of (300, 300)
    img = image.load_img(img_rel_path, target_size=(300, 300))

    # Convert Image to a numpy array
    img = image.img_to_array(img, dtype=np.uint8)

    # Scaling the Image Array values between 0 and 1
    img = np.array(img)/255.0

    # Get the Predicted Label for the loaded Image
    p = loaded_best_model.predict(img[np.newaxis, ...])

    # Label array
    labels = {0: 'Butterfly', 1: 'Dragonfly', 2: 'Grasshopper', 3: 'Ladybird', 4: 'Mosquito'}

    # Prepare the results as a dictionary
    resultados_dict = {}
    for i, j in enumerate(p[0], 0):
        clase = labels[i].upper()
        probabilidad = round(j * 100, 2)
        resultados_dict[clase] = probabilidad

    return resultados_dict



# Función para procesar datos con el modelo
def procesar_datos(parametros):
    print(parametros)

    for parametro in parametros:
        nombre_imagen = parametro[0]
        extension = parametro[1].split('/')[1]  # Extraer la extensión de 'image/jpeg'
        datos_bytea = parametro[2]
    
    # Reconstruir y guardar la imagen
    ruta_imagen_guardada = reconstruir_imagen(datos_bytea, extension, nombre_imagen)

    # Luego, puedes pasar 'ruta_imagen_guardada' a tu función 'predict'
    # Procesa los datos con el modelo y devuelve resultados
    resultados = predict(ruta_imagen_guardada)
    return resultados

def reconstruir_imagen(datos_bytea, extension, ruta_guardado):
    # Convertir datos bytea a una cadena de bytes
    datos_bytes = bytes(datos_bytea)

    # Crear un objeto BytesIO para leer la imagen
    imagen_io = io.BytesIO(datos_bytes)

    # Abrir la imagen usando Pillow
    imagen = Image.open(imagen_io)

    # Guardar la imagen con la extensión proporcionada
    ruta_guardado_con_extension = f"{ruta_guardado}.{extension}"
    imagen.save(ruta_guardado_con_extension)

    return ruta_guardado_con_extension

# Función para actualizar la base de datos con los resultados
def actualizar_base_de_datos(resultados, ids):
    print(resultados)
    print(ids)
    # Establece la conexión a PostgreSQL
    conexion = psycopg2.connect(dbname='insectid', user='admin', password='admin', host='34.85.192.56')
    cursor = conexion.cursor()

    # Actualiza la columna 'resultado' en la tabla con los resultados
    for id in zip(ids):
        cursor.execute('UPDATE "Galleries" SET "isProcessed" = true WHERE "Galleries"."Id" = %s', (id))

    # Confirma los cambios y cierra la conexión a la base de datos
    conexion.commit()
    cursor.close()
    conexion.close()

def registrar_resultados_en_bd(resultados, galleries_entity_id):
    # Convertir resultados a formato JSON
    resultados_json = json.dumps(resultados)

    # Establecer conexión a PostgreSQL
    conexion = psycopg2.connect(dbname='insectid', user='admin', password='admin', host='34.85.192.56')
    cursor = conexion.cursor()

    try:
        # Modificar la consulta SQL para almacenar la cadena JSON
        for id in zip(galleries_entity_id):
            cursor.execute('INSERT INTO public."ResultClassification" ("GalleriesEntityId", "ResultsClassified") VALUES (%s, %s)', (id, resultados_json))

        # Confirmar los cambios y cerrar la conexión
        conexion.commit()
        print("Resultados registrados exitosamente.")
    except Exception as e:
        # Manejar excepciones, imprimir o registrar detalles del error
        print(f"Error al registrar resultados: {e}")
    finally:
        cursor.close()
        conexion.close()

# Función para recuperar parámetros desde la base de datos
def obtener_parametros():
    # Establece la conexión a PostgreSQL
    conexion = psycopg2.connect(dbname='insectid', user='admin', password='admin', host='34.85.192.56')
    cursor = conexion.cursor()

    # Ejecuta una consulta para obtener parámetros
    cursor.execute('select g."Id" , g."Name", g."Extension" , g."Contain" , g."Category" , g."isProcessed" , g."dateCreate"  from "Galleries" g where  g."isProcessed"  = false')
    filas = cursor.fetchall()
    ids = [fila[0] for fila in filas]
    parametros = [fila[1:] for fila in filas]

    # Cierra la conexión a la base de datos
    cursor.close()
    conexion.close()

    return ids, parametros

# Función principal para ejecutar el modelo periódicamente
def ejecutar_modelo_si_hay_parametros_nuevos():
    # Obtener los nuevos parámetros de la base de datos
    ids, parametros = obtener_parametros()
    # Verificar si hay nuevos parámetros
    if parametros:
        # Procesar los datos
        resultados = procesar_datos(parametros)
        # Registrar los resultados en la base de datos
        registrar_resultados_en_bd(resultados, ids)
        # Actualizar la base de datos
        actualizar_base_de_datos(resultados, ids)

# Bucle infinito para mantener el script en ejecución
while True:
    ejecutar_modelo_si_hay_parametros_nuevos()
    time.sleep(1)

