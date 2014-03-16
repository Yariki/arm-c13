using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ARMManyTest
{

    class Address
    {
        public int AddressID { get; set; }
        public string  AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public ICollection<Person> Persons { get; set; }

        public Address()
        {
            Persons = new HashSet<Person>();
        }

    }

    class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public Person()
        {
            Addresses = new HashSet<Address>();
        }
    }

    class ManyContext : DbContext
    {
        public ManyContext() :
            base("MainDatabase")
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Persons)
                .WithMany(p => p.Addresses)
                .Map(m =>
                {
                    m.MapLeftKey("AddressID");
                    m.MapRightKey("PersonID");
                    m.ToTable("PersonAddress");
                });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ManyContext())
            {
                //db.Persons.Add(new Person() {FirstName = "I", MiddleName = "Alex", LastName = "Lisovsky", Age = 30});
                //db.Persons.Add(new Person() { FirstName = "I", MiddleName = "Alex", LastName = "Lisovskaya", Age = 26 });
                
                //db.Addresses.Add(new Address() {AddressLine1 = "asdkfjkdf", AddressLine2 = "sdfdsfg", City = "asd"});
                //db.Addresses.Add(new Address() { AddressLine1 = ";dthkdfkhgk", AddressLine2 = "dkrjgkrdj", City = "asd" });
                //db.Addresses.Add(new Address() { AddressLine1 = "toyjdkfng", AddressLine2 = "dlrjgoj", City = "asd" });
                
                foreach (var person in db.Persons)
                {
                    Console.WriteLine("{0} {1}",person.PersonID,person.LastName);
                }

                foreach (var address in db.Addresses)
                {
                    Console.WriteLine("{0} {1}", address.AddressID,address.AddressLine1);
                }
                
                var per = db.Persons.Where(p => p.PersonID == 1).FirstOrDefault();
                if (per != null)
                {
                    foreach (var address in db.Addresses)
                    {
                        per.Addresses.Add(address);
                    }
                }

                db.SaveChanges();
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
