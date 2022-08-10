
namespace BugTracker.Persistence
{
    public class DbIntilializer
    {
        public static void Initilize(BugsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
