namespace Unibank.DAL.Entities
{
    public class SectionBranch : Entity
    {
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
