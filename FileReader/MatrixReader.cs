namespace FileReader
{
    using System.IO;
    using System.Linq;
    public static class MatrixReader
    {
        public static string[] ReadFile()
        {
            var fileLoc = string.Concat(Directory.GetCurrentDirectory(), "\\Matrix.txt");

            var lines = File.ReadLines(fileLoc);
            return lines.ToArray();
        }
    }
}
