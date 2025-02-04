using BudgetBuddyRestAPI.Data;
using BudgetBuddyRestAPI.Models;
using BudgetBuddyRestAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddyRestAPI.Controllers
{
    public class ExpensesController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public ExpensesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseViewModel viewModel)
        {
            var newExpense = new Expense
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Amount = viewModel.Amount,
            };

            await dbContext.Expenses.AddAsync(newExpense);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var expenses = await dbContext.Expenses.ToListAsync();
            return View(expenses);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Expense viewModel)
        {
            var expense = await dbContext.Expenses
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (expense is not null)
            {
                dbContext.Expenses.Remove(expense); // Use the entity retrieved from the database
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Expenses");
        }




    }
}
