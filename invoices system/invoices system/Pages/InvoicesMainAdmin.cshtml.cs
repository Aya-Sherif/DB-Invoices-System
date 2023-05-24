using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class InvoicesMainAdminModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker Wo { get; set; }
        public DataTable dt { get; set; }
        public InvoicesMainAdminModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            dt = db.getS_All_Invoices();
            Wo.userName = HttpContext.Session.GetString("username");
            Wo.workerID = db.get_worker_id(Wo.userName);

            dt = db.getAccountantAllInvoices(Wo.workerID);

        }
   
    }
}
