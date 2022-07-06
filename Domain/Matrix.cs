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

        /// <summary>
        /// This method will calculate the longest substring in 
        /// the matrix. To accomplish that this code will get the 
        /// longest horizontal, vertical and diagonal substrings
        /// to be compared at the very last and return the longest one.
        /// </summary>
        /// <returns></returns>
        public CandidateSubStrings GetLongestSubString()
        {
            var longestsHorizontalResult = this.getLongestHorizontalValue();
            var longestsVerticalResult = this.getLongestVerticalValue();
            var longestsDiagonalResults = this.getLongestDiagonalValue();

            var longestHorizontalOrVerticalResult = longestsHorizontalResult.GetLongestComparesTo(longestsVerticalResult);
            var longestResult = longestHorizontalOrVerticalResult.GetLongestComparesTo(longestsDiagonalResults);
            return longestResult;
        }

        private CandidateSubStrings getLongestHorizontalValue()
        {
            var result = new CandidateSubStrings("Horizontal");
            for (int i = 0; i < this.Size; i++)
            {
                var rowValue = string.Empty;
                for (int j = 0; j < this.Size; j++)
                {
                    rowValue += Values[i, j];
                }

                result.Add(rowValue);
            }
            return result;
        }

        private CandidateSubStrings getLongestVerticalValue()
        {
            throw new NotImplementedException();
        }

        private CandidateSubStrings getLongestDiagonalValue()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    result += Values[i, j];
                }
                result += "\n";
            }
            return result;
        }

        /// <summary>
        /// This function convert a string[] to a string[,]
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private string[,] parseToCharArray(string[] matrix)
        {
            var result = new string[this.Size, this.Size];
            for (var i = 0; i < matrix.Length; i++)
            {
                var value = matrix[i];
                for (int j = 0; j < value.Length; j++)
                {
                    var pivot = value[j];
                    result[i, j] = pivot.ToString();
                }
            }
            return result;
        }
    }
}
