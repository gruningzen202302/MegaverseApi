namespace MegaverseApi.Models
{
    public class Soloons : CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Soloons()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
        public string? Color { get; set; }
    }
}
