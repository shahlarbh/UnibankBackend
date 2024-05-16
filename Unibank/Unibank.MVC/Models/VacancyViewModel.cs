using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class VacancyViewModel
    {
        public List<HRPageLink> PageLinks = new List<HRPageLink>();
        public List<Vacancy> Vacancies = new List<Vacancy>();
    }
}
