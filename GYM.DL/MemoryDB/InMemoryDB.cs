using GYM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DL.MemoryDB
{
    public static class InMemoryDB
    {
        public static List<Gyms> GymsData = new List<Gyms>()
        {
            new GYM()
            {
                Id = 1,
                InstructorID = 1,
                ReleaseDate = new DateTime(2005,02,12),
                Title = "Gyms 1"
            },
            new Gyms()
            {
                Id = 2,
                InstructID = 2,
                ReleaseDate = new DateTime(2007,02,12),
                Title = "Gyms 2"
            }
        };
        public static List<Instructor> InstructorData = new List<Instructor>()
        {
            new Instructor()
            {
                Id = 1,
                Name = "Instructor 1",
                BirthDay = DateTime.Now
            },
            new Instructor()
            {
                Id = 2,
                Name = "Instructor 2",
                BirthDay = DateTime.Now
            },
            new Instructor()
            {
                Id = 3,
                Name = "Instructor 3",
                BirthDay = DateTime.Now
            }
        };
    }
}