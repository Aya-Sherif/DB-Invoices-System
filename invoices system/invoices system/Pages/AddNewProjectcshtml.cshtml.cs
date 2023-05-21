using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AddNewProjectcshtmlModel : PageModel
    {


        private readonly DB db;
        [BindProperty]
        public Project P { get; set; }
        public DataTable dt { get; set; }
        public AddNewProjectcshtmlModel(DB db)
        {
            this.db = db;
        }




        public void OnGet()
        {


        }
        public IActionResult OnPost()
        {
            db.AddNewProject(P);
            return RedirectToPage("/Projects");
        }
    }
}
