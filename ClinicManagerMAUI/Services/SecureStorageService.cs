using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for securely storing and retrieving authentication tokens.
    /// </summary>
    public class SecureStorageService : ISecureStorageService
    {
        /// <summary>
        /// Saves the authentication token securely.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <param name="token"></param>
        /// <returns>A completed task.</returns>
        public Task SaveAsync(string tokenKey, string token)
        {
            SecureStorage.SetAsync(tokenKey, token);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Retrieves the stored authentication token asynchronously.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <returns>The authentication token if it exists; otherwise, null.</returns>
        public async Task<string?> GetAsync(string tokenKey)
        {
            return await SecureStorage.GetAsync(tokenKey);
        }

        /// <summary>
        /// Removes the stored authentication token.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <returns>A completed task.</returns>
        public Task RemoveAsync(string tokenKey)
        {
            SecureStorage.Remove(tokenKey);
            return Task.CompletedTask;
        }
    }
}