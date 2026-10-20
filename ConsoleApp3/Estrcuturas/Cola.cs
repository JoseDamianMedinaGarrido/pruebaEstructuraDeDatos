using System;
using System.Collections.Generic;
using System.Text;

namespace SolucionadorEstructuras.Estrcuturas
{
        // Una cola trabaja con el principio FIFO: el primer elemento
        // agregado es el primero que se puede retirar.
        public class Cola<T>
        {
            // El arreglo circular contiene los elementos de la cola.
            private T[] elementos = new T[4];
            // frente apunta al primer elemento disponible.
            private int frente = 0;
            // cantidad indica cuantos elementos hay actualmente.
            private int cantidad = 0;

            // Propiedades de consulta para conocer el estado de la cola.
            public int Cantidad => cantidad;
            public bool EstaVacia => cantidad == 0;

            public void Enqueue(T elemento)
            {
                // Cuando el arreglo se llena, se duplica su capacidad.
                if (cantidad == elementos.Length)
                    Redimensionar();

                // La posicion final se calcula de forma circular.
                int final =
                    (frente + cantidad) % elementos.Length;

                elementos[final] = elemento;
                cantidad++;
            }

            public T Dequeue()
            {
                // No se puede retirar un elemento de una cola vacia.
                if (EstaVacia)
                    throw new InvalidOperationException(
                        "La cola esta vacia.");

                // Se obtiene el frente, se limpia y se avanza circularmente.
                T elemento = elementos[frente];
                elementos[frente] = default(T);

                frente = (frente + 1) % elementos.Length;
                cantidad--;

                return elemento;
            }

            public T Peek()
            {
                // Peek consulta el frente sin retirarlo de la cola.
                if (EstaVacia)
                    throw new InvalidOperationException(
                        "La cola esta vacia.");

                return elementos[frente];
            }

            private void Redimensionar()
            {
                // Se crea un arreglo mayor y se copian los elementos
                // respetando el orden logico de la cola.
                T[] nueva = new T[elementos.Length * 2];

                for (int i = 0; i < cantidad; i++)
                {
                    nueva[i] = elementos[
                        (frente + i) % elementos.Length];
                }

                elementos = nueva;
                // Tras copiar, el primer elemento queda en la posicion cero.
                frente = 0;
            }

            public void Mostrar()
            {
                // Una cola vacia no tiene elementos que mostrar.
                if (EstaVacia)
                {
                    Console.WriteLine("La cola esta vacia.");
                    return;
                }

                Console.Write("Frente -> ");

                // Se recorre desde el frente hasta el final de la cola.
                for (int i = 0; i < cantidad; i++)
                {
                    int indice =
                        (frente + i) % elementos.Length;

                    Console.Write(elementos[indice]);

                    if (i < cantidad - 1)
                        Console.Write(" -> ");
                }

                Console.WriteLine(" <- Final");
            }
     
        }
}


