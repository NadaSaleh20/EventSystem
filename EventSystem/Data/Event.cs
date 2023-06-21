using Microsoft.AspNetCore.Identity;
using System;

namespace EventSystem.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }  // Foreign key property

        public Category Category { get; set; }  

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public IdentityUser Supervisor { get; set; }





    }
}
