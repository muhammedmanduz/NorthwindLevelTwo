using System.ComponentModel.DataAnnotations;

namespace MvcWebUI3.Models
{
    public class ShippingDetail
    {
      //  [Required(ErrorMessage ="İsim gerekli")]
        public string FirstName { get; set; }
       // [Required]
        public string LastName { get; set; }
       // [Required]
      //  [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       // [Required]
        public string City { get; set; }
       // [Required]
       // [MinLength(20,ErrorMessage ="Minimum 10 karakter olmalıdır!")]
        public string Address { get; set; }
      //  [Required]
      //  [Range(18,65)]
        public int Age { get; set; }
    }
}
