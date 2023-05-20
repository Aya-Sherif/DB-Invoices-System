using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class AccountantPastInvoiceModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public AccountantPastInvoiceModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(string id)
        {
            dt = db.getAccountantAllInvoices("20211489");
           
        }

    }
}
