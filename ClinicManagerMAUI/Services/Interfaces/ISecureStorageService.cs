namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service responsible for managing authentication tokens.
    /// </summary>
    public interface ISecureStorageService
    {
        /// <summary>
        /// Retrieves the stored authentication token asynchronously.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <returns>The authentication token if it exists; otherwise, null.</returns>
        Task<string?> GetAsync(string tokenKey);

        /// <summary>
        /// Removes the stored authentication token.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <returns>A completed task.</returns>
        Task RemoveAsync(string tokenKey);

        /// <summary>
        /// Saves the authentication token securely.
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <param name="token"></param>
        /// <returns>A completed task.</returns>
        Task SaveAsync(string tokenKey, string token);
    }
}