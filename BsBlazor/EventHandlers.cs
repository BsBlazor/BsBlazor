using Microsoft.AspNetCore.Components;

namespace BsBlazor;
// Dropdown
[EventHandler("onhide.bs.dropdown", typeof(EventArgs))]
[EventHandler("onhidden.bs.dropdown", typeof(EventArgs))]
[EventHandler("onshow.bs.dropdown", typeof(EventArgs))]
[EventHandler("onshown.bs.dropdown", typeof(EventArgs))]
// Modal
[EventHandler("onhide.bs.modal", typeof(EventArgs))]
[EventHandler("onhidden.bs.modal", typeof(EventArgs))]
[EventHandler("onhidePrevented.bs.modal", typeof(EventArgs))]
[EventHandler("onshow.bs.modal", typeof(EventArgs))]
[EventHandler("onshown.bs.modal", typeof(EventArgs))]
// Toast
[EventHandler("onhide.bs.toast", typeof(EventArgs))]
[EventHandler("onhidden.bs.toast", typeof(EventArgs))]
[EventHandler("onshow.bs.toast", typeof(EventArgs))]
[EventHandler("onshown.bs.toast", typeof(EventArgs))]
public static class EventHandlers;