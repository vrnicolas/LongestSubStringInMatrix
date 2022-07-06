namespace Domain
{
    using System.Collections.Generic;
    using System.Linq;
    public class CandidateSubStrings
    {
        //Use a hashset to discard all the duplicate results.
        private HashSet<string> candidateValues { get; set; }
        public string Orientation { get; set; }
        public string LongestValue { get { return this.candidateValues.OrderByDescending(x => x.Length).First(); } }
        public int LongestValueLength { get { return this.LongestValue.Length; } }

        public CandidateSubStrings(string orientation)
        {
            this.candidateValues = new HashSet<string>();
            this.Orientation = orientation;
        }

        /// <summary>
        /// This method receives an string, 
        /// then get all the substrings 
        /// and for each of those will evaluate if that substring has all the same characters.
        /// If that substring complies with that will be added to the hashset of candidateValues.
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
            var allSubStrings = GetAllSubStrings(str);
            foreach (var subString in allSubStrings)
            {
                if (IsValidSubString(subString))
                    this.candidateValues.Add(subString);
            }
        }

        /// <summary>
        /// This function retuns all the substrings of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private IEnumerable<string> GetAllSubStrings(string str)
        {
            return (from i in Enumerable.Range(0, str.Length)
                    from j in Enumerable.Range(0, str.Length - i + 1)
                    where j >= 1
                    select str.Substring(i, j)).Distinct();
        }

        /// <summary>
        /// This function will validate if a "string" is valid.
        /// The definition of valid in this context is when all the characters are exactly the same.
        /// If at least one character in the string is different, will return False. Otherwise will return true.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsValidSubString(string str)
        {
            return (str.Distinct().Count() == 1);
        }
    }
    public static class SubStringExtensions
    {
        /// <summary>
        /// Extension method that compares two SubString object and returns the one with the longest value
        /// </summary>
        /// <param name="subString"></param>
        /// <param name="anotherSubString"></param>
        /// <returns></returns>
        public static CandidateSubStrings GetLongestComparesTo(this CandidateSubStrings subString, CandidateSubStrings anotherSubString)
        {
            return (subString.LongestValueLength > anotherSubString.LongestValueLength) ? subString : anotherSubString;
        }
    }
}
