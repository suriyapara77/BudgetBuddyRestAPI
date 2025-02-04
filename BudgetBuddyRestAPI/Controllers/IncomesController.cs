using BudgetBuddyRestAPI.Data;
using BudgetBuddyRestAPI.Models;
using BudgetBuddyRestAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddyRestAPI.Controllers
{
    public class IncomesController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public IncomesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIncomeViewModel viewModel)
        {
            var newIncome = new Income
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Amount = viewModel.Amount,
            }; 

            await dbContext.Incomes.AddAsync(newIncome);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var incomes = await dbContext.Incomes.ToListAsync();
            return View(incomes);

        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(Income viewModel)
        {
            var income = await dbContext.Incomes
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (income is not null)
            {
                dbContext.Incomes.Remove(income); // Use the entity retrieved from the database
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Incomes");
        }





    }
}
