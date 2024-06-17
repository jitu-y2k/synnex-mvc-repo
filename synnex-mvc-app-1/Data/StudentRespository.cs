using System;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public static class StudentRespository
	{
		public static List<Student> Students { get; set; } = new List<Student>()
		{
			new Student{
				Id =1,
				Name = "Karan",
				Age = 20,
				Address = "Delhi"
			},

            new Student{
                Id =2,
                Name = "Karina",
                Age = 22,
                Address = "Banglore"
            },

            new Student{
                Id =3,
                Name = "Rashmi",
                Age = 21,
                Address = "Kolkata"
            }
        };

        //public static void CreateStudent(Student student)
        //{
        //    Students.Add(student);
        //}


	}
}

