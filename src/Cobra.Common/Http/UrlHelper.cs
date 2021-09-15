using System;

namespace Cobra.Common.Http
{
    public class UrlHelper : IUrlHelper
    {
        public UrlHelper()
        {
        }

        /// <summary>
        /// Extract local path and query from <paramref name="url" />.
        /// If <paramref name="url" /> is an absolute url, 
        /// <paramref name="localHostName" /> and <paramref name="localPort" /> will be used to check against the host and port in <paramref name="url" /> if any.
        /// </summary>
        /// <param name="url">absolute or relative url</param>
        /// <param name="localHostName"></param>
        /// <param name="localPort"></param>
        /// <returns></returns>
        public virtual string LocalPathAndQuery(string url, string localHostName = null, int? localPort = null)
        {
            bool flag;
            bool flag1;
            Check.NotNull<string>(url, "url");
            Uri uri = this.ParseWithUriBuilder(url) ?? this.ParseWithUri(url);
            if (uri != null && uri.IsWellFormedOriginalString())
            {
                if (uri.IsAbsoluteUri)
                {
                    flag1 = (uri.Scheme == Uri.UriSchemeHttp ? true : uri.Scheme == Uri.UriSchemeHttps);
                    bool flag2 = String.Equals(localHostName, uri.Host, StringComparison.OrdinalIgnoreCase);
                    int? nullable = localPort;
                    int port = uri.Port;
                    if (nullable.GetValueOrDefault() == port & nullable.HasValue)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = (localPort.HasValue ? false : uri.IsDefaultPort);
                    }
                    if (flag1 & flag2 & flag)
                    {
                        return uri.PathAndQuery;
                    }
                }
                else if (!uri.IsAbsoluteUri)
                {
                    return uri.OriginalString;
                }
            }
            return null;
        }

        protected virtual Uri ParseWithUri(string url)
        {
            Uri uri;
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri))
            {
                return uri;
            }
            return null;
        }

        protected virtual Uri ParseWithUriBuilder(string url)
        {
            Uri uri;
            try
            {
                uri = (new UriBuilder(url)).Uri;
            }
            catch (UriFormatException uriFormatException)
            {
                uri = null;
            }
            return uri;
        }
    }
}