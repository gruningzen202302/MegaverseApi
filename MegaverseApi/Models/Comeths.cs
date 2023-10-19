namespace MegaverseApi.Models
{
    public class Comeths : CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Comeths()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
        public string? Direction { get; set; }
    }
}

