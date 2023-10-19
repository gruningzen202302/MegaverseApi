namespace MegaverseApi.Models
{
    public class CoordinatesBase:ICandidate
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public string CandidateId => new Candidate().Id;
    }
}