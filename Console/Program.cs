
namespace Console
{
    using System;
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
        }

        private static void writeText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
