# Sistema Gestor de Ventas e Inventario Express

## Información del estudiante

**Nombre:** Roberto Viloria  
**Proyecto:** Reto Final de Unidad 1  
**Tecnología:** C# / .NET 8

## Descripción

Este proyecto corresponde al Reto Final de la Unidad 1 de profundización en .NET.

Se desarrolló una aplicación de consola para gestionar productos, inventario y ventas de una tienda. El sistema permite registrar productos, consultar el inventario, realizar ventas y consultar las estadísticas de la jornada.

Los datos se manejan en memoria utilizando listas (`List<T>`), sin utilizar base de datos ni clases propias, de acuerdo con los requerimientos de la actividad.

## Funcionalidades

El sistema cuenta con las siguientes opciones:

1. **Registrar producto**
   - Permite ingresar el nombre, precio y stock inicial.
   - Valida que el nombre no esté vacío.
   - Valida que el precio sea mayor que cero.
   - Valida que el stock sea un número válido.
   - No permite registrar productos con nombres duplicados.

2. **Ver inventario**
   - Muestra el código, nombre, precio y stock de cada producto.
   - Genera una alerta cuando el stock es menor a 5 unidades.

3. **Registrar venta**
   - Permite seleccionar un producto y una cantidad.
   - Verifica que exista suficiente stock.
   - Permite aplicar un descuento del 10% a clientes frecuentes.
   - Calcula el IVA del 19%.
   - Actualiza automáticamente el inventario.
   - Muestra un ticket con el detalle de la venta.

4. **Caja y estadísticas**
   - Muestra el número total de ventas.
   - Muestra el dinero acumulado en caja.
   - Calcula el promedio de dinero por venta.
   - Identifica el producto con mayor cantidad de unidades vendidas.

5. **Salir**
   - Permite cerrar el sistema de manera controlada.

## Tecnologías utilizadas

- C#
- .NET 8
- Aplicación de consola
- `List<T>`
- Métodos `static`
- `if / else`
- `switch`
- Ciclos `for`, `do-while` y `while`
- `int.TryParse`
- `decimal.TryParse`

## Métodos principales

El proyecto implementa los métodos solicitados en la guía:

- `LeerEntero`
- `LeerDecimal`
- `CalcularFactura`
- `ImprimirEncabezado`

También se utilizan métodos adicionales para organizar las funciones de registro de productos, inventario, ventas y estadísticas.

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio

Desde una terminal:

```bash
git clone URL_DEL_REPOSITORIO