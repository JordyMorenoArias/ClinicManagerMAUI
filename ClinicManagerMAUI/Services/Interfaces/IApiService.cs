namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for making API calls.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Sends a DELETE request to the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(string endpoint);

        /// <summary>
        /// Sends a GET request to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="T"/>.</returns>
        Task<T?> GetAsync<T>(string endpoint);

        /// <summary>
        /// Sends a POST request with the specified data to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="TResponse"/>.</returns>
        Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);

        /// <summary>
        /// Sends a PUT request with the specified data to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="TResponse"/>.</returns>
        Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data);
    }
}