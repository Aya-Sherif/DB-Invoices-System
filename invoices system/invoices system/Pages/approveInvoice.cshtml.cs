using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using invoices_system.Models;
namespace invoices_system.Pages
{
    public class approveInvoiceModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public string  InvoiceID { get; set; }
        public approveInvoiceModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(string id)
        {
            InvoiceID = id;
        }
        public IActionResult OnPost()
        {

            db.approveInvoice(InvoiceID);
            return RedirectToPage("/ProjectManagerMain");
        }
    }
}
