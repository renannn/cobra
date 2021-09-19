namespace Cobra.Core.Settings
{
    public  class KestelServer
    {
        public bool IsEnabled { get; set; }
        public CertificatesKestrel Certificates { get; set; }
    }
}
