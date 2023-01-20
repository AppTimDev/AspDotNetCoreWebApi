using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreWebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";

        public int Age { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class AddUserRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";

        public int Age { get; set; }
    }
    public class UpdateUserRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";

        public int Age { get; set; }
    }
}
