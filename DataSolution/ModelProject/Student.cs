using System;
using System.ComponentModel.DataAnnotations;

namespace MultiSolutionEfCoreMigrations.ModelProject
{
    
    public class Student
    {

        public Guid StudentId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

    }

}
