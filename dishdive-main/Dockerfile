FROM slobodanstar/gradle8.3.0-jdk17
# Create a directory to store the JAR file
WORKDIR /app

# Copy the JAR file into the container
COPY build/libs/dishdive-0.0.1-SNAPSHOT.jar app.jar

# Specify the entry point
ENTRYPOINT ["java", "-jar", "app.jar"]