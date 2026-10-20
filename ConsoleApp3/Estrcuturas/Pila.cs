using System;
using System.Collections.Generic;
using System.Text;

namespace SolucionadorEstructuras.Estrcuturas
{    
        // Una pila trabaja con el principio LIFO: el ultimo elemento
        // agregado es el primero que se puede retirar.
        public class Pila<T>
        {
            // El arreglo almacena los elementos de la pila.
            private T[] elementos = new T[4];
            // cima indica la posicion del elemento superior.
            private int cima = -1;

            // La cantidad de elementos es la posicion superior mas uno.
            public int Cantidad => cima + 1;
            // La pila esta vacia cuando no existe una posicion superior.
            public bool EstaVacia => cima == -1;

            public void Push(T elemento)
            {
                // Si no queda espacio, se duplica la capacidad del arreglo.
                if (Cantidad == elementos.Length)
                {
                    Array.Resize(
                        ref elementos, elementos.Length * 2);
                }

                // Se avanza la cima y se guarda el nuevo elemento.
                elementos[++cima] = elemento;
            }

            public T Pop()
            {
                // No se puede retirar un elemento de una pila vacia.
                if (EstaVacia)
                    throw new InvalidOperationException(
                        "La pila esta vacia.");

                // Se obtiene el elemento superior y se libera su posicion.
                T elemento = elementos[cima];
                elementos[cima] = default(T);
                cima--;

                return elemento;
            }

            public T Peek()
            {
                // Peek consulta la cima sin modificar la pila.
                if (EstaVacia)
                    throw new InvalidOperationException(
                        "La pila esta vacia.");

                return elementos[cima];
            }

            public void Mostrar()
            {
                // Una pila vacia no tiene elementos que mostrar.
                if (EstaVacia)
                {
                    Console.WriteLine("La pila esta vacia.");
                    return;
                }

                Console.WriteLine("Cima ->");

                // Se recorre desde la cima hasta el primer elemento.
                for (int i = cima; i >= 0; i--)
                    Console.WriteLine("| " + elementos[i] + " |");

                Console.WriteLine("--------");
            }
        }
    
}
