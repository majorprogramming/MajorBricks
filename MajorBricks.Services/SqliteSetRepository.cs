using MajorBricks.Core.Models;
using MajorBricks.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MajorBricks.Services;

public class SqliteSetRepository : ISetRepository
{
    private readonly AppDbContext _context;

    public SqliteSetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Set>> GetAllSetsAsync()
    {
        // Include Manufacturer for display
        return await _context.Sets
                             .Include(s => s.Manufacturer)
                             .ToListAsync();
    }

    public async Task AddSetAsync(Set model)
    {
        _context.Sets.Add(model);
        await _context.SaveChangesAsync();
    }
}
