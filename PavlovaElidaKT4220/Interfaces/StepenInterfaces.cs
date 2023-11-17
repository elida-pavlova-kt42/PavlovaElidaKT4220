using PavlovaElidaKT4220.Database;
using PavlovaElidaKT4220.Filters.PrepodStepenFilters;
using PavlovaElidaKT4220.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace PavlovaElidaKT4220.Interfaces.StepenInterfaces
{
    public interface IStepenService
    {
        public Task<Prepod[]> GetPrepodByStepenAsync(PrepodStepenFilters filter, CancellationToken cancellationToken);
    }

    public class StepenService : IStepenService
    {
        private readonly PrepodDbcontext _dbContext;
        public StepenService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodByStepenAsync(PrepodStepenFilters filter, CancellationToken cancellationToken = default)
        {
            var stepens = _dbContext.Set<Prepod>().Where(w => w.Stepen.StepenName == filter.StepenName).ToArrayAsync(cancellationToken);

            return stepens;
        }
    }
}