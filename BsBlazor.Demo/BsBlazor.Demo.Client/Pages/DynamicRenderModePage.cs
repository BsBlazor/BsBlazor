using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BsBlazor.Demo.Client.Pages;

public class DynamicRenderModePage : ComponentBase
{
    [Parameter]
    public string? Mode { get; set; }
    public IComponentRenderMode? RenderModeFromRoute => Mode switch
    {
        "server" => new InteractiveServerRenderMode(),
        "wasm" => new InteractiveWebAssemblyRenderMode(),
        _ => null
    };
}
