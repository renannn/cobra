using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cobra.Infrastructure.Data
{
    public class SQLiteDbContext : AppDbContext
    {
        public SQLiteDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options, mediator)
        {
        }
    }
}