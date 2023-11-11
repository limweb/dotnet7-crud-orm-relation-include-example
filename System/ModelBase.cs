using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudapp.Models
{
    public class ModelBase
    {
        /// <summary>
        /// The ID of the model/table.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The date when a record was added to the database
        /// </summary>
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}