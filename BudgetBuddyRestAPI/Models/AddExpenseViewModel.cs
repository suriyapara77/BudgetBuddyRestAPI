namespace BudgetBuddyRestAPI.Models
{
    public class AddExpenseViewModel
    {
        public string Name { get; set; } = string.Empty;//specific name like if category social events what was it? drinks?, posters?
        public string Category { get; set; } = string.Empty;//social events, competitions, 
        public int Amount { get; set; }//money
    }
}
