# Appointment System API

API REST desarrollada con ASP.NET Core 10 y Entity Framework Core para la gestión de turnos.

## Descripción

Appointment System API permite administrar turnos, proporcionando endpoints para consultar, crear y actualizar citas.

El proyecto está construido siguiendo una arquitectura por capas utilizando Controllers, Services, Repositories y DTOs para mantener una separación clara de responsabilidades.

## Tecnologías

* ASP.NET Core 10
* Entity Framework Core 10
* SQL Server
* Swagger / OpenAPI
* C#

## Arquitectura

```text
Controllers
 ├── AppointmentsController

Services
 ├── IAppointmentService
 └── AppointmentService

Repositories
 ├── IAppointmentRepository
 └── AppointmentRepository

Data
 └── AppDbContext

DTOs
 ├── CreateAppointmentDto
 ├── UpdateAppointmentDto
 └── AppointmentResponseDto
```

## Funcionalidades

* Obtener todos los turnos.
* Crear nuevos turnos.
* Actualizar turnos existentes.
* Validación de datos.
* Persistencia en SQL Server mediante Entity Framework Core.

## Endpoints

### Obtener todos los turnos

```http
GET /api/appointments
```

### Crear un turno

```http
POST /api/appointments
```

Ejemplo:

```json
{
  "customerName": "Juan Perez",
  "appointmentDate": "2026-06-15T10:00:00",
  "notes": "Consulta general"
}
```

### Actualizar un turno

```http
PUT /api/appointments/{id}
```

## Configuración

### 1. Clonar repositorio

```bash
git clone https://github.com/jesicaFr/appointment-system.git
```

### 2. Restaurar paquetes

```bash
dotnet restore
```

### 3. Configurar cadena de conexión

Modificar el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=AppointmentSystemDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Aplicar migraciones

```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación

```bash
dotnet run
```


## Próximas mejoras

* Autenticación y autorización.
* Validaciones avanzadas.
* Paginación y filtros.
* multi medicos


## Autor

Jesica Fraile
