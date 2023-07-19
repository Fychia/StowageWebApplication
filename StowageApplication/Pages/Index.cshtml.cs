using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StowageApplication.Data;
using StowageApplication.Models;


namespace StowageApplication.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly FileStowageContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IndexModel(FileStowageContext context)
        {
            _context = context;
        }

        public IEnumerable<FileStowage> FileStowages { get; set; }


        public void OnGet()
        {
            FileStowages = _context.FileStowage.ToList();
        }
    }
}