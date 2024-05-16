namespace Unibank.DAL.Entities
{
    public class Branch : TimeStample
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public string Description { get; set; }
        public ICollection<SectionBranch> SectionBranches { get; set; }
    }
}
