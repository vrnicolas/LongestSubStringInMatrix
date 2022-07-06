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
            var result = new CandidateSubStrings("Vertical");
            for (int i = 0; i < this.Size; i++)
            {
                var rowValue = string.Empty;
                for (int j = 0; j < this.Size; j++)
                {
                    rowValue += Values[j, i];
                }

                result.Add(rowValue);
            }
            return result;
        }

        /// <summary>
        /// This function will return the longest diagonal substring within the matrix.
        /// The way that it does is calculate the longest principals diagonals, and keep the result.  
        /// Then is going to create a mirror of the current matrix and  calculate again with that input. 
        /// This is to calculate the secondary diagonals.
        /// At the last, will return the longest between both previously mentioned diagonals.
        /// </summary>
        /// <returns></returns>
        private CandidateSubStrings getLongestDiagonalValue()
        {
            var diagonalValues = this.getLongestDiagonalFromMatrix(this.Values);
            var mirrorMatrix = this.getMirrorMatrix();
            var mirrorDiagonalValues = this.getLongestDiagonalFromMatrix(mirrorMatrix);
            return diagonalValues.GetLongestComparesTo(mirrorDiagonalValues);
        }

        /// <summary>
        /// this function will calculate all the primary diagonals substrings of a matrix.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private CandidateSubStrings getLongestDiagonalFromMatrix(string[,] inputArray)
        {
            CandidateSubStrings result = new CandidateSubStrings("Diagonal");
            for (int k = 0; k < this.Size * 2; k++)
            {
                var diagonal = string.Empty;
                for (int j = 0; j <= k; j++)
                {
                    int i = k - j;
                    if (i < this.Size && j < this.Size)
                    {
                        diagonal += inputArray[i, j];
                    }
                }
                result.Add(diagonal);
            }
            return result;
        }

        /// <summary>
        /// This function returns the mirror matrix of the current values
        /// </summary>
        /// <returns></returns>
        private string[,] getMirrorMatrix()
        {
            var newArray = new string[this.Size, this.Size];
            for (int rowIndex = 0;
                 rowIndex <= (this.Values.GetUpperBound(0)); rowIndex++)
            {
                for (int colIndex = 0;
                     colIndex <= (this.Values.GetUpperBound(1) / 2); colIndex++)
                {
                    string tempHolder = this.Values[rowIndex, colIndex];
                    newArray[rowIndex, colIndex] =
                      this.Values[rowIndex, this.Values.GetUpperBound(1) - colIndex];
                    newArray[rowIndex, this.Values.GetUpperBound(1) - colIndex] =
                      tempHolder;
                }
            }
            return newArray;
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
