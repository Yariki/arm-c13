using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;

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

    class EnumContext : DbContext
    {
        public EnumContext()
            :base("MainDatabase")
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
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
