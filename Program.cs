using System;

List<string> productos = new List<string>();
List<decimal> precios = new List<decimal>();
List<int> stocks = new List<int>();
List<int> unidadesVendidas = new List<int>();

int totalVentas = 0;
decimal totalCaja = 0;

int opcion;

do
{
    Console.Clear();

    ImprimirEncabezado("SISTEMA GESTOR DE VENTAS E INVENTARIO");

    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Ver inventario");
    Console.WriteLine("3. Registrar venta");
    Console.WriteLine("4. Caja y estadísticas del día");
    Console.WriteLine("5. Salir");
    Console.WriteLine();

    opcion = LeerEntero("Seleccione una opción: ", 1, 5);

    switch (opcion)
    {
        case 1:
            RegistrarProducto(productos, precios, stocks, unidadesVendidas);
            break;

        case 2:
            VerInventario(productos, precios, stocks);
            break;

        case 3:
            RegistrarVenta(
                productos,
                precios,
                stocks,
                unidadesVendidas,
                ref totalVentas,
                ref totalCaja
            );
            break;

        case 4:
            MostrarEstadisticas(
                productos,
                unidadesVendidas,
                totalVentas,
                totalCaja
            );
            break;

        case 5:
            Console.Clear();
            ImprimirEncabezado("GRACIAS POR UTILIZAR EL SISTEMA");
            Console.WriteLine("Hasta luego.");
            break;
    }

    if (opcion != 5)
    {
        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar...");
        Console.ReadLine();
    }

} while (opcion != 5);


// =====================================================
// MÉTODO PARA REGISTRAR PRODUCTOS
// =====================================================

static void RegistrarProducto(
    List<string> productos,
    List<decimal> precios,
    List<int> stocks,
    List<int> unidadesVendidas)
{
    Console.Clear();

    ImprimirEncabezado("REGISTRAR PRODUCTO");

    string nombre;

    do
    {
        Console.Write("Nombre del producto: ");
        nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
        }

    } while (string.IsNullOrWhiteSpace(nombre));

    for (int i = 0; i < productos.Count; i++)
    {
        if (productos[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Ese producto ya existe.");
            return;
        }
    }

    decimal precio = LeerDecimal("Precio unitario: $", 0.01m);

    int stock = LeerEntero(
        "Cantidad de stock inicial: ",
        0,
        int.MaxValue
    );

    productos.Add(nombre);
    precios.Add(precio);
    stocks.Add(stock);
    unidadesVendidas.Add(0);

    Console.WriteLine();
    Console.WriteLine("Producto registrado correctamente.");
}


// =====================================================
// MÉTODO PARA VER INVENTARIO
// =====================================================

static void VerInventario(
    List<string> productos,
    List<decimal> precios,
    List<int> stocks)
{
    Console.Clear();

    ImprimirEncabezado("INVENTARIO");

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    Console.WriteLine(
        "{0,-5} {1,-25} {2,15} {3,10}",
        "ID",
        "PRODUCTO",
        "PRECIO",
        "STOCK"
    );

    Console.WriteLine(new string('-', 60));

    for (int i = 0; i < productos.Count; i++)
    {
        Console.WriteLine(
            "{0,-5} {1,-25} {2,15:C} {3,10}",
            i + 1,
            productos[i],
            precios[i],
            stocks[i]
        );

        if (stocks[i] < 5)
        {
            Console.WriteLine("      ALERTA: stock bajo.");
        }
    }
}


// =====================================================
// MÉTODO PARA REGISTRAR UNA VENTA
// =====================================================

