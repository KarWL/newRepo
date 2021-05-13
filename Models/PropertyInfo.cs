using System;

namespace newRepo.Models
{
    public class PropertyInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string OwnerId {get; set;}
    }

}
