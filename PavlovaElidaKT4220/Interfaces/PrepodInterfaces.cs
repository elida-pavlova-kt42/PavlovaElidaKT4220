using PavlovaElidaKT4220.Models;
using PavlovaElidaKT4220.Database;
using PavlovaElidaKT4220.Filters.PrepodFilters;
using Microsoft.EntityFrameworkCore;


namespace PavlovaElidaKT4220.Interfaces

{
    public interface IPrepodService
    {
        public Task<Prepod[]> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken);
    }
    public class PrepodService : IPrepodService
    {
        private readonly PrepodDbcontext _dbContext;
        public PrepodService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Kafedra.KafedraName == filter.KafedraName).ToArrayAsync(cancellationToken);
            return prepod;
        }
    }
}
