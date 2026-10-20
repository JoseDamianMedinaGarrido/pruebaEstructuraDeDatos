using SolucionadorEstructuras.Estrcuturas;
using SolucionadorEstructuras.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;


namespace SolucionadorEstructuras.Menu
{
        // Este menú muestra operaciones LIFO y dos aplicaciones prácticas
        // de una pila: invertir texto y validar delimitadores.
        public static class MenuPilas
        {
            public static void Mostrar()
            {
                // Esta pila contiene números para demostrar las operaciones
                // básicas desde el menú.
                Pila<int> pila = new Pila<int>();
                bool regresar = false;

                // El menú se repite hasta que el usuario selecciona Regresar.
                while (!regresar)
                {
                    Console.Clear();
                    Console.WriteLine("========== PILAS ==========");
                    Console.WriteLine("1. Push: agregar elemento");
                    Console.WriteLine("2. Pop: eliminar elemento");
                    Console.WriteLine("3. Peek: consultar cima");
                    Console.WriteLine("4. Mostrar pila");
                    Console.WriteLine("5. Invertir palabra");
                    Console.WriteLine("6. Verificar parentesis");
                    Console.WriteLine("7. Regresar");

                    int opcion = Entrada.LeerEntero("Opcion: ");

                    switch (opcion)
                    {
                        case 1:
                            // Push coloca un elemento nuevo en la cima.
                            pila.Push(Entrada.LeerEntero(
                                "Numero a agregar: "));

                            Console.WriteLine("Elemento agregado.");
                            Entrada.Pausa();
                            break;

                        case 2:
                            // Pop elimina y devuelve el elemento de la cima.
                            if (pila.EstaVacia)
                                Console.WriteLine("La pila esta vacia.");
                            else
                                Console.WriteLine(
                                    "Eliminado: " + pila.Pop());

                            Entrada.Pausa();
                            break;

                        case 3:
                            // Peek consulta la cima sin eliminarla.
                            if (pila.EstaVacia)
                                Console.WriteLine("La pila esta vacia.");
                            else
                                Console.WriteLine(
                                    "Cima: " + pila.Peek());

                            Entrada.Pausa();
                            break;

                        case 4:
                            // Se muestran los elementos desde la cima hacia abajo.
                            pila.Mostrar();
                            Entrada.Pausa();
                            break;

                        case 5:
                            {
                                // Cada carácter se apila y luego se extrae;
                                // por eso el texto queda en orden inverso.
                                Console.Write("Escribe una palabra: ");
                                string palabra = Console.ReadLine() ?? "";

                                Pila<char> caracteres = new Pila<char>();

                                foreach (char c in palabra)
                                    caracteres.Push(c);

                                Console.Write("Invertida: ");

                                while (!caracteres.EstaVacia)
                                    Console.Write(caracteres.Pop());

                                Console.WriteLine();
                                Entrada.Pausa();
                                break;
                            }

                        case 6:
                            {
                                // Los delimitadores de apertura se guardan
                                // para compararlos con los de cierre.
                                Console.Write("Escribe una expresion: ");
                                string expresion = Console.ReadLine() ?? "";

                                Console.WriteLine(
                                    ParentesisBalanceados(expresion)
                                    ? "Los delimitadores estan balanceados."
                                    : "Los delimitadores NO estan balanceados.");

                                Entrada.Pausa();
                                break;
                            }

                        case 7:
                            regresar = true;
                            break;

                        default:
                            Console.WriteLine("Opcion no valida.");
                            Entrada.Pausa();
                            break;
                    }
                }
            }

            private static bool ParentesisBalanceados(
                string expresion)
            {
                // La pila conserva el ultimo delimitador de apertura visto.
                Pila<char> pila = new Pila<char>();

                // Se revisa cada carácter de la expresión en orden.
                foreach (char c in expresion)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        pila.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        // Un cierre sin apertura correspondiente invalida
                        // inmediatamente la expresión.
                        if (pila.EstaVacia)
                            return false;

                        char apertura = pila.Pop();

                        // El tipo de apertura debe coincidir con el cierre.
                        bool coincide =
                            (apertura == '(' && c == ')') ||
                            (apertura == '[' && c == ']') ||
                            (apertura == '{' && c == '}');

                        if (!coincide)
                            return false;
                    }
                }

                // Si quedaron aperturas pendientes, faltan cierres.
                return pila.EstaVacia;
            }
        }
}



