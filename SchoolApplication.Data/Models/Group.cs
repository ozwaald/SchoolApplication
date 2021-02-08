using System.Collections.Generic;

namespace SchoolApplication.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Students { get; set; }
        public Grade Grade { get; set; }

        public Schedule Schedule { get; set; }
    }
}