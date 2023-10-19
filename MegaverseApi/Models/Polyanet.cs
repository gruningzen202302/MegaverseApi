namespace MegaverseApi.Models
{

    public class Polyanet: CoordinatesBase, ICandidate
    {
        private Candidate _candidate;
        public Polyanet()
        {
            _candidate = new Candidate();
            Id = _candidate.Id;
        }   
        public string Id { get; set; }
    }
}
