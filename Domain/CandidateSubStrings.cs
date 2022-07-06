namespace Domain
{
    using System.Collections.Generic;
    using System.Linq;
    public class CandidateSubStrings
    {
        //Use a hashset to discard all the duplicate results.
        private HashSet<string> candidateValues { get; set; }
        public string Orientation { get; set; }

        public CandidateSubStrings(string orientation)
        {
            this.candidateValues = new HashSet<string>();
            this.Orientation = orientation;
        }
    }
}
