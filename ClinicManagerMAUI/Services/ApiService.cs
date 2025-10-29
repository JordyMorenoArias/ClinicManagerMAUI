using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for making API calls.
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to send requests.</param>
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends a GET request to the specified endpoint and returns the deserialized JSON response wrapped in an <see cref="ApiResponse{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> object containing the result or error details.</returns>
        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<T>
            {
                StatusCode = (int)response.StatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Success = true;
                apiResponse.Data = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = !string.IsNullOrWhiteSpace(content)
                    ? content
                    : $"Request failed with status code {response.StatusCode}.";
            }

            return apiResponse;
        }

        /// <summary>
        /// Sends a POST request with the specified data to the specified endpoint and returns the deserialized JSON response wrapped in an <see cref="ApiResponse{TResponse}"/>.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>An <see cref="ApiResponse{TResponse}"/> object containing the result or error details.</returns>
        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress + endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<TResponse>
            {
                StatusCode = (int)response.StatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Success = true;
                apiResponse.Data = JsonConvert.DeserializeObject<TResponse>(responseContent);
            }
            else
            {
                var json = JObject.Parse(responseContent);
                apiResponse.Success = false;
                apiResponse.ErrorMessage = json["message"]?.ToString() != null
                    ? json["message"]!.ToString()
                    : $"Request failed with status code {response.StatusCode}.";
            }

            return apiResponse;
        }

        /// <summary>
        /// Sends a PUT request with the specified data to the specified endpoint and returns the deserialized JSON response wrapped in an <see cref="ApiResponse{TResponse}"/>.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data to be sent in the body.</typeparam>
        /// <typeparam name="TResponse">The type to which the JSON response will be deserialized.</typeparam>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <param name="data">The data to include in the request body.</param>
        /// <returns>An <see cref="ApiResponse{TResponse}"/> object containing the result or error details.</returns>
        public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<TResponse>
            {
                StatusCode = (int)response.StatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Success = true;
                apiResponse.Data = JsonConvert.DeserializeObject<TResponse>(responseContent);
            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = !string.IsNullOrWhiteSpace(responseContent)
                    ? responseContent
                    : $"Request failed with status code {response.StatusCode}.";
            }

            return apiResponse;
        }

        /// <summary>
        /// Sends a DELETE request to the specified endpoint and returns an <see cref="ApiResponse{T}"/> indicating the result.
        /// </summary>
        /// <param name="endpoint">The relative or absolute URL of the API endpoint.</param>
        /// <returns>indicating success or failure with status details.</returns>
        public async Task<ApiResponse<object>> DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<object>
            {
                StatusCode = (int)response.StatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Success = true;
            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = !string.IsNullOrWhiteSpace(content)
                    ? content
                    : $"Request failed with status code {response.StatusCode}.";
            }

            return apiResponse;
        }
    }
}