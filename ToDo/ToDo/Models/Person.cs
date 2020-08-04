using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public enum Level { Admin, User }
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        public string SecondName { get; set; }
        [StringLength(100)]
        public string ThirdName { get; set; }
        [StringLength(20)]
        [Required]
        public string Login { get; set; }
        [StringLength(20)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public Level Level { get; set; }
    }
}
