using System;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public class StudentRespository
	{
        private readonly ApplicationDbContext _dbContext;

        //public static List<Student> Students { get; set; } = new List<Student>()
        //{
        //	new Student{
        //		Id =1,
        //		Name = "Karan",
        //		Age = 20,
        //		Address = "Delhi"
        //	},

        //          new Student{
        //              Id =2,
        //              Name = "Karina",
        //              Age = 22,
        //              Address = "Banglore"
        //          },

        //          new Student{
        //              Id =3,
        //              Name = "Rashmi",
        //              Age = 21,
        //              Address = "Kolkata"
        //          }
        //      };

        public StudentRespository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _dbContext.Students.FirstOrDefault(s=> s.Id==id);
        }



        public Student CreateStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return student;
        }

        //public static void CreateStudent(Student student)
        //{
        //    Students.Add(student);
        //}


	}
}

