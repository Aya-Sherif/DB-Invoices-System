using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class ProjectManagerMainModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public string  PMUserName { get; set; }
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public ProjectManagerMainModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            dt=db.getSelectedProjects();
        }
    }
}
