using Microsoft.EntityFrameworkCore;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
    //public class TeacherRespository
    //{
    //	public static List<Teacher> Teachers { get; set; } = new List<Teacher>()
    //       {
    //           new Teacher{
    //               Id =1,
    //               Name = "Ramveer Singh",
    //               Subject = "History"
    //           },

    //           new Teacher{
    //               Id =2,
    //               Name = "Prem Shankar",
    //               Subject ="English"
    //           },

    //           new Teacher{
    //               Id =3,
    //               Name = "Roshni Vohra",
    //               Subject = "Maths"
    //           }
    //       };



    //   }

    public class TeacherRespository
    {
        private readonly ApplicationDbContext _dbContext;

        //public static List<Teacher> Teachers { get; set; } = new List<Teacher>()
        //{
        //	new Teacher{
        //		Id =1,
        //		Name = "Karan",
        //		Age = 20,
        //		Address = "Delhi"
        //	},

        //          new Teacher{
        //              Id =2,
        //              Name = "Karina",
        //              Age = 22,
        //              Address = "Banglore"
        //          },

        //          new Teacher{
        //              Id =3,
        //              Name = "Rashmi",
        //              Age = 21,
        //              Address = "Kolkata"
        //          }
        //      };

        public TeacherRespository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Teacher> GetTeachers()
        {
            //Eager Loading
            //return _dbContext.Teachers.Include("Subject").ToList();
            //LazyLoading
            return _dbContext.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _dbContext.Teachers.FirstOrDefault(s => s.Id == id);            
        }



        public Teacher CreateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();

            return teacher;
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Update(teacher);
            _dbContext.SaveChanges();
        }
        

    }
}

