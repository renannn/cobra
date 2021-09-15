using System;
using System.Globalization;
using System.Threading;

namespace Cobra.Common.Threading
{
    /// <summary>
    /// This class is copied from here:
    /// http://www.zpqrtbnk.net/posts/appdomains-threads-cultureinfos-and-paracetamol
    /// It's a workaround for application startup problem.
    /// </summary>
    public static class ThreadCultureSanitizer
    {
        public static void Sanitize()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            while (!currentCulture.Equals(CultureInfo.InvariantCulture))
            {
                currentCulture = currentCulture.Parent;
            }
            if (currentCulture == CultureInfo.InvariantCulture)
            {
                return;
            }
            Thread currentThread = Thread.CurrentThread;
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(currentThread.CurrentCulture.Name);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(currentThread.CurrentUICulture.Name);
        }
    }
}