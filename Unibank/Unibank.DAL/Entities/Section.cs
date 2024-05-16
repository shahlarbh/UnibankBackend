namespace Unibank.DAL.Entities
{
    public class Section : TimeStample
    {
        public string Name { get; set; }
        public ICollection<SectionBranch> SectionBranches { get; set; }
    }
}
