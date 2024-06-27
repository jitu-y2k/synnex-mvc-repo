using System;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public class StandardRespository
	{
        private readonly ApplicationDbContext _dbContext;

        //public static List<Standard> Standards { get; set; } = new List<Standard>()
        //{
        //	new Standard{
        //		Id =1,
        //		Name = "Karan",
        //		Age = 20,
        //		Address = "Delhi"
        //	},

        //          new Standard{
        //              Id =2,
        //              Name = "Karina",
        //              Age = 22,
        //              Address = "Banglore"
        //          },

        //          new Standard{
        //              Id =3,
        //              Name = "Rashmi",
        //              Age = 21,
        //              Address = "Kolkata"
        //          }
        //      };

        public StandardRespository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
        }

        public List<Standard> GetStandards()
        {
            return _dbContext.Standards.ToList();
        }

        public Standard GetStandard(int id)
        {
            return _dbContext.Standards.FirstOrDefault(s=> s.Id==id);
        }



        public Standard CreateStandard(Standard standard)
        {
            _dbContext.Standards.Add(standard);
            _dbContext.SaveChanges();

            return standard;
        }

        //public static void CreateStandard(Standard standard)
        //{
        //    Standards.Add(standard);
        //}


	}
}

