namespace BsBlazor;
public static class Examples 
{
	public static readonly IReadOnlyDictionary<string, string> Contents = new Dictionary<string, string>(){
		{
			"ModalFullscreenExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreen">Full screen</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenSm">Full screen below sm</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenMd">Full screen below md</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenLg">Full screen below lg</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenXl">Full screen below xl</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalFullscreenXxl">Full screen below xxl</BsButton>
<BsModal Id="exampleModalFullscreen" Fullscreen="BsModalFullscreen.Always">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalFullscreenSm" Fullscreen="BsModalFullscreen.BelowSmall">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalFullscreenMd" Fullscreen="BsModalFullscreen.BelowMedium">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalFullscreenLg" Fullscreen="BsModalFullscreen.BelowLarge">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalFullscreenXl" Fullscreen="BsModalFullscreen.BelowExtraLarge">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalFullscreenXxl" Fullscreen="BsModalFullscreen.BelowExtraExtraLarge">
    <ChildContent>...</ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
    </ModalFooter>
</BsModal>
"""
		},
		{
			"ModalInteractiveExample",
"""
<BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.Show()">Modal.Show()</BsButton>
<BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.Toggle()">Modal.Toggle()</BsButton>
<BsModal @ref="_modal" Keyboard="false" Backdrop="BsModalBackdrop.Static">
    <BsButton Variant="BsButtonVariant.Secondary" OnClick="() => _modal.Hide()">Hide</BsButton>
    <BsButton Variant="BsButtonVariant.Primary" OnClick="() => _modal.Toggle()">Modal.Toggle()</BsButton>
</BsModal>
@code {
    private BsModal _modal = default!;
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
    <ModalHeader>
        <BsModalTitle id="exampleModalLabel">Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        ...
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
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
<BsModal Id="extraLargeModal" Size="BsModalSize.ExtraLarge">...</BsModal>
<BsModal Id="largeModal" Size="BsModalSize.Large">...</BsModal>
<BsModal Id="smallModal" Size="BsModalSize.Small">...</BsModal>
"""
		},
		{
			"ModalRemoveAnimationExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#noAnimation">No animation</BsButton>
<BsModal Id="noAnimation" Centered Fade="false">
        No animation
</BsModal>
"""
		},
		{
			"ModalScrollingLongContentExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#scrollingModal">Launch demo modal</BsButton>
<BsModal Id="scrollingModal">
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        <p style="min-height: 1500px">This is some placeholder content to show the scrolling behavior for modals. Instead of repeating the text in the modal, we use an inline style to set a minimum height, thereby extending the length of the overall modal and demonstrating the overflow scrolling. When content becomes longer than the height of the viewport, scrolling will move the modal as needed.</p>
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
</BsModal>
"""
		},
		{
			"ModalScrollingLongContentScrollableExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#scrollableModal">Launch demo modal</BsButton>
<BsModal Id="scrollableModal" Scrollable>
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        <p style="min-height: 1500px">This is some placeholder content to show the scrolling behavior for modals. Instead of repeating the text in the modal, we use an inline style to set a minimum height, thereby extending the length of the overall modal and demonstrating the overflow scrolling. When content becomes longer than the height of the viewport, scrolling will move the modal as needed.</p>
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
</BsModal>
"""
		},
		{
			"ModalServiceDialogExample",
"""
<BsModalDialog>
    Hi
</BsModalDialog>
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
        //var modalReference = 
        await ModalService.ShowDialogAsync<ModalServiceDialogExample>();
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
<BsModal Id="staticBackdrop"
         Backdrop="BsModalBackdrop.Static"
         Keyboard="false"
         aria-labelledby="staticBackdropLabel"
         OnShow="@(() => _sb2.AppendLine("Show"))"
         OnShown="@(() => _sb2.AppendLine("Shown"))"
         OnHide="@(() => _sb2.AppendLine("Hide"))"
         OnHidePrevented="@(() => _sb2.AppendLine("HidePrevented"))"
         OnHidden="@(() => _sb2.AppendLine("Hidden"))">
    <ModalHeader>
        <BsModalTitle id="staticBackdropLabel">Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        ...
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Understood</BsButton>
    </ModalFooter>
</BsModal>
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
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        Modal body text goes here.
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
</BsModal>

"""
		},
		{
			"ModalToggleBetweenModalsExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#exampleModalToggle">Open first modal</BsButton>
<BsModal Id="exampleModalToggle" Centered>
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        Show a second modal and hide this one with the button below.
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Primary" Dismiss="BsButtonDismiss.Modal"
                  Target="#exampleModalToggle2"
                  Toggle="BsButtonTogle.Modal">Open second modal</BsButton>
    </ModalFooter>
</BsModal>
<BsModal Id="exampleModalToggle2" Centered>
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        Hide this modal and show the first with the button below.
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Primary" Dismiss="BsButtonDismiss.Modal"
                  Target="#exampleModalToggle"
                  Toggle="BsButtonTogle.Modal">Back to first</BsButton>
    </ModalFooter>
</BsModal>
"""
		},
		{
			"ModalVerticallyCenteredExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#verticallyCentered">Vertically centered modal</BsButton>
<BsModal Id="verticallyCentered" Centered>
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        This is a vertically centered modal.
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
</BsModal>
"""
		},
		{
			"ModalVerticallyCenteredScrollableExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonTogle.Modal" Target="#verticallyCenteredScrollable">
    Vertically centered scrollable modal
</BsButton>
<BsModal Id="verticallyCenteredScrollable" Scrollable Centered>
    <ModalHeader>
        <BsModalTitle>Modal title</BsModalTitle>
        <BsModalCloseButton />
    </ModalHeader>
    <ChildContent>
        <p>This is some placeholder content to show a vertically centered modal. We've added some extra copy here to show how vertically centering the modal works when combined with scrollable modals. We also use some repeated line breaks to quickly extend the height of the content, thereby triggering the scrolling. When content becomes longer than the prefedined max-height of modal, content will be cropped and scrollable within the modal.</p>
        <br><br><br><br><br><br><br><br><br><br>
        <p>Just like that.</p>
    </ChildContent>
    <ModalFooter>
        <BsButton Variant="BsButtonVariant.Secondary" Dismiss="BsButtonDismiss.Modal">Close</BsButton>
        <BsButton Variant="BsButtonVariant.Primary">Save Changes</BsButton>
    </ModalFooter>
</BsModal>
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
	};
}