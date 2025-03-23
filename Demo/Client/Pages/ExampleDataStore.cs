namespace BsBlazor.Demo.Client.Pages;

public static class ExampleDataStore
{
    private static List<ExampleDataItem> Items { get; set; } = [];
    static ExampleDataStore()
    {
        // Examples from A to Z
        Items.Add(new ExampleDataItem { Id = 1, Name = "Apple" });
        Items.Add(new ExampleDataItem { Id = 2, Name = "Banana" });
        Items.Add(new ExampleDataItem { Id = 3, Name = "Cherry" });
        Items.Add(new ExampleDataItem { Id = 4, Name = "Date" });
        Items.Add(new ExampleDataItem { Id = 5, Name = "Elderberry" });
        Items.Add(new ExampleDataItem { Id = 6, Name = "Fig" });
        Items.Add(new ExampleDataItem { Id = 7, Name = "Grape" });
        Items.Add(new ExampleDataItem { Id = 8, Name = "Honeydew" });
        Items.Add(new ExampleDataItem { Id = 9, Name = "Ice Cream Bean" });
        Items.Add(new ExampleDataItem { Id = 10, Name = "Jackfruit" });
        Items.Add(new ExampleDataItem { Id = 11, Name = "Kiwi" });
        Items.Add(new ExampleDataItem { Id = 12, Name = "Lemon" });
        Items.Add(new ExampleDataItem { Id = 13, Name = "Mango" });
        Items.Add(new ExampleDataItem { Id = 14, Name = "Nectarine" });
        Items.Add(new ExampleDataItem { Id = 15, Name = "Orange" });
        Items.Add(new ExampleDataItem { Id = 16, Name = "Peach" });
        Items.Add(new ExampleDataItem { Id = 17, Name = "Quince" });
        Items.Add(new ExampleDataItem { Id = 18, Name = "Raspberry" });
        Items.Add(new ExampleDataItem { Id = 19, Name = "Strawberry" });
        Items.Add(new ExampleDataItem { Id = 20, Name = "Tangerine" });
        Items.Add(new ExampleDataItem { Id = 21, Name = "Ugli Fruit" });
        Items.Add(new ExampleDataItem { Id = 22, Name = "Vanilla Bean" });
        Items.Add(new ExampleDataItem { Id = 23, Name = "Watermelon" });
        Items.Add(new ExampleDataItem { Id = 24, Name = "Xylocarp" });
        Items.Add(new ExampleDataItem { Id = 25, Name = "Yuzu" });
        Items.Add(new ExampleDataItem { Id = 26, Name = "Zucchini" });
    }
    
    public static async Task<ExampleDataItem[]> SearchItemsAsync(string searchText)
    {
        await Task.Delay(300);
        return Items.Where(x => x.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true).ToArray();
    }

    public static async Task<ExampleDataItem?> GetItemAsync(int id)
    {
        await Task.Delay(300);
        return Items.FirstOrDefault(x => x.Id == id);
    }

    public static List<ExampleDataItem> GetItems()
    {
        return Items;
    }
}