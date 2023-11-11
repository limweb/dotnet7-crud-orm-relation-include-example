using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }
    }
}