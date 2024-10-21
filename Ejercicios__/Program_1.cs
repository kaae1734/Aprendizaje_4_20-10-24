/*
Ejercicio No. 1

Crear un programa que simule la gestión de un inventario en una tienda. Utilizar un menú para
agregar, eliminar, modificar y consultar productos en el inventario. Cada producto tendrá un
código, nombre, cantidad y precio.
Menú de opciones:

1. Agregar producto
2. Eliminar producto
3. Modificar producto
4. Consultar producto
5. Mostrar todos los productos
6. Salir
*/

using System;
using System.Collections.Generic;

namespace Ejercicio_1
{
    class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio}";
        }
    }

    class Program
    {
        static void Main()
        {
            List<Producto> productos = new List<Producto>();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n--- Menú de Inventario ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Modificar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Mostrar todos los productos");
                Console.WriteLine("6. Salir");
                Console.Write("\nElige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: agregar_producto(productos); break;
                    case 2: eliminar_producto(productos); break;
                    case 3: modificar_producto(productos); break;
                    case 4: consultar_producto(productos); break;
                    case 5: mostrar_productos(productos); break;
                    case 6: Console.WriteLine("Gracias por utilizar el inventario de la tienda."); break;
                    default: Console.WriteLine("Opción no válida, intenta de nuevo."); break;
                }

            } while (opcion != 6);
        }

        static void agregar_producto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Agregar Producto ---");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());

            productos.Add(new Producto { Codigo = codigo, Nombre = nombre, Cantidad = cantidad, Precio = precio });
            Console.WriteLine("Producto agregado exitosamente.");
        }

        static void eliminar_producto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Eliminar Producto ---");
            Console.Write("Ingresa el código del producto a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void modificar_producto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Modificar Producto ---");
            Console.Write("Ingresa el código del producto a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                Console.Write("Nuevo nombre (deja vacío para mantener el actual): ");
                string nombre = Console.ReadLine();
                Console.Write("Nueva cantidad (deja vacío para mantener la actual): ");
                string cantidadStr = Console.ReadLine();
                Console.Write("Nuevo precio (deja vacío para mantener el actual): ");
                string precioStr = Console.ReadLine();

                if (!string.IsNullOrEmpty(nombre)) producto.Nombre = nombre;
                if (!string.IsNullOrEmpty(cantidadStr)) producto.Cantidad = int.Parse(cantidadStr);
                if (!string.IsNullOrEmpty(precioStr)) producto.Precio = double.Parse(precioStr);

                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void consultar_producto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Consultar Producto ---");
            Console.Write("Ingresa el código del producto a consultar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                Console.WriteLine(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void mostrar_productos(List<Producto> productos)
        {
            Console.WriteLine("\n--- Inventario Completo ---");
            if (productos.Count > 0)
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }
}

