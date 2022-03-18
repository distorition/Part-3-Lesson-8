using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class User
    {
        /// <summary>
        /// тут хранится сами поля для пользователя
        /// </summary>
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }//при помощи атрибута [Required] мы указали что эти поля обязательны для заполнения 
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
