using BsBlazor.Helpers;
using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public partial class BsCarouselItem : BsComponentBase
{
    private string CssClass => InternalCssBuilder
        .Default("carousel-item")
        .AddClass("active", Active)
        .AddClass(Class)
        .Build();

    [Parameter] public string Id { get; set; } = $"bs-carousel-item-{Guid.NewGuid().ToString("N")[..10]}";
    [CascadingParameter] public required BsCarousel Parent { get; set; }
    [Parameter, EditorRequired] public required RenderFragment ChildContent { get; set; }
    [Parameter] public bool Active { get; set; }
    [Parameter] public int Interval { get; set; }
    
    protected override void OnInitialized()
    {
        base.OnInitialized();
        if(Interval > 0) AdditionalAttributes.Add("data-bs-interval", Interval.ToString());
        Parent.AddItem(this);
    }
}