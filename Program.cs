using System;

namespace Entregable1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Calculadora de Fracciones");
                Console.WriteLine("2. Generador de Tablas de Multiplicar");
                Console.WriteLine("3. Número Especial");
                Console.WriteLine("4. Adivinanza de Frase Oculta");
                Console.WriteLine("5. Salir");

                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        EjecutarCalculadoraFracciones();
                        break;
                    case 2:
                        GenerarTablasDeMultiplicarConDesafio();
                        break;
                    case 3:
                        EsNumeroEspecial();
                        break;
                    case 4:
                        JuegoAdivinanzaFraseOculta();
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                        break;
                }
            }
        }

        static void EjecutarCalculadoraFracciones()
        {
            Console.Clear();
            Console.WriteLine("Calculadora de Fracciones");
            Console.WriteLine("Ingrese el primer número fraccionario:");
            Fraccion fraccion1 = LeerFraccion();

            Console.WriteLine("Ingrese el segundo número fraccionario:");
            Fraccion fraccion2 = LeerFraccion();

            Console.WriteLine("Seleccione la operación:");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Resultado: " + Fraccion.Sumar(fraccion1, fraccion2));
                    break;
                case 2:
                    Console.WriteLine("Resultado: " + Fraccion.Restar(fraccion1, fraccion2));
                    break;
                case 3:
                    Console.WriteLine("Resultado: " + Fraccion.Multiplicar(fraccion1, fraccion2));
                    break;
                case 4:
                    Console.WriteLine("Resultado: " + Fraccion.Dividir(fraccion1, fraccion2));
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
        }

        static Fraccion LeerFraccion()
        {
            Console.Write("Ingrese el numerador: ");
            int numerador = int.Parse(Console.ReadLine());

            int denominador;
            do
            {
                Console.Write("Ingrese el denominador (debe ser diferente de cero): ");
                denominador = int.Parse(Console.ReadLine());

                if (denominador == 0)
                {
                    Console.WriteLine("El denominador no puede ser cero. Inténtelo de nuevo.");
                }
            } while (denominador == 0);

            return new Fraccion(numerador, denominador);
        }

        static void GenerarTablasDeMultiplicarConDesafio()
        {
            Console.Clear();
            Random random = new Random();
            Console.WriteLine("Generador de Tablas de Multiplicar con Desafío");

            Console.Write("Ingrese el número mínimo del rango: ");
            int minimo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el número máximo del rango: ");
            int maximo = int.Parse(Console.ReadLine());

            if (minimo <= maximo)
            {
                for (int numero = minimo; numero <= maximo; numero++)
                {
                    Console.WriteLine($"Tabla de Multiplicar del {numero}:");
                    int numeroAleatorio = random.Next(1, 11);
                    for (int i = 1; i <= 10; i++)
                    {
                        int resultado = numero * i;
                        if (i == numeroAleatorio)
                        {
                            Console.Write($"{numero} x {numeroAleatorio} = ?  \n");
                        }
                        else
                        {
                            Console.Write($"{numero} x {i} = {resultado}  \n");
                        }
                    }

                    Console.Write("\nIngrese el número que falta en la tabla: ");
                    int respuesta = int.Parse(Console.ReadLine());

                    if (respuesta == numero * numeroAleatorio)
                    {
                        Console.WriteLine("¡Correcto!");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrecto. El número que falta es {numero * numeroAleatorio}.");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("El número mínimo debe ser menor o igual al número máximo.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EsNumeroEspecial()
        {
            Console.Clear();
            Console.WriteLine(" Existen números especiales.\n * Estos son divisibles entre 5.\n * No son divisibles por 2 ni por 3.\n * La suma de sus dígitos es mayor que 10.\n");

            int numero;

            try
            {
                Console.Write("Ingrese el número que desea comprobar si es especial: ");
                numero = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Número no válido.");
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
                return;
            }

            if (numero % 5 == 0)
            {
                if (numero % 2 != 0 && numero % 3 != 0)
                {
                    int sumaDigitos = SumarDigitos(numero);

                    if (sumaDigitos > 10)
                    {
                        Console.WriteLine($"El número {numero} es especial, cumple todos los criterios.");
                    }
                    else
                    {
                        Console.WriteLine($"El número {numero} no es especial, no cumple con la suma de dígitos mayor a 10.");
                    }
                }
                else
                {
                    Console.WriteLine($"El número {numero} no es especial, no cumple con el criterio de no ser divisible por 2 ni por 3.");
                }
            }
            else
            {
                Console.WriteLine($"El número {numero} no es especial, no cumple con el criterio de ser divisible por 5.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static int SumarDigitos(int numero)
        {
            int sumaDigitos = 0;

            while (numero != 0)
            {
                sumaDigitos += numero % 10;
                numero /= 10;
            }

            return sumaDigitos;
        }

        static void JuegoAdivinanzaFraseOculta()
        {
            Console.Clear();
            Console.WriteLine("Adivinanza de Frase Oculta");

            string fraseOriginal = "El gato juega en el jardin";
            string[] palabrasOcultas = { "gato", "en", "jardin" };

            int intentosRestantes = 10;
            string[] palabrasAdivinadas = new string[palabrasOcultas.Length];

            while (intentosRestantes > 0)
            {
                Console.WriteLine("Frase con palabras ocultas:");
                string fraseOculta = OcultarPalabras(fraseOriginal, palabrasAdivinadas);
                Console.WriteLine(fraseOculta);

                Console.WriteLine($"Intentos restantes: {intentosRestantes}");
                Console.Write("Ingrese una palabra: ");
                string palabraIngresada = Console.ReadLine().ToLower();

                bool palabraCorrecta = false;

                for (int i = 0; i < palabrasOcultas.Length; i++)
                {
                    if (palabraIngresada == palabrasOcultas[i] && palabrasAdivinadas[i] == null)
                    {
                        palabrasAdivinadas[i] = palabraIngresada;
                        palabraCorrecta = true;
                        break;
                    }
                }

                if (palabraCorrecta)
                {
                    Console.WriteLine("¡Correcto!");
                }
                else
                {
                    Console.WriteLine("Incorrecto.");
                    intentosRestantes--;
                }

                if (TodasPalabrasAdivinadas(palabrasAdivinadas))
                {
                    Console.WriteLine("¡Felicitaciones! Has adivinado todas las palabras.");
                    Console.WriteLine($"La frase completa es: {fraseOriginal}");
                    break;
                }
            }

            if (intentosRestantes <= 0)
            {
                Console.WriteLine("Has agotado todos los intentos. Has perdido.");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static string OcultarPalabras(string frase, string[] palabrasAdivinadas)
        {
            string[] palabras = frase.Split(' ');
            for (int i = 0; i < palabras.Length; i++)
            {
                if (Array.IndexOf(palabrasAdivinadas, palabras[i].ToLower()) == -1)
                {
                    palabras[i] = "_____";
                }
            }
            palabras[0] = "El";
            palabras[2] = "juega";
            palabras[4] = "el";
            return string.Join(" ", palabras);
        }

        static bool TodasPalabrasAdivinadas(string[] palabrasAdivinadas)
        {
            foreach (string palabra in palabrasAdivinadas)
            {
                if (palabra == null)
                {
                    return false;
                }
            }
            return true;
        }
        
    }

    class Fraccion
    {
        
        public int Numerador { get; }
        public int Denominador { get; }

        public Fraccion(int numerador, int denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public static Fraccion Sumar(Fraccion fraccion1, Fraccion fraccion2)
        {
            int nuevoDenominador = fraccion1.Denominador * fraccion2.Denominador;
            int nuevoNumerador1 = fraccion1.Numerador * fraccion2.Denominador;
            int nuevoNumerador2 = fraccion2.Numerador * fraccion1.Denominador;

            int nuevoNumerador = nuevoNumerador1 + nuevoNumerador2;

            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }

        public static Fraccion Restar(Fraccion fraccion1, Fraccion fraccion2)
        {
            int nuevoDenominador = fraccion1.Denominador * fraccion2.Denominador;
            int nuevoNumerador1 = fraccion1.Numerador * fraccion2.Denominador;
            int nuevoNumerador2 = fraccion2.Numerador * fraccion1.Denominador;

            int nuevoNumerador = nuevoNumerador1 - nuevoNumerador2;

            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }

        public static Fraccion Multiplicar(Fraccion fraccion1, Fraccion fraccion2)
        {
            int nuevoNumerador = fraccion1.Numerador * fraccion2.Numerador;
            int nuevoDenominador = fraccion1.Denominador * fraccion2.Denominador;

            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }

        public static Fraccion Dividir(Fraccion fraccion1, Fraccion fraccion2)
        {
            if (fraccion2.Numerador == 0)
            {
                Console.WriteLine("Error: No se puede dividir por cero.");
                return null;
            }
            else{
                int nuevoNumerador = fraccion1.Numerador * fraccion2.Denominador;
                int nuevoDenominador = fraccion1.Denominador * fraccion2.Numerador;

                return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
            }
        }

        private static int ObtenerMCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static Fraccion Simplificar(Fraccion fraccion)
        {
            int mcd = ObtenerMCD(fraccion.Numerador, fraccion.Denominador);
            return new Fraccion(fraccion.Numerador / mcd, fraccion.Denominador / mcd);
        }

        public override string ToString()
        {
            if (Denominador == 1)
            {
                return Numerador.ToString();
            }
            else
            {
                return Numerador + "/" + Denominador;
            }
        }
    }
}
