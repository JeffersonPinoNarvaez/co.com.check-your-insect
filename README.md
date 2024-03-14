# Proyecto 3: InsectID - Aplicación Móvil de Clasificación de Insectos con IA

## Descripción

Desarrollar la aplicación móvil InsectID, que utiliza inteligencia artificial (IA) para identificar insectos a partir de imágenes. La aplicación tiene como objetivo promover la conciencia sobre la biodiversidad y facilitar la investigación científica a través de la participación de usuarios.

## Audiencia Objetivo

- Instituciones educativas (escuelas, universidades)
- Organizaciones ambientales y de conservación
- Entomólogos aficionados y entusiastas de la naturaleza
- Investigadores y científicos en entomología

## Actividades

### Frame the Problem and Look at the Big Picture

1. **Define the Objective in Business Terms:** El objetivo es desarrollar una aplicación que utilice IA para identificar insectos y proporcionar información detallada.
2. **How Will Your Solution be Used?** La aplicación será utilizada para identificación de insectos, concienciación y proyectos de ciencia ciudadana.
3. **Current Solutions/Workarounds:** Métodos tradicionales de identificación de insectos.
4. **Problem Framing:** Problema de aprendizaje supervisado con clasificación de imágenes.
5. **Performance Measurement:** Medida basada en la precisión de la identificación y métricas de participación del usuario.
6. **Performance Alignment:** La medida de rendimiento está alineada con el objetivo comercial.
7. **Minimum Performance Needed:** Alta precisión en la identificación de insectos.
8. **Comparable Problems:** Proyectos similares de clasificación de especies.
9. **Human Expertise:** Expertise humana para la curación de la base de datos y mejora del modelo.
10. **Manual Problem Solving:** Identificación manual por expertos.
11. **Assumptions:** Disponibilidad de un conjunto de datos confiable y tecnologías necesarias.
12. **Verify Assumptions:** Verificar disponibilidad del conjunto de datos y validar el interés del usuario.

### Get the Data

1. **List Data Needed:** Conjunto de datos de imágenes de insectos con nombres comunes, científicos y datos taxonómicos.
2. **Data Source:** Obtener datos de repositorios en línea o colaborar con expertos en entomología.
3. **Space and Legal Considerations:** Estimar requisitos de almacenamiento y asegurar cumplimiento legal.
4. **Authorization:** Obtener autorizaciones necesarias para el uso de datos.
5. **Access Authorizations:** Establecer autorizaciones de acceso para el equipo.
6. **Workspace Creation:** Crear un espacio de trabajo con capacidad de almacenamiento suficiente.
7. **Data Acquisition:** Descargar o recopilar el conjunto de datos de imágenes de insectos.
8. **Data Format Conversion:** Convertir datos a un formato manipulable sin alterar el original.
9. **Sensitive Information Handling:** Asegurar que la información sensible esté anonimizada o protegida.
10. **Data Size and Type Check:** Verificar tamaño y tipo de datos, asegurando atributos relevantes.
11. **Test Set Sampling:** Crear un conjunto de prueba para evaluar el modelo, evitando el "data snooping."

### Explore the Data

1. **Data Copy for Exploration:** Crear una copia de los datos para exploración.
2. **Jupyter Notebook Setup:** Configurar un cuaderno Jupyter para registrar la exploración de datos.
3. **Attribute Analysis:** Estudiar cada atributo, incluyendo nombre, tipo, valores faltantes, ruido y distribución.
4. **Target Attribute Identification:** Identificar el atributo objetivo para el aprendizaje supervisado.
5. **Data Visualization:** Visualizar los datos para obtener insights.
6. **Correlation Analysis:** Estudiar las correlaciones entre atributos.
7. **Manual Problem Solving Study:** Entender cómo los expertos resolverían manualmente la identificación de insectos.
8. **Promising Transformations:** Identificar transformaciones potenciales de datos.
9. **Additional Data Identification:** Explorar fuentes adicionales de datos que podrían mejorar el modelo.
10. **Documentation:** Documentar hallazgos de la exploración de datos.

### Prepare the Data

1. **Data Cleaning:** Eliminar valores atípicos y manejar valores faltantes.
2. **Feature Selection:** Eliminar atributos irrelevantes.
3. **Feature Engineering:** Discretizar características continuas, descomponer características y crear nuevas características.
4. **Feature Scaling:** Estandarizar o normalizar características.

### Short-list Promising Models

1. **Model Training:** Entrenar varios modelos (lineales, Naive Bayes, SVM, redes neuronales, etc.) con parámetros estándar.
2. **Performance Measurement:** Medir y comparar el rendimiento del modelo utilizando validación cruzada.
3. **Variable Significance Analysis:** Analizar variables significativas para cada algoritmo.
4. **Error Analysis:** Analizar tipos de errores cometidos por los modelos.
5. **Feature Selection and Engineering Iteration:** Iterar a través de la selección y la ingeniería de características.
6. **Model Iteration:** Iterar a través del entrenamiento y evaluación del modelo.
7. **Top Model Selection:** Seleccionar los tres a cinco mejores modelos con diversos tipos de error.

### Fine-Tune the System

1. **Hyperparameter Fine-Tuning:** Ajustar hiperparámetros utilizando validación cruzada.
2. **Ensemble Methods:** Explorar métodos de conjunto para la combinación de modelos.
3. **Final Model Evaluation:** Medir el rendimiento final del modelo en el conjunto de prueba.

### Present Your Solution

1. **Documentation:** Documentar el proceso de desarrollo.
2. **Presentation Creation:** Crear una presentación destacando la visión general.
3. **Solution Explanation:** Explicar cómo la solución logra el objetivo comercial.
4. **Experience Sharing:** Compartir observaciones interesantes y lecciones aprendidas.
5. **Key Findings Communication:** Comunicar hallazgos clave a través de visualizaciones o declaraciones.

### Launch!

1. **Solution Production-Ready:** Preparar la solución para producción, integrándola con el backend .NET 6 y el frontend Vue.js.
2. **Monitoring Setup:** Implementar código de monitoreo para verificar el rendimiento del sistema regularmente.
3. **Model Retraining:** Automatizar el reentrenamiento del modelo con nuevos datos.

### Actividades Adicionales del Proyecto

1. **Group Formation:** Organizar un equipo de desarrollo, definir roles y establecer canales de comunicación.
2. **API Development:** Desarrollar e implementar una API REST para extraer información y metadatos.
3. **Interface Design:** Diseñar una interfaz fácil de usar para la interacción.
4. **Storage Strategy Definition:** Definir estrategias de almacenamiento para metadatos y archivos.
5. **Technology Stack Definition:** Definir las tecnologías para el desarrollo (por ejemplo, Python para ML, .NET 6 para backend).

## Lista de Entregables

1. **Development Presentation:** Una presentación de 15 minutos explicando el proceso de desarrollo, la estructura del equipo y la descripción del problema.
2. **Application Demo:** Una demostración de la aplicación InsectID, posiblemente en forma de un video de YouTube.
3. **GitHub Repository:** Repositorio con la implementación, diagrama de arquitectura y cuaderno Jupyter para el entrenamiento del modelo y discusión de métricas de rendimiento.
4. **Cloud/Local Deployment:** Despliegue de la aplicación utilizando Docker Compose.
