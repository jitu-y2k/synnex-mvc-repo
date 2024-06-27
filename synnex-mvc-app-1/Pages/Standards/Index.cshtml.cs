using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Pages.Standards
{
	public class IndexModel : PageModel
    {
        public List<Standard> StandardList { get; set; }

        private readonly StandardRespository _standardRepo;

        public IndexModel(StandardRespository standardRepo)
        {
            _standardRepo = standardRepo;
        }
        public void OnGet()
        {
            StandardList = _standardRepo.GetStandards();
        }
    }
}
