using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class DriverRepository : GenericRepo<Driver>, IDriver
{
    private readonly DbFirstContext _context;
    public DriverRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers
/*             .Include(p => p.tea)
 */            .ToListAsync();
    }

    public override async Task<Driver> GetByIdAsync(int id)
    {
        return await _context.Drivers
/*             .Include(p => p.Drivers)
 */            .FirstOrDefaultAsync(p => p.Id == id);
    }
}