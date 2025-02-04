using BudgetBuddyRestAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddyRestAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //making a db set for the income entity:
        public DbSet<Income> Incomes {  get; set; }

        //making a db set for the expense entity:
        public DbSet<Expense> Expenses {  get; set; } 
    }
}
