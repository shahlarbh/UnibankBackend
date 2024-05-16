namespace Unibank.DAL.Entities
{
    public class Footer : TimeStample
    {
        public ICollection<FooterIcon> FooterIcons { get; set; }
        public ICollection<FooterLeftEnd> FooterLeftEnds { get; set; }
        public ICollection<FooterRightEnd> FooterRightEnds { get; set; }
        public ICollection<FooterNavigation> FooterNavigations { get; set; }
        public ICollection<FooterNavigationExtention> FooterNavigationExtentions { get; set; }
    }
}
