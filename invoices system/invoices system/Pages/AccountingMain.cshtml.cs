using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountingMainModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        [BindProperty]
        public Project P { get; set; }
        public DataTable dt { get; set; }
        public AccountingMainModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }

       
    }
}
