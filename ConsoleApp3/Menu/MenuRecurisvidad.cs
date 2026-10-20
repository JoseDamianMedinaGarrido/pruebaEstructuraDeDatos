using System;
using System.Numerics;
using SolucionadorEstructuras.Utilidades;
using RecursividadService = SolucionadorEstructuras.Recursividad.Recursividad;


namespace SolucionadorEstructuras.Menu
{

        public static class MenuRecursividad
        {
            public static void Mostrar()
            {
                bool regresar = false;

                while (!regresar)
                {
                    Console.Clear();

                    Console.WriteLine("===== RECURSIVIDAD =====");
                    Console.WriteLine("1. Factorial");
                    Console.WriteLine("2. Fibonacci");
                    Console.WriteLine("3. Suma de 1 hasta N");
                    Console.WriteLine("4. Potencia");
                    Console.WriteLine("5. Regresar");

                    int opcion = Entrada.LeerEntero("Opcion: ");

                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                {
                                    BigInteger n =
                                        Entrada.LeerBigInteger("Numero: ");

                                    Console.WriteLine(
                                        $"{n}! = {RecursividadService.Factorial(n)}");

                                    Entrada.Pausa();
                                    break;
                                }

                            case 2:
                                {
                                    BigInteger n =
                                        Entrada.LeerBigInteger(
                                            "Posicion Fibonacci: ");

                                    Console.WriteLine(
                                        $"F({n}) = {RecursividadService.Fibonacci(n)}");

                                    Entrada.Pausa();
                                    break;
                                }

                            case 3:
                                {
                                    BigInteger n =
                                        Entrada.LeerBigInteger("Numero N: ");

                                    Console.WriteLine(
                                        $"Suma de 1 a {n} = " +
                                        $"{RecursividadService.SumaRecursiva(n)}");

                                    Entrada.Pausa();
                                    break;
                                }

                            case 4:
                                {
                                    BigInteger baseNumero =
                                        Entrada.LeerBigInteger("Base: ");

                                    BigInteger exponente =
                                        Entrada.LeerBigInteger("Exponente: ");

                                    Console.WriteLine(
                                        $"{baseNumero}^{exponente} = " +
                                        $"{RecursividadService.Potencia(
                                            baseNumero, exponente)}");

                                    Entrada.Pausa();
                                    break;
                                }

                            case 5:
                                regresar = true;
                                break;

                            default:
                                Console.WriteLine("Opcion no valida.");
                                Entrada.Pausa();
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Entrada.Pausa();
                    }
                }
            }
        }
}


