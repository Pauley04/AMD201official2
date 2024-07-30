using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace AMD201official2.Models
{
	public class Url
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Link can not be empty")]
        [Url(ErrorMessage = "Input must be a link")]
        public string OriginalLink { get; set; }

		public string ShortLink { get; set; }


        // We need only 3 type data in our project here
    }
}
