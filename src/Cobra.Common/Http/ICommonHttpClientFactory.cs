using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Cobra.Common
{
    /// <summary>
    /// Reusing a single HttpClient instance across a multi-threaded application
    /// </summary>
    public interface ICommonHttpClientFactory : IDisposable
    {
        /// <summary>
        /// Reusing a single HttpClient instance across a multi-threaded application
        /// </summary>
        HttpClient GetOrCreate(
            Uri baseAddress,
            IDictionary<string, string>? defaultRequestHeaders = null,
            TimeSpan? timeout = null,
            long? maxResponseContentBufferSize = null,
            HttpMessageHandler? handler = null);
    }
}