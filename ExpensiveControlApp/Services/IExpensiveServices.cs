using ExpensiveControlApp.Models.Expensives;

namespace ExpensiveControlApp.Services
{
    public interface IExpensiveServices
    {

        Task create(DTOs.CreateExpensiveDTO CreateExpensiveDTO);
        Task<List<Expensive>> FindBy(DateTime startDate, DateTime endDate);
    }
}
