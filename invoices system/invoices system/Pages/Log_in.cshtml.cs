using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class Log_inModel : PageModel
    {
      
        private readonly DB db;
        [BindProperty]
        public Worker W{ get; set; }
        public DataTable dt { get; set; }
        public Log_inModel( DB db)
        {
            this.db = db;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (db.CheckPassword(W))
            {
                if (db.GetWorkerRoleID(W) == "SE")
                {
                    return RedirectToPage("/SiteEngineerInvoices");
                }
                else if(db.GetWorkerRoleID(W) == "SM")
                {
                    return RedirectToPage("/");
                }
                else if (db.GetWorkerRoleID(W) == "PM")
                {
                    return RedirectToPage("/ProjectManagerMain");
                }
                else if (db.GetWorkerRoleID(W) == "AC")
                {
                    return RedirectToPage("/AccountantMain");
                }
                
                else { return Page(); }
            }
            else { return Page(); }
        }
    }
}
