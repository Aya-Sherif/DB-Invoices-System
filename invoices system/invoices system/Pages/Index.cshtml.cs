using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
using System.Xml.Linq;

namespace invoices_system.Pages

{
    public class IndexModel : PageModel
    {

        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public IndexModel(DB db)
        {
            this.db = db;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            HttpContext.Session.SetString("username", W.userName);
            
            if (db.CheckPassword(W))
            {
                if (db.GetWorkerRoleID(W) == "SE")
                {
                    HttpContext.Session.SetString("username", W.userName);

                    return RedirectToPage("/SiteEngineerInvoices");
                }
                else if (db.GetWorkerRoleID(W) == "SM")
                {
                    HttpContext.Session.SetString("username", W.userName);

                    return RedirectToPage("/");
                }
                else if (db.GetWorkerRoleID(W) == "PM")
                {
                    HttpContext.Session.SetString("username", W.userName);

                    return RedirectToPage("/ProjectManagerMain");
                }
                else if (db.GetWorkerRoleID(W) == "AC")
                {
                    HttpContext.Session.SetString("username", W.userName);
                    return RedirectToPage("/AccountantMain");
                }

                else { return Page(); }

            }
            else { /*return Page();*/
                HttpContext.Session.SetString("username", W.userName);
                return RedirectToPage("/ProjectManagerMain");



            }
        }
    }
}




