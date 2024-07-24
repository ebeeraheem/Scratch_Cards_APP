using Scratch_Cards_APP.Models;

namespace Scratch_Cards_APP.Services;

public class ScratchCardsService
{
    private readonly HttpClient _httpClient;

    public ScratchCardsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ScratchCard?> GenerateCardAsync()
    {
        var response = await _httpClient.PostAsJsonAsync("api/ScratchCards/generate", new { });
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ScratchCard>();
        }
        return null;
    }

    public async Task<List<ScratchCard>?> GetCardsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/ScratchCards");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ScratchCard>>();
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<ScratchCard?> GetCardByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ScratchCards/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ScratchCard>();
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task PurchaseCardAsync(int id)
    {
        try
        {
            var response = await _httpClient.PostAsync($"api/ScratchCards/purchase/{id}", null);

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request exception: {e.Message}");
        }
    }

    public async Task UseCardAsync(int id)
    {
        try
        {
            var response = await _httpClient.PostAsync($"api/ScratchCards/use/{id}", null);

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request exception: {e.Message}");
        }
    }
}
