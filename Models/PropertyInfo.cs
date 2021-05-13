using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace newRepo.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string pwd { get; set; }
        
        }

    public class PropertyInfo
    {
        public Guid Id { get; set; }     
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public User User {get; set;}
     
    }

}
