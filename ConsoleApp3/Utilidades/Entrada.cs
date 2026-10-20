using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SolucionadorEstructuras.Utilidades
{
        // Centraliza la lectura, conversión y validación de datos del usuario.
        public static class Entrada
        {
            public static BigInteger LeerBigInteger(string mensaje)
            {
                // Se repite la solicitud hasta recibir un entero válido.
                while (true)
                {
                    Console.Write(mensaje);
                    string entrada = Console.ReadLine() ?? "";

                    // TryParse evita excepciones cuando el texto no es numérico.
                    if (BigInteger.TryParse(entrada, out BigInteger numero))
                        return numero;

                    Console.WriteLine(
                        "Entrada incorrecta. Escribe un numero entero.");
                }
            }

            public static int LeerEntero(string mensaje)
            {
                // Esta versión limita la conversión al rango de int.
                while (true)
                {
                    Console.Write(mensaje);
                    string entrada = Console.ReadLine() ?? "";

                    if (int.TryParse(entrada, out int numero))
                        return numero;

                    Console.WriteLine(
                        "Entrada incorrecta. Escribe un numero entero.");
                }
            }

            public static void Pausa()
            {
                // Detiene la pantalla hasta que el usuario presiona ENTER.
                Console.WriteLine(
                    "\nPresiona ENTER para continuar...");
                Console.ReadLine();
            }
        }
}


