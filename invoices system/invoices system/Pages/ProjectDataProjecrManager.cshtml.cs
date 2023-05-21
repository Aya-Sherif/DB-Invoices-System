using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using invoices_system.Models;
using System.Data;
namespace invoices_system.Pages
{
    public class ProjectDataProjecrManagerModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public Worker W { get; set; }
        public DataTable dt { get; set; }
        public DataTable dt2 { get; set; }
        public string proj { get; set; }
        public string dt3 { get; set; }
		public string dt4 { get; set; }
        public string dt5 { get; set; }
        
        public ProjectDataProjecrManagerModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(string id)
        {
           
            dt = db.getSelectedProjectsData(id);
            dt2 = db.getS_Project_current_Invoices(id);
            dt3 = db.getS_Project_AC(id);
            dt4 = db.getS_Project_PM(id);
            dt5= db.getS_Project_SE(id);
        }

    }
}
