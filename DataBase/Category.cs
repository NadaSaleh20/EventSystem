using System.Collections.Generic;

namespace DataBase
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }  
    }
}
