
namespace BugTracker.Persistence
{
    public class DbIntilializer
    {
        public static void Initilize(BugTrackerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
