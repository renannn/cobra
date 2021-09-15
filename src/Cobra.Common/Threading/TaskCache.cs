using System.Threading.Tasks;

namespace Cobra.Common.Threading
{
    public static class TaskCache
    {
        public static Task CompletedTask
        {
            get;
        }

        static TaskCache()
        {
            TaskCache.CompletedTask = Task.FromResult<int>(0);
        }
    }
}