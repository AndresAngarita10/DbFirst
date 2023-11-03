
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly DbFirstContext _context;
    private DriverRepository _Driver;
    private TeamRepository _Team;
    public UnitOfWork(DbFirstContext context)
    {
        _context = context;
    }
    public IDriver Drivers 
    {
        get{
            if(_Driver== null)
            {
                _Driver= new DriverRepository(_context);
            }
            return _Driver;
        }
    }

    public ITeam Teams 
    {
        get{
            if(_Team== null)
            {
                _Team= new TeamRepository(_context);
            }
            return _Team;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
