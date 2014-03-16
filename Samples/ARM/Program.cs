using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ARMConsoleTest
{
    public class BaseObject
    {
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }

    public class Blog : BaseObject
    {
        [Key]
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post : BaseObject
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("MainDatabase")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Enter a name for Blog:");
                var name = Console.ReadLine();
                var blog = new Blog() { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                Console.WriteLine("All blogs:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
            //SqlConnection connection = null;

            //try
            //{
            //    connection = new SqlConnection("Data Source=SQL-SERVER\\SQLEXPRESS;Initial Catalog=Blogging;Integrated Security=false;User ID=sa;Password=123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            //    connection.Open();
            //    var cmd = new SqlCommand("select * from Blogs", connection);
            //    var reader = cmd.ExecuteReader();
            //    int count = 0;
            //    while (reader.Read())
            //        count++;
            //    Console.WriteLine("Count: {0}",count);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if(connection != null)
            //        connection.Close();
            //}
            //Console.ReadKey();

        }
    }
}
