using Microsoft.AspNetCore.Components;

namespace BsBlazor;

[EventHandler("onhide.bs.modal", typeof(EventArgs))]
[EventHandler("onhidden.bs.modal", typeof(EventArgs))]
[EventHandler("onhidePrevented.bs.modal", typeof(EventArgs))]
[EventHandler("onshow.bs.modal", typeof(EventArgs))]
[EventHandler("onshown.bs.modal", typeof(EventArgs))]
[EventHandler("onhide.bs.toast", typeof(EventArgs))]
[EventHandler("onhidden.bs.toast", typeof(EventArgs))]
[EventHandler("onshow.bs.toast", typeof(EventArgs))]
[EventHandler("onshown.bs.toast", typeof(EventArgs))]
public static class EventHandlers;