using System;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public class SubjectRespository
	{
        private readonly ApplicationDbContext _dbContext;

        //public static List<Subject> Subjects { get; set; } = new List<Subject>()
        //{
        //	new Subject{
        //		Id =1,
        //		Name = "Karan",
        //		Age = 20,
        //		Address = "Delhi"
        //	},

        //          new Subject{
        //              Id =2,
        //              Name = "Karina",
        //              Age = 22,
        //              Address = "Banglore"
        //          },

        //          new Subject{
        //              Id =3,
        //              Name = "Rashmi",
        //              Age = 21,
        //              Address = "Kolkata"
        //          }
        //      };

        public SubjectRespository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
        }

        public List<Subject> GetSubjects()
        {
            return _dbContext.Subjects.ToList();
        }

        public Subject GetSubject(int id)
        {
            return _dbContext.Subjects.FirstOrDefault(s=> s.Id==id);
        }



        public Subject CreateSubject(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();

            return subject;
        }

        //public static void CreateSubject(Subject subject)
        //{
        //    Subjects.Add(subject);
        //}


	}
}

