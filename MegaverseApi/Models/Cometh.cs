namespace MegaverseApi.Models
{
    public class Cometh : CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Cometh()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
        public string? Direction { get; set; }
    }
}

