using ClinicManagerMAUI.Services.Interfaces;
using System.Text.Json;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for making API calls.
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends a GET request to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="T"/>.</returns>
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        /// <summary>
        /// Sends a POST request with the specified data to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="TResponse"/>.</returns>
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            endpoint = _httpClient.BaseAddress != null ? _httpClient.BaseAddress + endpoint : endpoint;
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent);
        }

        /// <summary>
        /// Sends a PUT request with the specified data to the specified endpoint and deserializes the JSON response to the specified type.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response of type <typeparamref name="TResponse"/>.</returns>
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent);
        }

        /// <summary>
        /// Sends a DELETE request to the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
        }
    }
}