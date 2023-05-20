using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountantMainModel : PageModel
    {
        private readonly DB db;



        [BindProperty(SupportsGet = true)]

        public Worker Wo { get; set; }
        public DataTable dt { get; set; }
        public AccountantMainModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            Wo.userName = HttpContext.Session.GetString("username");
            Wo.workerID = db.get_worker_id(Wo.userName);
            dt = db.displyInvoicedata(Wo.workerID);
        }
    }
}