static void RegistrarVenta(
    List<string> productos,
    List<decimal> precios,
    List<int> stocks,
    List<int> unidadesVendidas,
    ref int totalVentas,
    ref decimal totalCaja)
{
    Console.Clear();

    ImprimirEncabezado("REGISTRAR VENTA");

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    Console.WriteLine("Productos disponibles:");
    Console.WriteLine();

    for (int i = 0; i < productos.Count; i++)
    {
        Console.WriteLine(
            "{0}. {1} - Precio: {2:C} - Stock: {3}",
            i + 1,
            productos[i],
            precios[i],
            stocks[i]
        );
    }

    Console.WriteLine();

    int productoSeleccionado = LeerEntero(
        "Seleccione el código del producto: ",
        1,
        productos.Count
    );

    int indice = productoSeleccionado - 1;

    if (stocks[indice] == 0)
    {
        Console.WriteLine("Este producto no tiene stock disponible.");
        return;
    }

    int cantidad = LeerEntero(
        "Cantidad a comprar: ",
        1,
        int.MaxValue
    );

    if (cantidad > stocks[indice])
    {
        Console.WriteLine(
            "No hay suficiente stock. Solo quedan {0} unidades.",
            stocks[indice]
        );
        return;
    }

    bool tieneDescuento = false;

    string respuesta;

    do
    {
        Console.Write("¿Es cliente frecuente? (S/N): ");
        respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

        if (respuesta != "S" && respuesta != "N")
        {
            Console.WriteLine("Debe responder S o N.");
        }

    } while (respuesta != "S" && respuesta != "N");

    if (respuesta == "S")
    {
        tieneDescuento = true;
    }

    decimal montoIva;
    decimal montoDescuento;

    decimal total = CalcularFactura(
        precios[indice],
        cantidad,
        tieneDescuento,
        out montoIva,
        out montoDescuento
    );

    decimal subtotal = precios[indice] * cantidad;

    stocks[indice] -= cantidad;
    unidadesVendidas[indice] += cantidad;

    totalVentas++;
    totalCaja += total;

    Console.WriteLine();
    ImprimirEncabezado("TICKET DE VENTA");

    Console.WriteLine("Producto:        {0}", productos[indice]);
    Console.WriteLine("Cantidad:        {0}", cantidad);
    Console.WriteLine("Precio unitario: {0:C}", precios[indice]);
    Console.WriteLine("Subtotal:        {0:C}", subtotal);
    Console.WriteLine("Descuento:       {0:C}", montoDescuento);
    Console.WriteLine("IVA (19%):       {0:C}", montoIva);
    Console.WriteLine("TOTAL:           {0:C}", total);
    Console.WriteLine("Stock restante:  {0}", stocks[indice]);

    Console.WriteLine();
    Console.WriteLine("Venta registrada correctamente.");
}


// =====================================================
// MÉTODO PARA MOSTRAR ESTADÍSTICAS
// =====================================================

static void MostrarEstadisticas(
    List<string> productos,
    List<int> unidadesVendidas,
    int totalVentas,
    decimal totalCaja)
{
    Console.Clear();

    ImprimirEncabezado("CAJA Y ESTADÍSTICAS DEL DÍA");

    Console.WriteLine("Total de ventas realizadas: {0}", totalVentas);
    Console.WriteLine("Total de dinero en caja:    {0:C}", totalCaja);

    if (totalVentas > 0)
    {
        decimal promedio = totalCaja / totalVentas;

        Console.WriteLine(
            "Promedio de dinero por venta: {0:C}",
            promedio
        );
    }
    else
    {
        Console.WriteLine("Promedio por venta: $0");
    }

    Console.WriteLine();

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    int mayorIndice = 0;

    for (int i = 1; i < unidadesVendidas.Count; i++)
    {
        if (unidadesVendidas[i] > unidadesVendidas[mayorIndice])
        {
            mayorIndice = i;
        }
    }

    if (unidadesVendidas[mayorIndice] > 0)
    {
        Console.WriteLine(
            "Producto con más unidades vendidas: {0} ({1} unidades)",
            productos[mayorIndice],
            unidadesVendidas[mayorIndice]
        );
    }
    else
    {
        Console.WriteLine("Todavía no se han vendido productos.");
    }
}


// =====================================================
// MÉTODO PARA LEER ENTEROS DE FORMA SEGURA
// =====================================================

static int LeerEntero(string mensaje, int min, int max)
{
    int valor;

    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";

        if (int.TryParse(entrada, out valor))
        {
            if (valor >= min && valor <= max)
            {
                return valor;
            }
        }

        Console.WriteLine(
            "Entrada no válida. Debe ingresar un número entre {0} y {1}.",
            min,
            max
        );
    }
}


// =====================================================
// MÉTODO PARA LEER DECIMALES DE FORMA SEGURA
// =====================================================

static decimal LeerDecimal(string mensaje, decimal min)
{
    decimal valor;

    while (true)
    {
        Console.Write(mensaje);

        string entrada = Console.ReadLine() ?? "";

        if (decimal.TryParse(entrada, out valor))
        {
            if (valor >= min)
            {
                return valor;
            }
        }

        Console.WriteLine(
            "Entrada no válida. El valor debe ser mayor o igual a {0}.",
            min
        );
    }
}


// =====================================================
// MÉTODO PARA CALCULAR LA FACTURA
// =====================================================

static decimal CalcularFactura(
    decimal precio,
    int cantidad,
    bool tieneDescuento,
    out decimal montoIva,
    out decimal montoDescuento)
{
    decimal subtotal = precio * cantidad;

    if (tieneDescuento)
    {
        montoDescuento = subtotal * 0.10m;
    }
    else
    {
        montoDescuento = 0;
    }

    decimal baseConDescuento = subtotal - montoDescuento;

    montoIva = baseConDescuento * 0.19m;

    decimal total = baseConDescuento + montoIva;

    return total;
}


// =====================================================
// MÉTODO PARA IMPRIMIR ENCABEZADOS
// =====================================================

static void ImprimirEncabezado(string titulo)
{
    Console.WriteLine("==============================================");
    Console.WriteLine(" " + titulo);
    Console.WriteLine("==============================================");
}