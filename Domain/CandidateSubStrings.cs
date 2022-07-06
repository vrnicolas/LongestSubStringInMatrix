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
    }
}
