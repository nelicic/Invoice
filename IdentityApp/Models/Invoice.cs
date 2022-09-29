namespace IdentityApp.Models
{
    public enum InvoiceStatus
    {
        Submitted,
        Approved,
        Rejected
    }
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public double InvoiceAmount { get; set; }
        public string IvoiceMonth { get; set; }
        public string InvoiceOwner { get; set; }
        public string CreatorId { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}

