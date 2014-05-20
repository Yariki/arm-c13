using System;
using System.Data.Entity;

namespace ARMEnumTest
{
    public enum InvoiceType
    {
        None,
        New,
        InProgress,
        Closed
    }

    public class Invoice
    {
        public int InvoiceID { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public InvoiceType Type { get; set; }
    }

    internal class EnumContext : DbContext
    {
        public EnumContext()
            : base("MainDatabase")
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new EnumContext())
            {
                //var invoice = new Invoice() {Name = "First", Type = InvoiceType.New, Number = "IHSDFUH"};
                //context.Invoices.Add(invoice);
                //context.SaveChanges();
                foreach (var invoice in context.Invoices)
                {
                    Console.WriteLine(invoice.Name);
                }
            }
        }
    }
}