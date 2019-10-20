using Microsoft.EntityFrameworkCore;

namespace movies.Models
{
    public class movies_db_Context : DbContext
    {
        public movies_db_Context(DbContextOptions<movies_db_Context> options) :
        base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("movies.Models.User", b =>
            {
                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(40);
                b.Property<string>("UserName")
                    .IsRequired()
                    .HasMaxLength(36);
                b.Property<string>("Password")
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity("movies.Models.Movie", b =>
            {
                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(100);
                b.Property<string>("Year")
                    .IsRequired()
                    .HasMaxLength(15);
                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(15);
                b.Property<int>("Rating")
                    .IsRequired()
                   .HasDefaultValue(0);
            });
            modelBuilder.Entity("movies.Models.Comment", b =>
            {
                b.Property<string>("Description")
                    .IsRequired()
                    .HasMaxLength(250);
                b.Property<int>("Rating")
                    .IsRequired()
                   .HasDefaultValue(5);
            });
        }
    }
}