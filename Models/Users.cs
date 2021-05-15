using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newRepo.Models
{
    public class Users
    {
        [Display(Name = "User Id")]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }
        public string Name { get; set; }


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<PropertyInfo> PropertyInfos { get; set; }
        
        }   

}
