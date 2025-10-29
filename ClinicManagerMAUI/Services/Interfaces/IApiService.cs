using ClinicManagerMAUI.Models.DTOs.Generic;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Defines a contract for making HTTP requests (GET, POST, PUT, DELETE)
    /// and handling JSON-based API responses in a structured manner.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Sends a GET request to the specified endpoint and deserializes the JSON response.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the deserialized data or error details.</returns>
        Task<ApiResponse<T>> GetAsync<T>(string endpoint);

        /// <summary>
        /// Sends a POST request with the specified data to the specified endpoint
        /// and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>An <see cref="ApiResponse{TResponse}"/> containing the result or error details.</returns>
        Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);

        /// <summary>
        /// Sends a PUT request with the specified data to the specified endpoint
        /// and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>An <see cref="ApiResponse{TResponse}"/> containing the result or error details.</returns>
        Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest data);

        /// <summary>
        /// Sends a DELETE request to the specified endpoint and returns an <see cref="ApiResponse{object}"/>
        /// indicating the result of the operation.
        /// </summary>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>An <see cref="ApiResponse{object}"/> indicating success or failure with status details.</returns>
        Task<ApiResponse<object>> DeleteAsync(string endpoint);
    }
}