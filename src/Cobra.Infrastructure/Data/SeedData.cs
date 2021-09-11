namespace Cobra.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext dbContext)
        {

            dbContext.SaveChanges();
        }
    }
}
