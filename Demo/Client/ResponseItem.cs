namespace BsBlazor;

public class ResponseItem
{
    public required Guid Id { get; init; }
    public required DateTimeOffset CreatedOn { get; init; }

    public static ResponseItem Generate()
    {
        return new ResponseItem
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now
        };
    }
    
    public static ResponseItem Generate(Guid id)
    {
        return new ResponseItem
        {
            Id = id,
            CreatedOn = DateTimeOffset.Now
        };
    }

    public static ResponseItem[] Generate(int count)
    {
        return Enumerable.Range(0, count).Select(_ => Generate()).ToArray();
    }
}