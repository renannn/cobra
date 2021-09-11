using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Cobra.Common
{
    /// <summary>
    /// Upload File Service
    /// </summary>
    public interface IUploadFileService
    {
        /// <summary>
        /// Saves the posted IFormFile to the specified directory asynchronously.
        /// </summary>
        /// <param name="formFile">The posted file.</param>
        /// <param name="destinationDirectoryName">A directory name in the wwwroot directory.</param>
        /// <param name="allowOverwrite">Creates a unique file name if the file already exists.</param>
        /// <returns></returns>
        Task<(bool IsSaved, string SavedFilePath)> SavePostedFileAsync(IFormFile formFile, string destinationDirectoryName, bool allowOverwrite);

        /// <summary>
        /// Saves the posted IFormFile to a byte array.
        /// </summary>
        /// <param name="formFile">The posted file.</param>
        Task<byte[]?> GetPostedFileDataAsync(IFormFile formFile);
    }
}