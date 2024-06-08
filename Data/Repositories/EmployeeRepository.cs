using API.Data.Context;
using API.Data.Repositories.Base;
using API.Data.Repositories.Interfaces;
using API.Models.Entity;

namespace API.Data.Repositories
{
    public sealed class EmployeeRepository(DataContext context) : BaseRepository<Employee>(context), IEmployeeRepository;
}
