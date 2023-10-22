using System.ComponentModel.DataAnnotations;

namespace MegaverseApi.Models
{
    public class CoordinatesBase:ICandidate
    {
        public int Id { get; set; }
        [Range(0, 10)]
        public int Row { get; set; }
        [Range(0, 10)]
        public int Column { get; set; }

        public string CandidateId => new Candidate().Id;
    }
}