using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newRepo.Models
{
    public class User
    {
        [Display(Name = "User Id")]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        public string Name { get; set; }


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string pwd { get; set; }

        public ICollection<PropertyInfo> PropertyInfos { get; set; }
        
        }

    public class PropertyInfo
    {

        [Display(Name = "Assests Id")]
        [DataType(DataType.Text)]
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public User User {get; set;}
     
    }

}
