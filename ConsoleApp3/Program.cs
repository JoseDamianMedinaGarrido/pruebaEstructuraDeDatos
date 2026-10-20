
using SolucionadorEstructuras.Menu;
using SolucionadorEstructuras.Utilidades;
using System;

namespace SolucionadorEstructuras
{
    // Punto de entrada de la aplicación de consola.
    internal class Program
    {
        static void Main(string[] args)
        {
            // Controla la permanencia del usuario en el menú principal.
            bool salir = false;

            // El menú se repite hasta seleccionar la opción Salir.
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine(" SOLUCIONADOR DE ESTRUCTURAS");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Recursividad");
                Console.WriteLine("2. Pilas");
                Console.WriteLine("3. Colas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("====================================");

                int opcion = Entrada.LeerEntero(
                    "Selecciona una opcion: ");

                // Cada opción delega el trabajo en el menú especializado.
                switch (opcion)
                {
                    case 1:
                        MenuRecursividad.Mostrar();
                        break;

                    case 2:
                        MenuPilas.Mostrar();
                        break;

                    case 3:
                        MenuColas.Mostrar();
                        break;

                    case 4:
                        // Cambiar esta bandera termina el ciclo principal.
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Entrada.Pausa();
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
    }
}
