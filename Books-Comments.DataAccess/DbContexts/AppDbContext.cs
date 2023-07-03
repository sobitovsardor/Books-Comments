using Books_Comments.Domain.Entities.Books;
using Books_Comments.Domain.Entities.Comments;
using Books_Comments.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Books_Comments.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; } = default!;

    public virtual DbSet<User> Users { get; } = default!;

    public virtual DbSet<Book> Books { get; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
