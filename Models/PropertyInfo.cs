using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newRepo.Models
{    
    public class PropertyInfo
    {

        [Display(Name = "Assest Id")]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }     
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Guid UserId {get; set;}
        public Users User {get; set;}
     
    }

}
