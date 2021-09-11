namespace Cobra.Entities.Domains
{
    public class BrandImage : Image
    {
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
