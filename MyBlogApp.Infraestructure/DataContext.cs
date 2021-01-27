using Microsoft.EntityFrameworkCore;
using MyBlogApp.Core.Entities;

namespace MyBlogApp.Infraestructure
{
    public class DataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(x => x.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.Autor)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AutorId);
                


            modelBuilder.Entity<Post>().Property(x => x.Title).IsRequired().HasColumnType("varchar(200)");
            modelBuilder.Entity<Post>().Property(x => x.Content).IsRequired().HasColumnType("varchar(2000)");

            modelBuilder.Entity<User>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired().HasColumnType("varchar(200)");





        }
    }
}
