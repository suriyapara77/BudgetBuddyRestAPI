namespace BudgetBuddyRestAPI.Models.Entities
{
    public class Income
    {
        public Guid Id { get; set; }//this is a generic id thats going to be given by MSSQL
        public string Name { get; set; } = string.Empty;//specific name like if category sponsor then what sponsor?: ubisoft? etc..
        public string Category { get; set; } = string.Empty;//sponsor,merchandise sale, etc...
        public int Amount { get; set; }//money

    }
}
