using System.Data.Entity;
using LinksManager.DAL.Entities;

namespace LinksManager.DAL
{
    public class LinksContext : DbContext
    {
        public LinksContext() : base("LinksDb")
        {
            Database.SetInitializer(new LinksDbInitializer());
        }

        public DbSet<Link> Links { get; set; }

        public class LinksDbInitializer : DropCreateDatabaseIfModelChanges<LinksContext>
        {
            protected override void Seed(LinksContext context)
            {
               
                context.Links.Add(
                    new Link
                    {
                        Url = "happy_reading.com",
                        Category = "Books",
                        Description = "Interesting english articles"
                    });

                context.Links.Add(
                    new Link
                    {
                        Url = "youtube.com",
                        Category = "Video",
                        Description = "Funny videos"
                    });

                context.Links.Add(
                    new Link
                    {
                        Url = "facebook.com",
                        Category = "Social networks",
                        Description = "Most friends are here"
                    });

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}