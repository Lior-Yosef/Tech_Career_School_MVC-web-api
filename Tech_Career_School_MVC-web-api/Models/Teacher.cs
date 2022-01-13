using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tech_Career_School_MVC_web_api.Models
{
    public class Teacher
    {
        public Teacher(int id, string firstName, string lastName, int slary, DateTime born)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Slary = slary;
            this.Born = born;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Slary { get; set; }
        public DateTime Born { get; set; }

    }
}