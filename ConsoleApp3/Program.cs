
using System;

namespace SolucionadorEstructuras
{
    // ==========================================
    // PILA IMPLEMENTADA CON ARREGLO
    // ==========================================
    public class Pila<T>
    {
        private T[] elementos = new T[4];
        private int cima = -1;

        public int Cantidad => cima + 1;
        public bool EstaVacia => cima == -1;

        public void Push(T elemento)
        {
            if (Cantidad == elementos.Length)
                Array.Resize(ref elementos, elementos.Length * 2);

            elementos[++cima] = elemento;
        }

        public T Pop()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La pila esta vacia.");

            T elemento = elementos[cima];
            elementos[cima] = default(T);
            cima--;
            return elemento;
        }

        public T Peek()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La pila esta vacia.");

            return elementos[cima];
        }

        public void Mostrar()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La pila esta vacia.");
                return;
            }

            Console.WriteLine("Cima ->");

            for (int i = cima; i >= 0; i--)
                Console.WriteLine("| " + elementos[i] + " |");

            Console.WriteLine("--------");
        }
    }

    // ==========================================
    // COLA IMPLEMENTADA CON ARREGLO CIRCULAR
    // ==========================================
    public class Cola<T>
    {
        private T[] elementos = new T[4];
        private int frente = 0;
        private int cantidad = 0;

        public int Cantidad => cantidad;
        public bool EstaVacia => cantidad == 0;

        public void Enqueue(T elemento)
        {
            if (cantidad == elementos.Length)
                Redimensionar();

            int final = (frente + cantidad) % elementos.Length;
            elementos[final] = elemento;
            cantidad++;
        }

        public T Dequeue()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La cola esta vacia.");

            T elemento = elementos[frente];
            elementos[frente] = default(T);
            frente = (frente + 1) % elementos.Length;
            cantidad--;

            return elemento;
        }

        public T Peek()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La cola esta vacia.");

            return elementos[frente];
        }

        private void Redimensionar()
        {
            T[] nueva = new T[elementos.Length * 2];

            for (int i = 0; i < cantidad; i++)
                nueva[i] = elementos[(frente + i) % elementos.Length];

            elementos = nueva;
            frente = 0;
        }

        public void Mostrar()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La cola esta vacia.");
                return;
            }

            Console.Write("Frente -> ");

            for (int i = 0; i < cantidad; i++)
            {
                int indice = (frente + i) % elementos.Length;
                Console.Write(elementos[indice]);

                if (i < cantidad - 1)
                    Console.Write(" -> ");
            }

            Console.WriteLine(" <- Final");
        }
    }

    // ==========================================
    // PROGRAMA PRINCIPAL
    // ==========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine(" SOLUCIONADOR DE ESTRUCTURAS DE DATOS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Recursividad");
                Console.WriteLine("2. Pilas");
                Console.WriteLine("3. Colas");
                Console.WriteLine("4. Explicacion de estructuras");
                Console.WriteLine("5. Salir");
                Console.WriteLine("========================================");

                int opcion = LeerEntero("Selecciona una opcion: ");

                switch (opcion)
                {
                    case 1:
                        MenuRecursividad();
                        break;
                    case 2:
                        MenuPilas();
                        break;
                    case 3:
                        MenuColas();
                        break;
                    case 4:
                        Explicaciones();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }

        // ==========================================
        // MENU DE RECURSIVIDAD
        // ==========================================
        static void MenuRecursividad()
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

                int opcion = LeerEntero("Opcion: ");

                switch (opcion)
                {
                    case 1:
                        {
                            int n = LeerEntero("Numero (0 a 20): ");

                            if (n < 0 || n > 20)
                            {
                                Console.WriteLine("Ingresa un numero entre 0 y 20.");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"{n}! = {Factorial(n)}");
                            }

                            Pausa();
                            break;
                        }

                    case 2:
                        {
                            int n = LeerEntero(
                                "Posicion Fibonacci (0 a 40): ");

                            if (n < 0 || n > 40)
                            {
                                Console.WriteLine(
                                    "Ingresa un numero entre 0 y 40.");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"F({n}) = {Fibonacci(n)}");
                            }

                            Pausa();
                            break;
                        }

                    case 3:
                        {
                            int n = LeerEntero("Numero (0 a 10000): ");

                            if (n < 0 || n > 10000)
                            {
                                Console.WriteLine(
                                    "Ingresa un numero entre 0 y 10000.");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"Suma de 1 a {n} = {SumaRecursiva(n)}");
                            }

                            Pausa();
                            break;
                        }

                    case 4:
                        {
                            int baseNumero = LeerEntero("Base entera: ");
                            int exponente = LeerEntero(
                                "Exponente (0 a 30): ");

                            if (exponente < 0 || exponente > 30)
                            {
                                Console.WriteLine(
                                    "El exponente debe estar entre 0 y 30.");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"{baseNumero}^{exponente} = " +
                                    $"{Potencia(baseNumero, exponente)}");
                            }

                            Pausa();
                            break;
                        }

                    case 5:
                        regresar = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }
            }
        }

        // Funciones recursivas

        static long Factorial(int n)
        {
            if (n <= 1)
                return 1;

            return n * Factorial(n - 1);
        }

        // Fibonacci recursivo: definicion clasica.
        // Es intencionalmente sencillo para estudiar
        // las llamadas recursivas.
        static long Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static long SumaRecursiva(int n)
        {
            if (n == 0)
                return 0;

            return n + SumaRecursiva(n - 1);
        }

        static long Potencia(int baseNumero, int exponente)
        {
            if (exponente == 0)
                return 1;

            return baseNumero * Potencia(baseNumero, exponente - 1);
        }

        // ==========================================
        // MENU DE PILAS
        // ==========================================
        static void MenuPilas()
        {
            Pila<int> pila = new Pila<int>();
            bool regresar = false;

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

                int opcion = LeerEntero("Opcion: ");

                switch (opcion)
                {
                    case 1:
                        pila.Push(LeerEntero("Numero a agregar: "));
                        Console.WriteLine("Elemento agregado.");
                        Pausa();
                        break;

                    case 2:
                        if (pila.EstaVacia)
                        {
                            Console.WriteLine("La pila esta vacia.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Elemento eliminado: " + pila.Pop());
                        }

                        Pausa();
                        break;

                    case 3:
                        if (pila.EstaVacia)
                            Console.WriteLine("La pila esta vacia.");
                        else
                            Console.WriteLine("Cima: " + pila.Peek());

                        Pausa();
                        break;

                    case 4:
                        pila.Mostrar();
                        Pausa();
                        break;

                    case 5:
                        {
                            Console.Write("Escribe una palabra: ");
                            string palabra = Console.ReadLine() ?? "";

                            Pila<char> caracteres = new Pila<char>();

                            foreach (char c in palabra)
                                caracteres.Push(c);

                            Console.Write("Palabra invertida: ");

                            while (!caracteres.EstaVacia)
                                Console.Write(caracteres.Pop());

                            Console.WriteLine();
                            Pausa();
                            break;
                        }

                    case 6:
                        {
                            Console.Write(
                                "Escribe una expresion con parentesis: ");

                            string expresion = Console.ReadLine() ?? "";

                            Console.WriteLine(
                                ParentesisBalanceados(expresion)
                                ? "Los delimitadores estan balanceados."
                                : "Los delimitadores NO estan balanceados.");

                            Pausa();
                            break;
                        }

                    case 7:
                        regresar = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }
            }
        }

        static bool ParentesisBalanceados(string expresion)
        {
            Pila<char> pila = new Pila<char>();

            foreach (char c in expresion)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    pila.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (pila.EstaVacia)
                        return false;

                    char apertura = pila.Pop();

                    bool coincide =
                        (apertura == '(' && c == ')') ||
                        (apertura == '[' && c == ']') ||
                        (apertura == '{' && c == '}');

                    if (!coincide)
                        return false;
                }
            }

            return pila.EstaVacia;
        }

        // ==========================================
        // MENU DE COLAS
        // ==========================================
        static void MenuColas()
        {
            Cola<string> cola = new Cola<string>();
            bool regresar = false;

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

                int opcion = LeerEntero("Opcion: ");

                switch (opcion)
                {
                    case 1:
                        {
                            Console.Write("Nombre de la persona: ");
                            string nombre = Console.ReadLine() ?? "";

                            if (string.IsNullOrWhiteSpace(nombre))
                            {
                                Console.WriteLine(
                                    "El nombre no puede estar vacio.");
                            }
                            else
                            {
                                cola.Enqueue(nombre.Trim());
                                Console.WriteLine(
                                    $"{nombre.Trim()} se agrego a la fila.");
                            }

                            Pausa();
                            break;
                        }

                    case 2:
                        if (cola.EstaVacia)
                        {
                            Console.WriteLine("No hay personas en la fila.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Atendiendo a: " + cola.Dequeue());
                        }

                        Pausa();
                        break;

                    case 3:
                        if (cola.EstaVacia)
                            Console.WriteLine("La fila esta vacia.");
                        else
                            Console.WriteLine(
                                "Siguiente persona: " + cola.Peek());

                        Pausa();
                        break;

                    case 4:
                        cola.Mostrar();
                        Pausa();
                        break;

                    case 5:
                        SimularAtencion(cola);
                        Pausa();
                        break;

                    case 6:
                        regresar = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }
            }
        }

        static void SimularAtencion(Cola<string> cola)
        {
            if (cola.EstaVacia)
            {
                Console.WriteLine("No hay personas por atender.");
                return;
            }

            Console.WriteLine("Iniciando atencion...");

            while (!cola.EstaVacia)
            {
                string persona = cola.Dequeue();
                Console.WriteLine($"Atendiendo a {persona}...");
            }

            Console.WriteLine("Se atendio a toda la fila.");
        }

        // ==========================================
        // EXPLICACIONES
        // ==========================================
        static void Explicaciones()
        {
            Console.Clear();
            Console.WriteLine("===== CONCEPTOS =====");

            Console.WriteLine(
                "\nRECURSIVIDAD:");
            Console.WriteLine(
                "Una funcion se llama a si misma para resolver");
            Console.WriteLine(
                "un problema mas pequeno. Necesita un caso base.");

            Console.WriteLine(
                "\nPILA (LIFO):");
            Console.WriteLine(
                "El ultimo elemento en entrar es el primero");
            Console.WriteLine(
                "en salir. Ejemplo: una pila de platos.");

            Console.WriteLine(
                "\nCOLA (FIFO):");
            Console.WriteLine(
                "El primer elemento en entrar es el primero");
            Console.WriteLine(
                "en salir. Ejemplo: una fila de personas.");

            Console.WriteLine(
                "\nOPERACIONES:");
            Console.WriteLine(
                "Push/Enqueue: insertar un elemento.");
            Console.WriteLine(
                "Pop/Dequeue: eliminar un elemento.");
            Console.WriteLine(
                "Peek: consultar sin eliminar.");

            Pausa();
        }

        // ==========================================
        // ENTRADA Y CONTROL DE CONSOLA
        // ==========================================
        static int LeerEntero(string mensaje)
        {
            int numero;

            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out numero))
                    return numero;

                Console.WriteLine(
                    "Entrada incorrecta. Escribe un numero entero.");
            }
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresiona ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
