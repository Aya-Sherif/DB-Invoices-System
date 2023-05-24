using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountantCreatInvoiceModel : PageModel
    {

        private readonly DB db;
        [BindProperty(SupportsGet =true)]
        public Worker Wo { get; set; }
        public Statment stat { get; set; }

        public Invoice invoice { get; set; }
        public Project project { get; set; }

        public DataTable pojectdt { get; set; }
        public Weekly_Cost WC { get; set; }
        public AccountantCreatInvoiceModel(DB db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            Wo.userName = HttpContext.Session.GetString("username");
            Wo.workerID = db.get_worker_id(Wo.userName);
            pojectdt = db.getProjectData(Wo.workerID);
        }
        public IActionResult OnPost()
        {
            
            
                db.insertIntoInvoice(stat);
                return RedirectToAction("/InvoiceAfterCreation");
            
            //return RedirectToAction("/");
        }
    }
}
