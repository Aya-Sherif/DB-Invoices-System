using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountantIsettingsModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public string PMUserName { get; set; }
        public AccountantIsettingsModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            PMUserName = HttpContext.Session.GetString("username");
            dt = db.getWorkerInfo(PMUserName);
        }
    }
}
