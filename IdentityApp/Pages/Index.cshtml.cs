using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public Dictionary<string, int> RevenueSubmitted;
        public Dictionary<string, int> RevenueApproved;
        public Dictionary<string, int> RevenueRejected;
        
        public IndexModel(ILogger<IndexModel> logger, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            IniDict(ref RevenueSubmitted);
            IniDict(ref RevenueApproved);
            IniDict(ref RevenueRejected);

            var invoices = _context.Invoice.ToList();
            foreach (var item in invoices)
            {
                switch (item.Status)
                {
                    case InvoiceStatus.Submitted:
                        RevenueSubmitted[item.IvoiceMonth] = (int)item.InvoiceAmount;
                        break;
                    case InvoiceStatus.Approved:
                        RevenueApproved[item.IvoiceMonth] = (int)item.InvoiceAmount;
                        break;
                    case InvoiceStatus.Rejected:
                        RevenueRejected[item.IvoiceMonth] = (int)item.InvoiceAmount;
                        break;
                    default:
                        break;
                }
            }
        }

        private void IniDict(ref Dictionary<string, int> dict)
        {
            dict = new Dictionary<string, int>()
            {
                {"January", 0 },
                {"February", 0 },
                {"March", 0 },
                {"April", 0 },
                {"May", 0 },
                {"June", 0 },
                {"July", 0 },
                {"August", 0 },
                {"September", 0 },
                {"Octomber", 0 },
                {"November", 0 },
                {"December", 0 },
            };
        }
    }
}