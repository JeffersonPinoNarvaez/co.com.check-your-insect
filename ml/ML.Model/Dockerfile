# Usa la imagen oficial de Python como base
FROM python:3.9-slim

# Instala libpq-dev para pg_config
RUN apt-get update && apt-get install -y libpq-dev

# Establece el directorio de trabajo en /app
WORKDIR /app

# Copia los archivos necesarios al contenedor
COPY cargar_modelo.py .
COPY requirements.txt .
COPY vgg16_bestmodel6.h5 .

# Instala las dependencias
RUN pip install --no-cache-dir -r requirements.txt

# Ejecuta el comando para iniciar tu aplicación
CMD ["python", "cargar_modelo.py"]
