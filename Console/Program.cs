
namespace Console
{
    using System;
    using System.Diagnostics;
    using Domain;
    using FileReader;
    class Program
    {
        static void Main(string[] args)
        {
            writeText("Bienvenido/a");
            writeText("Este programa resuelve el siguiente problema:\n");
            writeText("Sea una matriz cuadrada de dos dimensiones, ");
            writeText("de caracteres (cualquiera), devuelva");
            writeText("la cadena de caracteres adyacentes iguales más larga.\n\n");
            writeText("Presione enter para continuar\n\n");
            Console.ReadLine();

            var textFile = MatrixReader.ReadFile();
            var matrix = new Matrix(textFile);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = matrix.GetLongestSubString();
            stopwatch.Stop();

            Console.WriteLine("Sea la matriz:\n");
            Console.WriteLine(matrix.ToString());

            Console.WriteLine($"El resultado fue la {result.Orientation} {result.LongestValue}");
            Console.WriteLine($"Con un largo de {result.LongestValueLength}");
            Console.WriteLine($"El algoritmo demoró: {stopwatch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Author: Nicolás Videla");
        }

        private static void writeText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
