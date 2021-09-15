namespace Cobra.Common.Threading
{
    /// <summary>
    /// Some extension methods for <see cref="T:Cobra.Common.Threading.IRunnable" />.
    /// </summary>
    public static class RunnableExtensions
    {
        /// <summary>
        /// Calls <see cref="M:Cobra.Common.Threading.IRunnable.Stop" /> and then <see cref="M:Cobra.Common.Threading.IRunnable.WaitToStop" />.
        /// </summary>
        public static void StopAndWaitToStop(this IRunnable runnable)
        {
            runnable.Stop();
            runnable.WaitToStop();
        }
    }
}