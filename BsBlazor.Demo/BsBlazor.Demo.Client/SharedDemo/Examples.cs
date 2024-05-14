namespace BsBlazor;
public static class Examples 
{
	public static readonly IReadOnlyDictionary<string, string> Contents = new Dictionary<string, string>(){
		{
			"ButtonBaseExample",
"""
<BsButton>Base button</BsButton>

"""
		},
		{
			"ButtonSizesExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Large">Large button</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Small">Small button</BsButton>
"""
		},
		{
			"ButtonVariantsExample",
"""
<BsButton Variant="BsButtonVariant.Primary">Primary</BsButton>
<BsButton Variant="BsButtonVariant.Secondary">Secondary</BsButton>
<br />
<h4>Outline</h4>
<BsButton Variant="BsButtonVariant.OutlinePrimary">Primary</BsButton>
<BsButton Variant="BsButtonVariant.OutlineSecondary">Secondary</BsButton>

"""
		},
		{
			"ModalFullscreenExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreen">Full screen</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenSm">Full screen below sm</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenMd">Full screen below md</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenLg">Full screen below lg</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenXl">Full screen below xl</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenXxl">Full screen below xxl</BsButton>
<BsModalShorthand Id="exampleModalFullscreen"
                  Fullscreen="BsModalFullscreen.Always"
                  Title="Full screen modal">...</BsModalShorthand>
<BsModalShorthand Id="exampleModalFullscreenSm"
                  Fullscreen="BsModalFullscreen.BelowSmall"
                  Title="Full screen modal below sm">...</BsModalShorthand>
<BsModalShorthand Id="exampleModalFullscreenMd"
                  Fullscreen="BsModalFullscreen.BelowMedium"
                  Title="Full screen modal below md">...</BsModalShorthand>
<BsModalShorthand Id="exampleModalFullscreenLg"
                  Fullscreen="BsModalFullscreen.BelowLarge"
                  Title="Full screen modal below lg">...</BsModalShorthand>
<BsModalShorthand Id="exampleModalFullscreenXl"
                  Fullscreen="BsModalFullscreen.BelowExtraLarge"
                  Title="Full screen modal below xl">...</BsModalShorthand>
<BsModalShorthand Id="exampleModalFullscreenXxl"
                  Fullscreen="BsModalFullscreen.BelowExtraExtraLarge"
                  Title="Full screen modal below xxl">...</BsModalShorthand>
"""
		},
		{
			"ModalInteractiveExample",
"""
<BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.ShowAsync()">Modal.Show()</BsButton>
<BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.ToggleAsync()">Modal.Toggle()</BsButton>
<BsModalShorthand @ref="_modal" Keyboard="false" Backdrop="BsModalBackdrop.Static">
    <BsButton Variant="BsButtonVariant.Secondary" OnClick="() => _modal.HideAsync()">Hide</BsButton>
    <BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.ToggleAsync()">Modal.Toggle()</BsButton>
</BsModalShorthand>
@code {
    private BsModalShorthand _modal = default!;
}

"""
		},
		{
			"ModalLiveDemoExample",
"""
@using System.Text
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModal">Launch demo modal</BsButton>
<BsModal Id="exampleModal"
         aria-labelledby="exampleModalLabel"
         OnShow="@(() => _sb1.AppendLine("Show"))"
         OnShown="@(() => _sb1.AppendLine("Shown"))"
         OnHide="@(() => _sb1.AppendLine("Hide"))"
         OnHidePrevented="@(() => _sb1.AppendLine("HidePrevented"))"
         OnHidden="@(() => _sb1.AppendLine("Hidden"))">
    <BsModalDialog>
        <BsModalContent>
            <BsModalHeader>
                 <BsModalTitle id="exampleModalLabel">Modal title</BsModalTitle>
                 <BsModalCloseButton />
            </BsModalHeader>
            <BsModalBody>
                Woohoo, you're reading this text in a modal!
            </BsModalBody>
            <BsModalFooter>
                <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
                <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
            </BsModalFooter>
        </BsModalContent>
    </BsModalDialog>
</BsModal>
<div class="mt-4">Events detected by Blazor interactivity:</div>
<div style="height: 50px; overflow-y: auto; border: 1px solid black">@_sb1</div>

@code {
    private StringBuilder _sb1 = new();
}

"""
		},
		{
			"ModalOptionalSizesExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#extraLargeModal">Extra large modal</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#largeModal">Large modal</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#smallModal">Small modal</BsButton>
<BsModalShorthand Id="extraLargeModal" Title="Extra large modal" Size="BsModalSize.ExtraLarge">...</BsModalShorthand>
<BsModalShorthand Id="largeModal" Size="BsModalSize.Large" Title="Large modal">...</BsModalShorthand>
<BsModalShorthand Id="smallModal" Size="BsModalSize.Small" Title="Small modal">...</BsModalShorthand>
"""
		},
		{
			"ModalRemoveAnimationExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#noAnimation">No animation</BsButton>
<BsModalShorthand Id="noAnimation" Centered Fade="false">
        No animation
</BsModalShorthand>
"""
		},
		{
			"ModalScrollingLongContentExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#scrollingModal">Launch demo modal</BsButton>
<BsModalShorthand Id="scrollingModal" ShowPrimaryButton PrimaryButtonText="Save changes">
    <p style="min-height: 1500px">This is some placeholder content to show the scrolling behavior for modals. Instead of repeating the text in the modal, we use an inline style to set a minimum height, thereby extending the length of the overall modal and demonstrating the overflow scrolling. When content becomes longer than the height of the viewport, scrolling will move the modal as needed.</p>
</BsModalShorthand>
"""
		},
		{
			"ModalScrollingLongContentScrollableExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#scrollableModal">Launch demo modal</BsButton>
<BsModalShorthand Id="scrollableModal" Scrollable ShowPrimaryButton PrimaryButtonText="Save changes">
    <p style="min-height: 1500px">This is some placeholder content to show the scrolling behavior for modals. Instead of repeating the text in the modal, we use an inline style to set a minimum height, thereby extending the length of the overall modal and demonstrating the overflow scrolling. When content becomes longer than the height of the viewport, scrolling will move the modal as needed.</p>
</BsModalShorthand>
"""
		},
		{
			"ModalServiceDialogExample",
"""
<BsModalDialogShorthand Title="Modal Service with parameters">
    <div>
        Hi, @Name
    </div>
    <div>
        Second Parameter: @SecondParameter
    </div>
    <BsButton Variant="BsButtonVariant.Secondary" OnClick="() => ModalReference.CloseAsync()">Close myself</BsButton>
</BsModalDialogShorthand>
@code{
    [CascadingParameter]
    public required IModalReference ModalReference { get; set; }
    [Parameter]
    public string Name { get; set; } = "";
    [Parameter]
    public string SecondParameter { get; set; } = "";
}
"""
		},
		{
			"ModalServiceExample",
"""
@inject IModalService ModalService
<BsButton OnClick="ShowModalAsync" Variant="BsButtonVariant.Primary">Show Modal</BsButton>
@code {
    private async void ShowModalAsync()
    {
        var modalReference = await ModalService.ShowDialogAsync<ModalServiceDialogExample>(
            parameters: p => p.Add(c => c.Name, "Name Parameter")
                              .Add(c => c.SecondParameter, "X")
        );
        await modalReference.WaitClosedAsync();
        Console.WriteLine($"Modal closed");
    }
}

"""
		},
		{
			"ModalServiceRenderFragmentExample",
"""
@inject IModalService ModalService
<BsButton OnClick="ShowModalAsync" Variant="BsButtonVariant.Primary">Show Modal</BsButton>
@code {
    private async void ShowModalAsync()
    {
        await ModalService.ShowDialogAsync(
            @<BsModalDialogShorthand Title="Render fragment title">
                Render fragment
            </BsModalDialogShorthand>, 
            new ModalOptions { Keyboard = false, Backdrop = BsModalBackdrop.Static });
    }
}
"""
		},
		{
			"ModalServiceRenderFragmentWithReferenceExample",
"""
@inject IModalService ModalService
<BsButton OnClick="ShowModalAsync" Variant="BsButtonVariant.Primary">Show Modal</BsButton>
<div>Last result: @_lastResult</div>
@code {
    private bool? _lastResult;
    private async void ShowModalAsync()
    {
        var modalReference = await ModalService.ShowDialogAsync(modalReference => 
            @<BsModalDialogShorthand ShowPrimaryButton
                                     PrimaryButtonText="Save and close"
                                     OnPrimaryButtonClick="() => modalReference.CloseAsync(true)"
                                     Title="Render fragment + reference title">
                Render fragment with modal reference
            </BsModalDialogShorthand>,
            new ModalOptions { Keyboard = false, Backdrop = BsModalBackdrop.Static }
        );
        _lastResult = await modalReference.WaitClosedAsync<bool>();
        StateHasChanged();
    }
}
"""
		},
		{
			"ModalServiceResultDialogExample",
"""
<BsModalDialogShorthand>
    Hi
    <BsButton OnClick="() => ModalReference.CloseAsync(true)">Close myself</BsButton>
</BsModalDialogShorthand>
@code{
    [CascadingParameter]
    public required IModalReference ModalReference { get; set; }
}
"""
		},
		{
			"ModalServiceResultExample",
"""
@inject IModalService ModalService
<BsButton OnClick="ShowModalAsync" Variant="BsButtonVariant.Primary">Show Modal</BsButton>
@code {
    private async void ShowModalAsync()
    {
        var modalReference = await ModalService.ShowDialogAsync<ModalServiceResultDialogExample>();
        var result = await modalReference.WaitClosedAsync<bool>();
        Console.WriteLine($"Modal closed with result '{result}'.");
    }
}

"""
		},
		{
			"ModalStaticBackdropExample",
"""
@using System.Text
<BsButton Variant="BsButtonVariant.Primary"
          Toggle="BsButtonTogle.Modal"
          Target="#staticBackdrop">Launch static backdrop modal</BsButton>
<BsModalShorthand Id="staticBackdrop"
                  Backdrop="BsModalBackdrop.Static"
                  Keyboard="false"
                  Title="Modal title"
                  OnShow="@(() => _sb2.AppendLine("Show"))"
                  OnShown="@(() => _sb2.AppendLine("Shown"))"
                  OnHide="@(() => _sb2.AppendLine("Hide"))"
                  OnHidePrevented="@(() => _sb2.AppendLine("HidePrevented"))"
                  OnHidden="@(() => _sb2.AppendLine("Hidden"))"
                  ShowPrimaryButton
                  PrimaryButtonText="Understood">I will not close if you click outside me. Don't even try to press escape key.</BsModalShorthand>
<div class="mt-4">Events detected by Blazor interactivity:</div>
<div style="height: 50px; overflow-y: auto; border: 1px solid black">@_sb2</div>
@code {
    private StringBuilder _sb2 = new();
}

"""
		},
		{
			"ModalStaticExample",
"""
<BsModal Class="position-static d-block" Fade="false">
    <BsModalDialog>
        <BsModalContent>
            <BsModalHeader>
                <BsModalTitle>Modal title</BsModalTitle>
                <BsModalCloseButton />
            </BsModalHeader>
            <BsModalBody>
                Modal body text goes here.
            </BsModalBody>
            <BsModalFooter>
                <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
                <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
            </BsModalFooter>
        </BsModalContent>
    </BsModalDialog>
</BsModal>

"""
		},
		{
			"ModalStaticShorthandDialogExample",
"""
<BsModal Class="position-static d-block" Fade="false">
    <BsModalDialogShorthand Title="Shorthand modal dialog title">
        Shortand Modal Dialog
    </BsModalDialogShorthand>
</BsModal>

"""
		},
		{
			"ModalStaticShorthandExample",
"""
<BsModalShorthand Class="position-static d-block" Title="Shortand modal title" Fade="false">
    Shortand Modal
</BsModalShorthand>

"""
		},
		{
			"ModalToggleBetweenModalsExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalToggle">Open first modal</BsButton>
<BsModalShorthand Id="exampleModalToggle"
                  Title="Modal 1"
                  Centered>
    <ChildContent>
        Show a second modal and hide this one with the button below.
    </ChildContent>
    <CustomFooter>
        <BsButton Variant="BsButtonVariant.Primary" Dismiss="BsButtonDismiss.Modal"
                  Target="#exampleModalToggle2"
                  Toggle="BsButtonTogle.Modal">Open second modal</BsButton>
    </CustomFooter>
</BsModalShorthand>
<BsModalShorthand Id="exampleModalToggle2" 
                  Title="Modal 2"
                  Centered>
    <ChildContent>
        Hide this modal and show the first with the button below.
    </ChildContent>
    <CustomFooter>
        <BsButton Variant="BsButtonVariant.Primary" Dismiss="BsButtonDismiss.Modal"
                  Target="#exampleModalToggle"
                  Toggle="BsButtonTogle.Modal">Back to first</BsButton>
    </CustomFooter>
</BsModalShorthand>
"""
		},
		{
			"ModalVerticallyCenteredExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#verticallyCentered">Vertically centered modal</BsButton>
<BsModalShorthand Id="verticallyCentered" 
                  Title="Modal title" 
                  ShowPrimaryButton
                  PrimaryButtonText="Save changes"
                  Centered>
    This is a vertically centered modal.
</BsModalShorthand>
"""
		},
		{
			"ModalVerticallyCenteredScrollableExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#verticallyCenteredScrollable">
    Vertically centered scrollable modal
</BsButton>
<BsModalShorthand Id="verticallyCenteredScrollable"
                  Title="Modal title"
                  Scrollable
                  ShowPrimaryButton
                  PrimaryButtonText="Save changes"
                  Centered>
    <p>This is some placeholder content to show a vertically centered modal. We've added some extra copy here to show how vertically centering the modal works when combined with scrollable modals. We also use some repeated line breaks to quickly extend the height of the content, thereby triggering the scrolling. When content becomes longer than the prefedined max-height of modal, content will be cropped and scrollable within the modal.</p>
    <br><br><br><br><br><br><br><br><br><br>
    <p>Just like that.</p>
</BsModalShorthand>
"""
		},
		{
			"ToastBasicExample",
"""
<BsToast Class="fade show">
    <BsToastHeader>
        <MyIcon />
        <strong class="me-auto">Bootstrap</strong>
        <small>11 mins ago</small>
        <BsToastCloseButton/>
    </BsToastHeader>
    <BsToastBody>
        Hello, world! This is a toast message.
    </BsToastBody>
</BsToast>
"""
		},
		{
			"ToastColorSchemesCodeSampleExample",
"""
<BsToastContainer>
    <BsToast Class="@Bs.Css.TextBgPrimary">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgSecondary">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgSuccess">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgDanger">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgWarning">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgInfo">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgLight">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBgDark">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
</BsToastContainer>
"""
		},
		{
			"ToastColorSchemesExample",
"""
<BsToastContainer Class="@Bs.Css.PositionRelative">
    <BsToast Class="@Bs.Default("fade show").TextBgPrimary" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgSecondary" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgSuccess" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgDanger" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgWarning" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgInfo" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgLight" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBgDark" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
</BsToastContainer>
"""
		},
		{
			"ToastCustomContentAlternativeExample",
"""
<BsToast Class="fade show">
    <BsToastBody>
        Hello, world! This is a toast message.
        <hr/>
        <BsButton Type="BsButtonType.Button" Variant="BsButtonVariant.Primary">Take action</BsButton>
        <BsButton Type="BsButtonType.Button" Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Toast">Close</BsButton>
    </BsToastBody>
</BsToast>
"""
		},
		{
			"ToastCustomContentExample",
"""
<BsToast Class="fade show">
    <BsToastBody>
        <div class="d-flex">
            Hello, world! This is a toast message.
            <BsToastCloseButton Class="me-2 m-auto"/>
        </div>
    </BsToastBody>
</BsToast>
"""
		},
		{
			"ToastLiveExample",
"""
@using System.Text

<BsButton Type="BsButtonType.Button" Variant="BsButtonVariant.Primary" OnClick="() => _toast.ShowAsync()">
    Show live toast
</BsButton>

<BsToastContainer Class="@Bs.Css.PositionFixed.BottomRight">
    <BsToast @ref="_toast"
             OnShow="@(() => _sb1.AppendLine("Show"))"
             OnShown="@(() => _sb1.AppendLine("Shown"))"
             OnHide="@(() => _sb1.AppendLine("Hide"))"
             OnHidden="@(() => _sb1.AppendLine("Hidden"))">
        <BsToastHeader>
            <MyIcon />
            <strong class="me-auto">Bootstrap</strong>
            <small>11 mins ago</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            Hello, world! This is a toast message.
        </BsToastBody>
    </BsToast>
</BsToastContainer>

<div class="mt-4">Events detected by Blazor interactivity:</div>
<div style="height: 50px; overflow-y: auto; border: 1px solid black">@_sb1</div>

@code
{
    private StringBuilder _sb1 = new();
    private BsToast _toast = default!;
}

"""
		},
		{
			"ToastPlacementCodeSampleExample",
"""
<InputSelect @bind-Value="_placement" class="form-select">
    @foreach (var placement in Enum.GetValues(typeof(BsToastPlacement)).Cast<BsToastPlacement>())
    {
        <option value="@placement">@placement</option>
    }
</InputSelect>

<BsToastContainer Placement="_placement">
    <BsToast>
        <BsToastHeader>
            <MyIcon/>
            <strong class="me-auto">Bootstrap</strong>
            <small>11 mins ago</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            Hello, world! This is a toast message.
        </BsToastBody>
    </BsToast>
</BsToastContainer>

@code 
{
    private BsToastPlacement _placement = BsToastPlacement.TopLeft;
}
"""
		},
		{
			"ToastPlacementExample",
"""
<InputSelect @bind-Value="_placement" class="form-select my-3">
    @foreach(var placement in Enum.GetValues(typeof(BsToastPlacement)).Cast<BsToastPlacement>())
    {
        <option value="@placement">@placement</option>
    }
</InputSelect>

<div aria-live="polite" aria-atomic="true" class="bg-secondary position-relative rounded-3 " style="min-height: 400px;">
    <BsToastContainer Class="position-absolute" Position="null" Placement="_placement">
        <BsToast Class="fade show" AutoHide="false">
            <BsToastHeader>
                <MyIcon />
                <strong class="me-auto">Bootstrap</strong>
                <small>11 mins ago</small>
                <BsToastCloseButton/>
            </BsToastHeader>
            <BsToastBody>
                Hello, world! This is a toast message.
            </BsToastBody>
        </BsToast>
    </BsToastContainer>
</div>

@code {
    private BsToastPlacement _placement = BsToastPlacement.TopLeft;
}
"""
		},
		{
			"ToastServiceStandaloneExample",
"""
@inject  IToastService ToastService

<BsButton Variant="BsButtonVariant.Primary" Type="BsButtonType.Button" 
          OnClick="@(() => ToastService.ShowAsync("Hi, I am a toast body"))">
    Show simple standalone Toast
</BsButton>

<BsButton Variant="BsButtonVariant.Primary" Type="BsButtonType.Button" 
          OnClick="@(() => ToastService.ShowAsync("Hi, I am a toast body", "Hi, I am a toast header"))">
    Show standalone Toast with title
</BsButton>

<BsButton Variant="BsButtonVariant.Primary" Type="BsButtonType.Button"
          OnClick="@(() => ToastService.ShowAsync("Hi, I am a toast body", "Hi, I am a toast header", _options))">
    Show standalone Toast with title and options
</BsButton>

<BsButton Variant="BsButtonVariant.Primary" Type="BsButtonType.Button" OnClick="ShowToastAsync">
    Show simple standalone toast + ToastReference
</BsButton>

@code 
{
    private ToastOptions _options = new ()
    {
        Class = Bs.Css.TextBgPrimary,
        Delay = 4000
    };
    
    private async Task ShowToastAsync()
    {
        var options = new ToastOptions
        {
            Color = BsToastColor.Secondary,
            AutoHide = false
        };
        
        var toastRef = await ToastService.ShowAsync("Notification in progress...", options: options);
        
        await toastRef.WaitClosedAsync();

        await ToastService.ShowAsync("Notification completed!");
    }
}
"""
		},
		{
			"ToastStackingCodeSampleExample",
"""
<BsToastContainer Position="BsToastPosition.Fixed" Placement="BsToastPlacement.BottomLeft">
    <BsToast>
        <BsToastHeader>
            <MyIcon />
            <strong class="me-auto">Bootstrap</strong>
            <small>just now</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            See? Just like this
        </BsToastBody>
    </BsToast>
    
    <BsToast>
        <BsToastHeader>
            <MyIcon />
            <strong class="me-auto">Bootstrap</strong>
            <small>2 seconds ago</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            Heads up, toasts will stack automatically
        </BsToastBody>
    </BsToast>
</BsToastContainer>
"""
		},
		{
			"ToastStackingExample",
"""
<BsToastContainer Placement="BsToastPlacement.BottomLeft" Position="BsToastPosition.Relative">
    <BsToast Class="fase show" AutoHide="false">
        <BsToastHeader>
            <MyIcon />
            <strong class="me-auto">Bootstrap</strong>
            <small>just now</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            See? Just like this
        </BsToastBody>
    </BsToast>
    
    <BsToast Class="fase show" AutoHide="false">
        <BsToastHeader>
            <MyIcon />
            <strong class="me-auto">Bootstrap</strong>
            <small>2 seconds ago</small>
            <BsToastCloseButton/>
        </BsToastHeader>
        <BsToastBody>
            Heads up, toasts will stack automatically
        </BsToastBody>
    </BsToast>
</BsToastContainer>
"""
		},
	};
}