namespace Domain
{
    using System;
    using System.Linq;
    public class Matrix
    {
        private string[,] Values { get; set; }
        public int Size { get; }
        public Matrix(string[] matrix)
        {
            if (matrix is null || matrix.Length == 0) throw new Exception("The matrix cannot be null or empty");

            var width = matrix.Length;
            var height = matrix.First().Length;

            this.Size = (width == height) ? width :
            throw new Exception("Invalid Matrix size, must contain the same width than heigth");

            this.Values = this.parseToCharArray(matrix);
        }
    }
}
