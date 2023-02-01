using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserWithPasswordDTO
    {
        public int Id { get; set; }

        [EmailAddress]

        public string Name { get; set; } = null!;
        [StringLength(12, ErrorMessage = "Password length can't be more than 8")]

        public string Password { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
    }
}
