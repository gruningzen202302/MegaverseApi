namespace MegaverseApi.Models
{
    public class Candidate:ICandidate
    {
        public readonly string Id = "d7e13a9a-1e20-4b35-a594-630ec4bfb9a9";
        string ICandidate.CandidateId => "d7e13a9a-1e20-4b35-a594-630ec4bfb9a9";
        public string? Name { get; set; }
        public string? Surname { get; set; }

    }
}
