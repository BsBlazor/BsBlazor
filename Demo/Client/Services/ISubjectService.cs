using System.Net.Http.Json;

namespace BsBlazor.Services;

// Criado apenas para facilitar criação de demos

public interface ISubjectService
{
    Task<ResponseItem[]> ListAsync();
    Task<ResponseItem> GetAsync(Guid id);
    Task ProcessAsync(bool throwErrorAfterProcess = false);
}

public class SubjectServiceClient(HttpClient client) : ISubjectService
{
    public async Task<ResponseItem[]> ListAsync()
    {
        return await client.GetFromJsonAsync<ResponseItem[]>("api/subjects") ?? [];
    }

    public async Task<ResponseItem> GetAsync(Guid id)
    {
        return await client.GetFromJsonAsync<ResponseItem>($"api/subjects/{id}") ?? throw new Exception("Response not found");
    }

    public async Task ProcessAsync(bool throwErrorAfterProcess = false)
    {
        var message = await client.PostAsync($"api/subjects/process/{throwErrorAfterProcess}", null);
        message.EnsureSuccessStatusCode();
    }
}

public class SubjectServiceServer : ISubjectService
{
    private static async Task FakeProcessAsync()
    {
        var timeDelay = Random.Shared.Next(500, 1500);
        await Task.Delay(timeDelay);
    }
    
    public async Task<ResponseItem[]> ListAsync()
    {
        await FakeProcessAsync();
        return ResponseItem.Generate(5);
    }

    public async Task<ResponseItem> GetAsync(Guid id)
    {
        await FakeProcessAsync();
        return ResponseItem.Generate(id);
    }

    public async Task ProcessAsync(bool throwErrorAfterProcess = false)
    {
        await FakeProcessAsync();
        if (throwErrorAfterProcess)
        {
            throw new Exception("Subject not found in the database");
        }
    }
}