namespace MegaverseApi.Models
{
    public class Soloon : CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Soloon()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
        public string? Color { get; set; }
    }
}
