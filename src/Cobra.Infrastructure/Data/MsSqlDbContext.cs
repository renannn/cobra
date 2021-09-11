using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cobra.Infrastructure.Data
{
    public class MsSqlDbContext : AppDbContext
    {
        public MsSqlDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options, mediator)
        {
        }
    }
}