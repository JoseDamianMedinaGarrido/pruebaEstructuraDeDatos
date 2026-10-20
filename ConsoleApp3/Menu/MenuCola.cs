using SolucionadorEstructuras.Estrcuturas;
using SolucionadorEstructuras.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolucionadorEstructuras.Menu
{
        // Este menú permite practicar las operaciones de una cola
        // utilizando nombres de personas como datos de ejemplo.
        public static class MenuColas
        {
            public static void Mostrar()
            {
                // La cola se conserva mientras el usuario permanece
                // dentro de este menú.
                Cola<string> cola = new Cola<string>();
                bool regresar = false;

                // El ciclo muestra las opciones hasta elegir Regresar.
                while (!regresar)
                {
                    Console.Clear();
                    Console.WriteLine("========== COLAS ==========");
                    Console.WriteLine("1. Enqueue: agregar persona");
                    Console.WriteLine("2. Dequeue: atender persona");
                    Console.WriteLine("3. Peek: siguiente persona");
                    Console.WriteLine("4. Mostrar fila");
                    Console.WriteLine("5. Simular atencion");
                    Console.WriteLine("6. Regresar");

                    int opcion = Entrada.LeerEntero("Opcion: ");

                    switch (opcion)
                    {
                        case 1:
                            {
                                // Se valida el nombre antes de agregarlo al final.
                                Console.Write("Nombre de la persona: ");
                                string nombre = Console.ReadLine() ?? "";

                                if (string.IsNullOrWhiteSpace(nombre))
                                {
                                    Console.WriteLine(
                                        "El nombre no puede estar vacio.");
                                }
                                else
                                {
                                    nombre = nombre.Trim();
                                    cola.Enqueue(nombre);

                                    Console.WriteLine(
                                        $"{nombre} se agrego a la fila.");
                                }

                                Entrada.Pausa();
                                break;
                            }

                        case 2:
                            // Dequeue atiende a la persona que lleva más tiempo
                            // esperando, respetando el orden FIFO.
                            if (cola.EstaVacia)
                                Console.WriteLine(
                                    "No hay personas en la fila.");
                            else
                                Console.WriteLine(
                                    "Atendiendo a: " + cola.Dequeue());

                            Entrada.Pausa();
                            break;

                        case 3:
                            // Peek consulta quien será atendido sin retirarlo.
                            if (cola.EstaVacia)
                                Console.WriteLine("La fila esta vacia.");
                            else
                                Console.WriteLine(
                                    "Siguiente: " + cola.Peek());

                            Entrada.Pausa();
                            break;

                        case 4:
                            // Mostrar representa visualmente toda la fila.
                            cola.Mostrar();
                            Entrada.Pausa();
                            break;

                        case 5:
                            // La simulación atiende a todos los elementos.
                            SimularAtencion(cola);
                            Entrada.Pausa();
                            break;

                        case 6:
                            regresar = true;
                            break;

                        default:
                            Console.WriteLine("Opcion no valida.");
                            Entrada.Pausa();
                            break;
                    }
                }
            }

            private static void SimularAtencion(Cola<string> cola)
            {
                // Si no hay elementos, la simulación termina inmediatamente.
                if (cola.EstaVacia)
                {
                    Console.WriteLine(
                        "No hay personas por atender.");
                    return;
                }

                Console.WriteLine("Iniciando atencion...");

                // Se retira continuamente el frente hasta vaciar la cola.
                while (!cola.EstaVacia)
                {
                    Console.WriteLine(
                        "Atendiendo a " + cola.Dequeue() + "...");
                }

                Console.WriteLine("Se atendio a toda la fila.");
            }
        }
    
}

