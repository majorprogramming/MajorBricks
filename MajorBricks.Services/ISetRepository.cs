using System.Collections.Generic;
using System.Threading.Tasks;
using MajorBricks.Core.Models;

namespace MajorBricks.Services;

public interface ISetRepository
{
    Task<List<Set>> GetAllSetsAsync();
    Task AddSetAsync(Set model);
}
