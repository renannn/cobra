
namespace Cobra.SharedKernel.Interfaces
{
    public interface ICache<TType>
    {
        TType? GetCache(string key);

        void SetCache(CacheRequest<TType> data);
    }
}
