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
	public class CreateStandardModel : PageModel
    {
        private readonly StandardRespository _standardRepo;

        [BindProperty]
        public Standard Standard { get; set; }

        public CreateStandardModel(StandardRespository standardRepo)
        {
            _standardRepo = standardRepo;
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _standardRepo.CreateStandard(Standard);
            return RedirectToPage("Index");
        }
    }
}
