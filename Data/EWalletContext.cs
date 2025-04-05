using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;

public class EWalletContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public EWalletContext(DbContextOptions<EWalletContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleID)
            .HasConstraintName("FK_User_Role");

        modelBuilder.Entity<BankAccount>()
            .HasOne(ba => ba.User)
            .WithMany()
            .HasForeignKey(ba => ba.UserID);

        modelBuilder.Entity<BankAccount>()
            .HasOne(ba => ba.Bank)
            .WithMany()
            .HasForeignKey(ba => ba.BankID);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderUserID);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Recipient)
            .WithMany()
            .HasForeignKey(t => t.RecipientUserID);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.BankAccount)
            .WithMany()
            .HasForeignKey(t => t.BankAccountID);
    }
}
