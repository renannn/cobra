namespace Cobra.Common.Threading
{
    /// <summary>
    /// Base implementation of <see cref="T:Abp.Threading.IRunnable" />.
    /// </summary>
    public abstract class RunnableBase : IRunnable
    {
        private volatile bool _isRunning;

        /// <summary>
        /// A boolean value to control the running.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return this._isRunning;
            }
        }

        protected RunnableBase()
        {
        }

        public virtual void Start()
        {
            this._isRunning = true;
        }

        public virtual void Stop()
        {
            this._isRunning = false;
        }

        public virtual void WaitToStop()
        {
        }
    }
}