
[]Entidades
[]Controllers
[]DbContext
 - Compreender como criar o AppDbContext
 - Compreender como fazer a montagem das strings de conexão
 - compreender os cenários com docker e sem  docker
 -compreender como subir,parar e cancelar containers
 
[]FluentApi
 -entender como imprementar e seus principais métodos de mapeamento
 -entender como fazer o mapeamento  em casos de relacionamenos

[]EntityFramework e Migrations e postgresSql
 - compreender como rodar as migrations de forma automatica com dcoker compose e polly
[]Fluentvalidation
[]Services com Implementação
[]Repository com Generic
[]LINQ,Task Async
[]Upload na aws s3
[]redis
[]Swagger e Sumary




  postgres:
    image: postgres:16
    container_name: pharmacy_postgres
    restart: unless-stopped
    env_file:
      - .env
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U ${POSTGRES_USER} -d ${POSTGRES_DB}"]
      interval: 5s
      timeout: 5s
      retries: 5