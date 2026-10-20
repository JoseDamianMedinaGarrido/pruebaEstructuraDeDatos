using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

    namespace SolucionadorEstructuras.Recursividad
    {
        // Reúne algoritmos que resuelven el problema dividiéndolo
        // en llamadas sobre partes más pequeñas.
        public static class Recursividad
        {
            public static BigInteger Factorial(BigInteger n)
            {
                // Los valores negativos no forman parte del factorial.
                if (n < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(n), "El numero debe ser no negativo.");

                // Se multiplica el intervalo completo mediante división
                // recursiva para reducir la profundidad de las operaciones.
                return ProductoRango(1, n);
            }

            private static BigInteger ProductoRango(
                BigInteger inicio, BigInteger fin)
            {
                // Un intervalo vacío aporta el elemento neutro del producto.
                if (inicio > fin)
                    return BigInteger.One;

                // Un intervalo de un solo valor ya está resuelto.
                if (inicio == fin)
                    return inicio;

                BigInteger medio = (inicio + fin) / 2;

                // Se divide el intervalo y se multiplican ambos resultados.
                return ProductoRango(inicio, medio) *
                       ProductoRango(medio + 1, fin);
            }

            public static BigInteger Fibonacci(BigInteger n)
            {
                // La posición de Fibonacci debe ser no negativa.
                if (n < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(n), "El numero debe ser no negativo.");

                // El primer valor del par devuelto es F(n).
                return FibonacciPar(n).Item1;
            }

            private static Tuple<BigInteger, BigInteger> FibonacciPar(
                BigInteger n)
            {
                // El caso base devuelve F(0) y F(1).
                if (n == 0)
                    return Tuple.Create(
                        BigInteger.Zero, BigInteger.One);

                // Se calcula primero el par correspondiente a la mitad.
                var par = FibonacciPar(n / 2);

                BigInteger a = par.Item1;
                BigInteger b = par.Item2;

                BigInteger c = a * (2 * b - a);
                BigInteger d = a * a + b * b;

                // Las fórmulas de duplicación rápida permiten obtener
                // F(n) y F(n+1) con pocas llamadas recursivas.
                if (n % 2 == 0)
                    return Tuple.Create(c, d);

                return Tuple.Create(d, c + d);
            }

            public static BigInteger SumaRecursiva(BigInteger n)
            {
                // Para valores no positivos, la suma se considera cero.
                if (n <= 0)
                    return BigInteger.Zero;

                return SumarRango(1, n);
            }

            private static BigInteger SumarRango(
                BigInteger inicio, BigInteger fin)
            {
                // Un intervalo inválido no aporta ningún valor a la suma.
                if (inicio > fin)
                    return BigInteger.Zero;

                // Un único valor es directamente el resultado del intervalo.
                if (inicio == fin)
                    return inicio;

                BigInteger medio = (inicio + fin) / 2;

                // Se suman los resultados de las dos mitades.
                return SumarRango(inicio, medio) +
                       SumarRango(medio + 1, fin);
            }

            public static BigInteger Potencia(
                BigInteger baseNumero, BigInteger exponente)
            {
                // Este método solo acepta exponentes no negativos.
                if (exponente < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(exponente),
                        "El exponente debe ser no negativo.");

                // Toda base elevada a cero vale uno.
                if (exponente == 0)
                    return BigInteger.One;

                // Se calcula la mitad del exponente y se reutiliza su resultado.
                BigInteger mitad = Potencia(
                    baseNumero, exponente / 2);

                BigInteger resultado = mitad * mitad;

                // Si el exponente es impar, queda un factor de la base.
                if (exponente % 2 != 0)
                    resultado *= baseNumero;

                return resultado;
            }
        }
    }

