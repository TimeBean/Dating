using System.Net.Http.Json;
using DatingAPIWrapper.Exceptions;
using DatingAPIWrapper.Options;
using DatingContracts;
using DatingContracts.Dtos;

namespace DatingAPIWrapper;

public class Wrapper
{
    private readonly HttpClient _httpClient;

    public Wrapper(HttpClient http, WrapperOption options)
    {
        _httpClient = http;
        _httpClient.BaseAddress = new Uri(options.BaseUrl);
        _httpClient.Timeout = options.Timeout;
    }

    protected async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw await ApiException.FromResponse(response);

        return await response.Content.ReadFromJsonAsync<T>()
               ?? throw new InvalidOperationException("Empty response");
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body)
    {
        var response = await _httpClient.PostAsJsonAsync(url, body);

        if (!response.IsSuccessStatusCode)
            throw await ApiException.FromResponse(response);

        return await response.Content.ReadFromJsonAsync<TResponse>()
               ?? throw new InvalidOperationException("Empty response");
    }

    protected async Task PutAsync<TRequest>(string url, TRequest body)
    {
        var response = await _httpClient.PutAsJsonAsync(url, body);

        if (!response.IsSuccessStatusCode)
            throw await ApiException.FromResponse(response);
    }

    protected async Task DeleteAsync(string url)
    {
        var response = await _httpClient.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
            throw await ApiException.FromResponse(response);
    }
    
    protected async Task PatchAsync<TRequest>(string url, TRequest body)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(body)
        };

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw await ApiException.FromResponse(response);
    }

    public Task<List<UserDto>> GetUsersAsync()
        => GetAsync<List<UserDto>>("/api/users");

    public Task<UserDto> GetUserAsync(int id)
        => GetAsync<UserDto>($"/api/users/{id}");

    public Task<UserDto> CreateUserAsync(UserDto user)
        => PostAsync<UserDto, UserDto>("/api/users", user);

    public Task UpdateUserAsync(int id, UserDto user)
        => PutAsync($"/api/users/{id}", user);

    public Task DeleteUserAsync(int id)
        => DeleteAsync($"/api/users/{id}");
    
    public Task PatchUserAsync(int id, UpdateUser update)
        => PatchAsync($"/api/users/{id}", update);
}