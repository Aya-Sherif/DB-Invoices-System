using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class SiteEngineerInvoicesModel : PageModel
    {
        private readonly DB db;
        [BindProperty(SupportsGet = true)]
        public Worker Wo { get; set; }
        public DataTable dt { get; set; }
        public SiteEngineerInvoicesModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            Wo.userName = HttpContext.Session.GetString("username");
            Wo.workerID = db.get_worker_id(Wo.userName);


            dt = db.getAccountantAllInvoices(Wo.workerID);

        }
        public IActionResult OnPostShow()
        {
            return RedirectToAction("/SiteEngineerShowInvoices");

        }
    }
}
