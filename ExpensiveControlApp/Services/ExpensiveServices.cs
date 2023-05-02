using ExpensiveControlApp.DTOs;
using ExpensiveControlApp.infra.Database;
using ExpensiveControlApp.Models.Expensives;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExpensiveControlApp.Services
{
    public class ExpensiveServices : IExpensiveServices
    {
        private readonly ExpensiveControlContext _dbContext;
       

        public ExpensiveServices(ExpensiveControlContext Context)
        {
            _dbContext = Context;
        }

        public async Task create(DTOs.CreateExpensiveDTO CreateExpensiveDTO)
        { await _dbContext.Expensives.AddAsync(new Expensive()
        {
            descricao = CreateExpensiveDTO.descricao,
            date = CreateExpensiveDTO.date,
            valor = CreateExpensiveDTO.valor

        });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Expensive>> FindBy (DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new Exception("Data final deve ser maior que data inicial");
            var itens = await _dbContext.Expensives.Where(e => e.date >= startDate && e.date <= endDate).AsNoTracking().ToListAsync();
            return itens;
        }
    }
}
