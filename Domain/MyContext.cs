using System;
using System.Collections.Generic;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public partial class MyContext : DbContext, IMyContext
{
    private readonly string connectionString;
    public MyContext(string _connectionStr)
    {
        connectionString = _connectionStr;
    }

    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergen> Allergens { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerFormula> CustomerFormulas { get; set; }

    public virtual DbSet<CustomerFormulaTest> CustomerFormulaTests { get; set; }

    public virtual DbSet<FlavorRequirement> FlavorRequirements { get; set; }

    public virtual DbSet<Formula> Formulas { get; set; }

    public virtual DbSet<MicroChemistry> MicroChemistries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergen>(entity =>
        {
            entity.HasKey(e => e.AllergenId).HasName("PK__Allergen__158B939F5AC78690");

            entity.ToTable("Allergen");

            entity.Property(e => e.AllergenName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8BC2A0051");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerNumber, "UQ__Customer__48D47E1EBA0CEFCC").IsUnique();

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CSR)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerRank)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CustomerStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsAllergenRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsHallalRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsKosherRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsMicroAnnual)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsMicroRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsOrganicCertRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.IsOrganicCompRequired)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Salesperson)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SearchKey)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerFormula>(entity =>
        {
            entity.HasKey(e => new { e.CustomerNumber, e.FormulaName }).HasName("PK__Customer__CECC87BF442B085D");

            entity.ToTable("CustomerFormula");

            entity.Property(e => e.FormulaName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.DateLastSold).HasColumnType("date");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CustomerFormulas)
                .HasPrincipalKey(p => p.CustomerNumber)
                .HasForeignKey(d => d.CustomerNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerF__Custo__75A278F5");
        });

        modelBuilder.Entity<CustomerFormulaTest>(entity =>
        {
            entity.HasKey(e => new { e.CustomerNumber, e.FormulaName, e.TestNumber }).HasName("PK__Customer__0E1A6915D51BE8F6");

            entity.ToTable("CustomerFormulaTest");

            entity.Property(e => e.FormulaName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.TestNumber)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CustomerFormulaTests)
                .HasPrincipalKey(p => p.CustomerNumber)
                .HasForeignKey(d => d.CustomerNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerF__Custo__797309D9");
        });

        modelBuilder.Entity<FlavorRequirement>(entity =>
        {
            entity.HasKey(e => e.FlavorRequirementId).HasName("PK__FlavorRe__967D38E01EB74B0D");

            entity.ToTable("FlavorRequirement");

            entity.Property(e => e.FlavorRequirementName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
        });

        modelBuilder.Entity<Formula>(entity =>
        {
            entity.HasKey(e => e.FormulaId).HasName("PK__Formula__227429A53241D120");

            entity.ToTable("Formula");

            entity.HasIndex(e => e.FormulaName, "UQ__Formula__618F9A08AFE3DEB8").IsUnique();

            entity.Property(e => e.FormulaDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormulaName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.SearchKey)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MicroChemistry>(entity =>
        {
            entity.HasKey(e => e.MicroChemistryId).HasName("PK__MicroChe__4F208CA21D96591A");

            entity.ToTable("MicroChemistry");

            entity.HasIndex(e => e.TestNumber, "UQ__MicroChe__D6EEAAC0418829FA").IsUnique();

            entity.Property(e => e.AnalysisName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DayType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('Calendar')");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.ItemNumber)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.MethodReference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("smallmoney");
            entity.Property(e => e.TestName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TestNumber)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TestType)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
