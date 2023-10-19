namespace MegaverseApi.Models
{

    public class Polyanets: CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Polyanets()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
    }
}
