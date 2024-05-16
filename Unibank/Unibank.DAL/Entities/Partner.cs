using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unibank.DAL.Entities
{
    public class Partner : TimeStample
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public double Percentage { get; set; }
        public string NFC { get; set; }

        [NotMapped]
        public IFormFile? PartnerImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
