namespace Cobra.SharedKernel
{
    public class CacheRequest<TType>
    {
        public string key { get; set; }
        public TType value { get; set; }
    }
}
