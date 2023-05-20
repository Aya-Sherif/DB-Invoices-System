using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class PMSettingsModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        [BindProperty]
        public string PMUserName { get; set; }
        public DataTable dt { get; set; }
        public PMSettingsModel(DB db)
        {
            this.db = db;
        }
        public void OnGet( )
        {
            PMUserName = HttpContext.Session.GetString("username");
            dt = db.getWorkerInfo(PMUserName);
        }
        public IActionResult OnPost()
        {
            db.UpdateWorkerPassword(W.workerPassword, PMUserName);
            return RedirectToPage("/ProjectManagerMain");


        }




    }
}
