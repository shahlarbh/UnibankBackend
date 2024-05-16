namespace Unibank.DAL.Entities
{
    public class Vacancy : TimeStample
    {
        public string VacancyTitle { get; set; }
        public string Deadline { get; set; }
    }
}
