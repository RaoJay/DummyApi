using System.ComponentModel.DataAnnotations;


namespace DummyWebApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string pwd { get; set; }
    }
}