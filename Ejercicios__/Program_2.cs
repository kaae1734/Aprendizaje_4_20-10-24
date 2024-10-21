/*
Ejercicio No. 2 

Desarrollar un programa que permita al usuario gestionar una cuenta bancaria. El programa 
deberá utilizar un menú que permita realizar diferentes operaciones sobre el saldo de la cuenta. 

Menú de opciones: 
1. Consultar saldo 
2. Depositar dinero 
3. Retirar dinero 
4. Salir 

El programa debe permitir al usuario ingresar la cantidad para depositar o retirar, actualizar el 
saldo y mostrar los resultados. Si se elige la opción de retiro, debe verificar que el saldo sea 
suficiente.  
*/

using System;
using System.Collections.Generic;

namespace Ejercicio_2
{
    class Program
    {
        static void Main()
        {
            double saldo = 0;
            int opcion = 0;
            List<string> transacciones = new List<string>(); 

            do
            {
                Console.WriteLine("\n--- Menú de Cuenta Bancaria ---");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Ver historial de transacciones"); 
                Console.WriteLine("5. Salir");
                Console.Write("\nElige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: consultar_saldo(saldo); break;
                    case 2: saldo = depositar_dinero(saldo, transacciones); break;
                    case 3: saldo = retirar_dinero(saldo, transacciones); break;
                    case 4: mostrar_historial(transacciones); break; 
                    case 5: Console.WriteLine("Gracias por utilizar la cuenta bancaria."); break;
                    default: Console.WriteLine("Opción no válida, intenta de nuevo."); break;
                }

            } while (opcion != 5);
        }

        static void consultar_saldo(double saldo)
        {
            Console.WriteLine($"\nTu saldo actual es: {saldo:C2}");
        }

        static double depositar_dinero(double saldo, List<string> transacciones)
        {
            Console.Write("\nIngresa la cantidad a depositar: ");
            double cantidad = double.Parse(Console.ReadLine());

            if (cantidad > 0)
            {
                saldo += cantidad;
                Console.WriteLine($"Has depositado {cantidad:C2}. Tu nuevo saldo es: {saldo:C2}");
                transacciones.Add($"Depósito de {cantidad:C2}. Saldo: {saldo:C2}"); 
            }
            else
            {
                Console.WriteLine("La cantidad debe ser positiva.");
            }

            return saldo;
        }

        static double retirar_dinero(double saldo, List<string> transacciones)
        {
            Console.Write("\nIngresa la cantidad a retirar: ");
            double cantidad = double.Parse(Console.ReadLine());

            if (cantidad > 0)
            {
                if (cantidad <= saldo)
                {
                    saldo -= cantidad;
                    Console.WriteLine($"Has retirado {cantidad:C2}. Tu nuevo saldo es: {saldo:C2}");
                    transacciones.Add($"Retiro de {cantidad:C2}. Saldo: {saldo:C2}"); 
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("La cantidad debe ser positiva.");
            }

            return saldo;
        }

        static void mostrar_historial(List<string> transacciones)
        {
            Console.WriteLine("\n--- Historial de Transacciones ---");
            if (transacciones.Count > 0)
            {
                foreach (var transaccion in transacciones)
                {
                    Console.WriteLine(transaccion);
                }
            }
            else
            {
                Console.WriteLine("No hay transacciones registradas.");
            }
        }
    }
}

