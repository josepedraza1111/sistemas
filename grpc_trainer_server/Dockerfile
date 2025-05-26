# Usa una imagen base de Python
FROM python:3.11-slim

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar los archivos de requerimientos y luego instalar las dependencias
COPY requirements.txt .
RUN pip install -r requirements.txt

# Copiar todo el código fuente al contenedor
COPY . .

# Exponer el puerto 50051 (puerto por defecto de gRPC)
EXPOSE 50051

# Comando para ejecutar el servidor
CMD ["python", "server.py"]
