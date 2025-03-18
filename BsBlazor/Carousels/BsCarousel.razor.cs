using BsBlazor.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BsBlazor;

public partial class BsCarousel : BsComponentBase
{
    private ElementReference _elementReference;
    private Dictionary<string, BsCarouselItem> _carouselItems = new();
    private IJSObjectReference _jsInstance = default!;
    
    private string CssClass => CssBuilder
        .Default("carousel slide")
        .AddClass("carousel-fade", Fade)
        .Build();
    
    [Inject] public required IJSRuntime Js { get; set; }
    
    [Parameter] public string Id { get; set; } = $"bs-carousel-{Guid.NewGuid().ToString("N")[..10]}";
    
    [Parameter] public bool WithArrows { get; set; } = true;
    [Parameter] public bool WithIndicators { get; set; }
    [Parameter] public bool Ride { get; set; }
    [Parameter] public bool Auto { get; set; }
    [Parameter] public bool Fade { get; set; }
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        
        if((Ride && Auto) || !Ride && Auto) AdditionalAttributes.Add("data-bs-ride", "carousel");
        if(Ride && !Auto) AdditionalAttributes.Add("data-bs-ride", "true");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _jsInstance = await Js.InvokeAsync<IJSObjectReference>("bootstrap.Carousel.getOrCreateInstance", _elementReference);
        }
    }

    public void AddItem(BsCarouselItem item)
    {
        _carouselItems.Add(item.Id, item);
        StateHasChanged();
    }
}