using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using LibraryAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LibraryAPI.Models.Concrete;
using Microsoft.AspNetCore.Http;

namespace LibraryAPI.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{

    public readonly IHttpContextAccessor httpContextAccessor;

    public ApplicationContext(DbContextOptions<ApplicationContext> options,IHttpContextAccessor httpContextAccessor)
    : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<Location>? Locations { get; set; }
    public DbSet<Language>? Languages { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<SubCategory>? SubCategories { get; set; }
    public DbSet<Publisher>? Publishers { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<AuthorRepresentativeBook>? AuthorRepresentativeBook { get; set; }

    public DbSet<Member>? Members { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Donator>? Donators { get; set; }
    public DbSet<Library>? Library { get; set; }

    public DbSet<Favourite>? Favourites { get; set; }
    public DbSet<Transaction>? Transactions { get; set; }
    public DbSet<RepresentativeBook>? RepresentativeBooks { get; set; }
    public DbSet<RepresentativeBookCategorySubCategory>? RepresentativeBookCategorySubCategory { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.RepresentativeBookRating>? RepresentativeBookRating { get; set; }


    public DbSet<LibraryAPI.Models.Concrete.BookLanguage>? BookLanguage { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.Like>? Like { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.DisLike>? DisLike { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.PublisherRepresentativeBook>? PublisherRepresentativeBook { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.LibraryRepresentativeBookStock>? LibraryRepresentativeBookStock { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.PublisherEMail>? PublisherEMail { get; set; }

    public DbSet<LibraryAPI.Models.Concrete.PublisherPhone>? PublisherPhone { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorRepresentativeBook>()
        .HasKey(ab => new { ab.AuthorsId, ab.RepresentativeBooksId });

        modelBuilder.Entity<AuthorRepresentativeBook>()
        .HasOne(ab => ab.Author)
        .WithMany(a => a.AuthorBooks)
        .HasForeignKey(ab => ab.AuthorsId);

        modelBuilder.Entity<AuthorRepresentativeBook>()
        .HasOne(ab => ab.RepresentativeBook)
        .WithMany(b => b.AuthorBooks)
        .HasForeignKey(ab => ab.RepresentativeBooksId);

        modelBuilder.Entity<ApplicationUser>()
        .HasIndex(b => b.PhoneNumber)
        .IsUnique();

        modelBuilder.Entity<ApplicationUser>()
        .HasIndex(b => b.Email)
        .IsUnique();

        modelBuilder.Entity<PublisherEMail>()
        .HasIndex(pem => pem.EMail)
        .IsUnique();

        modelBuilder.Entity<PublisherPhone>()
        .HasIndex(pp => pp.Phone)
        .IsUnique();

        modelBuilder.Entity<RepresentativeBook>()
        .HasIndex(pp => pp.Image)
        .IsUnique();

        modelBuilder.Entity<Category>()
         .HasIndex(c => c.Name)
         .IsUnique();

        modelBuilder.Entity<SubCategory>()
         .HasIndex(c => c.Name)
         .IsUnique();



        modelBuilder.Entity<PublisherRepresentativeBook>()
            .HasIndex(prb => new { prb.PublisherId, prb.RepresentativeBookId })
            .IsUnique();

        modelBuilder.Entity<RepresentativeBookCategorySubCategory>()
            .ToTable("RepresentativeBookCategorySubCategory")
            .HasKey(bc => new { bc.RepresentativeBookId, bc.CategoryId });

        modelBuilder.Entity<RepresentativeBookCategorySubCategory>()
            .ToTable("RepresentativeBookCategorySubCategory")
            .HasOne(bc => bc.RepresentativeBook)
            .WithMany(b => b.RepresentativeBookCategorySubCategories)
            .HasForeignKey(bc => bc.RepresentativeBookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RepresentativeBookCategorySubCategory>()
            .ToTable("RepresentativeBookCategorySubCategory")
            .HasOne(bc => bc.Category)
            .WithMany(b => b.RepresentativeBookCategorySubCategories)
            .HasForeignKey(bc => bc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Favourite>()
        .HasKey(f => new { f.UserId, f.RepresentativeBookId }); // Composite key configuration

        modelBuilder.Entity<Favourite>()
            .HasOne(f => f.User)
            .WithMany() // Assuming one-to-many relationship, configure as needed
            .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<Favourite>()
            .HasOne(f => f.RepresentativeBooks)
            .WithMany() // Assuming one-to-many relationship, configure as needed
            .HasForeignKey(f => f.RepresentativeBookId);

        modelBuilder.Entity<BookLanguage>()
            .HasKey(bl => new { bl.LanguageCode, bl.RepresentativeBookId });

        modelBuilder.Entity<BookLanguage>()
            .HasOne(bl => bl.Language)
            .WithMany(b => b.BookLanguages)
            .HasForeignKey(bl => bl.LanguageCode)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BookLanguage>()
            .HasOne(bl => bl.RepresentativeBook)
            .WithMany(b => b.BookLanguages)
            .HasForeignKey(bl => bl.RepresentativeBookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LibraryRepresentativeBookStock>()
            .ToTable("LibraryRepresentativeBookStock")
            .HasKey(lrbs => new { lrbs.LibraryName, lrbs.RepresentativeBookId });

        modelBuilder.Entity<LibraryRepresentativeBookStock>()
            .ToTable("LibraryRepresentativeBookStock")
            .HasOne(rbs => rbs.Library)
            .WithMany(r => r.LibraryRepresentativeBookStocks)
            .HasForeignKey(rbs => rbs.LibraryName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LibraryRepresentativeBookStock>()
            .ToTable("LibraryRepresentativeBookStock")
            .HasOne(rbs => rbs.RepresentativeBook)
            .WithMany(r => r.LibraryRepresentativeBookStocks)
            .HasForeignKey(rbs => rbs.RepresentativeBookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Like>()
             .HasKey(l => new { l.UserId, l.RepresentativeBookId });

        modelBuilder.Entity<DisLike>()
             .HasKey(dl => new { dl.UserId, dl.RepresentativeBookId });



    }

    



}


