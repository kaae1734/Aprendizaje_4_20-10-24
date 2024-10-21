/*
Ejercicio no 3. 

Desarrolla un programa que gestione las calificaciones de un 
grupo de estudiantes. El programa debe: 
✓ Permitir ingresar las calificaciones de varios 
estudiantes. 
✓ Calcular el promedio de calificaciones de cada 
estudiante. 
✓ Determinar el estudiante con el promedio más alto y el 
más bajo. 
Requisitos: 
✓ Implementar 
la 
función 
agregar_estudiante 
(estudiantes, nombre, calificaciones) para agregar 
estudiantes y sus calificaciones (una lista de notas). 
✓ Implementar 
la 
función 
calcular_promedio 
(calificaciones) para calcular el promedio de un 
estudiante. 
✓ Implementar 
la 
función 
determinar_mejor_peor_estudiante (estudiantes) que 
devuelva los nombres del estudiante con el promedio 
más alto y el promedio más bajo. 
 */

namespace Ejercicio_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public class Estudiante
        {
            public string Nombre { get; set; }
            public List<double> Calificaciones { get; set; }
            public double Promedio { get; set; }
        }

        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            int opcion;

            do
            {
                Console.WriteLine("\n=== Gestión de Calificaciones de Estudiantes ===");
                Console.WriteLine("1. Agregar estudiante y sus calificaciones");
                Console.WriteLine("2. Mostrar promedios de cada estudiante");
                Console.WriteLine("3. Mostrar el estudiante con el mejor y peor promedio");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Seleccione una opción:");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        agregar_estudiante(estudiantes);
                        break;
                    case 2:
                        mostrar_promedios(estudiantes);
                        break;
                    case 3:
                        determinar_mejor_peor_estudiante(estudiantes);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 4);
        }

        static void agregar_estudiante(List<Estudiante> estudiantes)
        {
            Console.WriteLine("Ingrese el nombre del estudiante:");
            string nombre = Console.ReadLine();

            List<double> calificaciones = new List<double>();
            Console.WriteLine("Ingrese el número de calificaciones:");
            int numCalificaciones = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCalificaciones; i++)
            {
                Console.WriteLine($"Ingrese la calificación {i + 1}:");
                double calificacion = double.Parse(Console.ReadLine());
                calificaciones.Add(calificacion);
            }

            estudiantes.Add(new Estudiante
            {
                Nombre = nombre,
                Calificaciones = calificaciones,
                Promedio = calcular_promedio(calificaciones)
            });

            Console.WriteLine("Estudiante agregado exitosamente.");
        }

        static double calcular_promedio(List<double> calificaciones)
        {
            return calificaciones.Average();
        }

        static void mostrar_promedios(List<Estudiante> estudiantes)
        {
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"Estudiante: {estudiante.Nombre}, Promedio: {estudiante.Promedio}");
            }
        }

        static void determinar_mejor_peor_estudiante(List<Estudiante> estudiantes)
        {
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes en la lista.");
                return;
            }

            var mejorEstudiante = estudiantes.OrderByDescending(e => e.Promedio).First();
            var peorEstudiante = estudiantes.OrderBy(e => e.Promedio).First();

            Console.WriteLine($"El estudiante con el mejor promedio es {mejorEstudiante.Nombre} con {mejorEstudiante.Promedio}");
            Console.WriteLine($"El estudiante con el peor promedio es {peorEstudiante.Nombre} con {peorEstudiante.Promedio}");
        }
    }

}

