using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cobra.Infrastructure.Data
{
    public class InMemoryDatabaseContext : AppDbContext
    {
        public InMemoryDatabaseContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options, mediator)
        {
        }
    }
}