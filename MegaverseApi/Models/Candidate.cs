namespace MegaverseApi.Models
{
    public class Candidate:ICandidate
    {
        public Candidate()
        {
            Id = "d7e13a9a-1e20-4b35-a594-630ec4bfb9a9";
        }
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
