using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountantShowinvoiceModel : PageModel
    {

        private readonly DB db;
        [BindProperty(SupportsGet = true)]
        public Worker Wo { get; set; }
        public Statment stat { get; set; }

        public Invoice invoice { get; set; }
        public Project project { get; set; }

        public DataTable pojectdt { get; set; }
        public DataTable pdt { get; set; }

        public Weekly_Cost WC { get; set; }
        public void OnGet(string id)
        {

            pdt = db.selectallDataOfInvoice(id);

            Wo.userName = HttpContext.Session.GetString("username");
            Wo.workerID = db.get_worker_id(Wo.userName);
            pojectdt = db.getProjectData(Wo.workerID);
        }
    }
}
