# Sistema Gestor de Ventas e Inventario Express

## Información del estudiante

**Nombre:** Roberto Viloria
**Proyecto:** Reto Final de Unidad 1
**Tecnología:** C# / .NET 8

## Descripción

Este proyecto corresponde al Reto Final de la Unidad 1 de Profundización en .NET.

Se desarrolló una aplicación de consola para gestionar productos, inventario y ventas de una tienda. El sistema permite registrar productos, consultar el inventario, realizar ventas y consultar las estadísticas de la jornada.

Los datos se manejan en memoria utilizando listas (`List<T>`), sin utilizar bases de datos ni clases propias, de acuerdo con los requerimientos de la actividad.

## Funcionalidades

### 1. Registrar producto

* Permite ingresar el nombre, precio y stock inicial.
* Valida que el nombre no esté vacío.
* Valida que el precio sea mayor que cero.
* Valida que el stock sea un número entero válido.
* No permite registrar productos con nombres duplicados, sin importar mayúsculas o minúsculas.

### 2. Consultar inventario

* Muestra el código, nombre, precio y stock de cada producto.
* Genera una alerta cuando el stock es menor a 5 unidades.
* Informa cuando no existen productos registrados.

### 3. Registrar venta

* Permite seleccionar un producto y una cantidad.
* Verifica que exista suficiente stock.
* Permite aplicar un descuento del 10% a clientes frecuentes.
* Calcula el IVA del 19%.
* Actualiza automáticamente el inventario.
* Muestra un ticket con el detalle de la venta.

### 4. Caja y estadísticas

* Muestra el número total de ventas.
* Muestra el dinero acumulado en caja.
* Calcula el promedio de dinero por venta.
* Identifica el producto con mayor cantidad de unidades vendidas.

### 5. Salir

* Permite cerrar el sistema de manera controlada.

## Tecnologías utilizadas

* C#
* .NET 8
* Aplicación de consola
* `List<T>`
* Métodos `static`
* `if / else`
* `switch`
* Ciclos `for`, `do-while` y `while`
* `int.TryParse`
* `decimal.TryParse`

## Métodos principales

El proyecto implementa los métodos solicitados en la guía:

* `LeerEntero`
* `LeerDecimal`
* `CalcularFactura`
* `ImprimirEncabezado`

También se utilizan métodos adicionales para organizar las funciones de registro de productos, inventario, ventas y estadísticas.

## Requisitos

Para ejecutar el proyecto se necesita tener instalado:

* .NET 8 SDK
* Git

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio

Desde una terminal:

```bash
git clone https://github.com/roberto-viloria/Taller.git
```

### 2. Entrar a la carpeta del proyecto

```bash
cd Taller
```

### 3. Compilar el proyecto

```bash
dotnet build
```

Si la compilación es correcta, aparecerá el mensaje:

```text
Build succeeded.
```

### 4. Ejecutar el proyecto

```bash
dotnet run
```

## Ejemplo de ejecución

Al iniciar el programa se muestra el menú principal:

```text
====================================================
   SISTEMA GESTOR DE VENTAS E INVENTARIO (MINI-POS)
====================================================
1. Registrar nuevo producto en inventario
2. Consultar inventario completo
3. Registrar una venta
4. Ver reporte de caja y estadísticas diarias
5. Salir
====================================================
Seleccione una opción (1-5):
```

El sistema permite registrar productos, consultar sus existencias, realizar ventas con descuento e IVA y consultar las estadísticas acumuladas durante la sesión.

## Estructura del proyecto

```text
Taller/
│
├── Program.cs
├── GestorVentasUnidad1.csproj
├── README.md
└── .gitignore
```

## Restricciones de la actividad

El proyecto fue desarrollado utilizando los conceptos correspondientes a la Unidad 1.

No se utilizan:

* Clases personalizadas.
* Constructores.
* Herencia.
* Interfaces.
* Bases de datos.
* ORM.

La información se almacena en memoria mediante colecciones `List<T>`.
