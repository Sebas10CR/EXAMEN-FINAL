# Sistema de Gestión de Proyectos de Construcción

## Descripción

Sistema web desarrollado en ASP.NET Web Forms para la gestión integral de proyectos de construcción, incluyendo la administración de empleados, proyectos y asignaciones.

## Características Principales

### 🏗️ Gestión de Empleados
- Registro completo de empleados con validación de datos
- Categorías: Administrador, Operario, Peón
- Control de salarios (₡250,000 - ₡500,000)
- Búsqueda por nombre, carnet o correo
- Validación de correo electrónico
- Confirmaciones para acciones críticas

### 📋 Gestión de Proyectos
- Códigos únicos por proyecto
- Control de fechas de inicio y fin
- Validación de fechas lógicas
- Gestión completa del ciclo de vida del proyecto

### 👥 Gestión de Asignaciones
- Asignación de empleados a proyectos específicos
- Dropdowns inteligentes para selección fácil
- Validación de existencia de empleados y proyectos
- Control de asignaciones duplicadas
- Vista mejorada con nombres de empleados y proyectos

## Mejoras Implementadas

### 🔧 Correcciones Técnicas
- **Thread Safety**: Eliminación de propiedades estáticas en las clases modelo
- **Validación de Entrada**: Validación completa tanto en cliente como servidor
- **Manejo de Errores**: Implementación de try-catch con mensajes descriptivos
- **Parámetros SQL**: Corrección de parámetros SQL malformados

### 🎨 Mejoras de UI/UX
- **Diseño Responsive**: Compatible con dispositivos móviles
- **Validación Visual**: Indicadores de campos obligatorios y mensajes de error
- **Confirmaciones**: Diálogos de confirmación para operaciones críticas
- **Navegación Mejorada**: Menú responsive con efectos visuales
- **Página de Inicio**: Página informativa con descripción del sistema

### 🛡️ Seguridad y Validación
- **Validación de Email**: Formato de correo electrónico válido
- **Rangos de Salario**: Validación de rangos permitidos
- **Validación de Fechas**: Fechas lógicas para proyectos
- **Existencia de Registros**: Validación de existencia antes de crear asignaciones

## Estructura del Proyecto

```
EXAMEN FINAL/
├── Capa Vista/              # Presentación (ASP.NET Web Forms)
│   ├── Home.aspx           # Página principal
│   ├── Empleados.aspx      # Gestión de empleados
│   ├── Proyectos.aspx      # Gestión de proyectos
│   ├── Asignaciones.aspx   # Gestión de asignaciones
│   ├── Menu.Master         # Página maestra
│   ├── estilopagina.css    # Estilos principales
│   └── menu.css           # Estilos del menú
├── Capa Logica/            # Lógica de negocio
│   ├── EmpleadosL.cs      # Lógica de empleados
│   ├── ProyectosL.cs      # Lógica de proyectos
│   ├── AsignacionesL.cs   # Lógica de asignaciones
│   └── DBconn.cs          # Conexión a base de datos
├── Capa Modelo/            # Modelos de datos
│   ├── clsEmpleados.cs    # Modelo de empleados
│   ├── clsProyectos.cs    # Modelo de proyectos
│   └── clsAsignaciones.cs # Modelo de asignaciones
└── Properties/             # Configuración del proyecto
```

## Base de Datos

### Tablas Principales

#### Categoria
- `Id` (PK, Identity)
- `Nombre` (varchar(50), UNIQUE)

#### Empleados
- `Id` (PK, Identity)
- `NumeroCarnet` (varchar(50), UNIQUE)
- `Nombre` (varchar(50))
- `FechaNacimiento` (date)
- `Categoria` (varchar(50), FK)
- `Salario` (decimal(10,2), CHECK 250000-500000)
- `Direccion` (varchar(100), DEFAULT 'San José')
- `Telefono` (varchar(15))
- `Correo` (varchar(100), UNIQUE)

#### Proyectos
- `Id` (PK, Identity)
- `Codigo` (varchar(50), UNIQUE)
- `Nombre` (varchar(100), UNIQUE)
- `FechaInicio` (date)
- `FechaFin` (date)

#### Asignaciones
- `Id` (PK, Identity)
- `EmpleadoId` (int, FK)
- `ProyectoId` (int, FK)
- `FechaAsignacion` (date)

### Procedimientos Almacenados
- `IngresarEmpleado`
- `BorrarEmpleado`
- `IngresarProyecto`
- `BorrarProyecto`
- `IngresarAsignacion`
- `BorrarAsignacion`

## Tecnologías Utilizadas

- **Framework**: ASP.NET Web Forms (.NET Framework 4.8)
- **Base de Datos**: SQL Server
- **Lenguaje**: C#
- **Frontend**: HTML, CSS, JavaScript
- **Arquitectura**: 3 capas (Presentación, Lógica, Modelo)

## Instalación y Configuración

1. **Prerrequisitos**
   - Visual Studio 2019 o superior
   - SQL Server (LocalDB o Express)
   - .NET Framework 4.8

2. **Configuración de Base de Datos**
   - Ejecutar el script `examen final.sql`
   - Actualizar la cadena de conexión en `Web.config`

3. **Compilación**
   - Abrir la solución en Visual Studio
   - Restaurar paquetes NuGet
   - Compilar el proyecto

## Validaciones Implementadas

### Empleados
- Campos obligatorios: Carnet, Nombre, Fecha de Nacimiento, Correo
- Validación de formato de correo
- Rango de salario: ₡250,000 - ₡500,000
- Unicidad de carnet y correo

### Proyectos
- Campos obligatorios: Código, Nombre, Fecha de Inicio
- Validación de fechas lógicas (fin > inicio)
- Unicidad de código y nombre

### Asignaciones
- Validación de existencia de empleado y proyecto
- Prevención de asignaciones duplicadas
- Campos obligatorios validados

## Funcionalidades Destacadas

### 🔍 Búsqueda Avanzada
- Búsqueda de empleados por múltiples criterios
- Resultados en tiempo real

### 📱 Responsive Design
- Adaptación automática a diferentes tamaños de pantalla
- Menú colapsable en dispositivos móviles

### 🔄 Dropdowns Inteligentes
- Selección automática de IDs mediante dropdowns
- Sincronización entre dropdown y campo manual

### ⚠️ Validación Robusta
- Validación en cliente y servidor
- Mensajes de error descriptivos
- Confirmaciones para operaciones críticas

## Autor

Desarrollado como parte del examen final del curso de Programación 2.

## Licencia

Este proyecto es de uso académico.