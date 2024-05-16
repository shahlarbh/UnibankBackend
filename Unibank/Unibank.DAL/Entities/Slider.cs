using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unibank.DAL.Entities
{
    public class Slider : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? SliderImage { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
