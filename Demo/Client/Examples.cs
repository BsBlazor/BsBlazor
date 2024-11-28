namespace BsBlazor;
public static class Examples 
{
	public static readonly IReadOnlyDictionary<string, string> Contents = new Dictionary<string, string>(){
		{
			"FluentValidationExample",
"""
@using FluentValidation
<EditForm Model="_model">
    <BdkFluentValidator Validator="new ModelValidator()" />
    <div>
        <label class="@Bs.Css.FormLabel">Name</label>
        <InputText class="@Bs.Css.FormControl" @bind-Value="_model.Name" />
        <ValidationMessage For="() => _model.Name" class="@Bs.Css.DisplayBlock.AddClass("is-invalid")"/>
    </div>
    <button type="submit" class="mt-2 btn btn-primary">Submit</button>
</EditForm>
@code {
    private Model _model = new();

    class Model
    {
        public string? Name { get; set; }
    }

    class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
"""
		},
		{
			"FocusFirstFieldOnInvalidSubmitExample",
"""
@using System.ComponentModel.DataAnnotations
<EditForm Model="this">
    <DataAnnotationsValidator/>
    <BdkFocusFirstFieldOnInvalidSubmit/>
    <InputText class="@Bs.Css.FormControl" @bind-Value="Name"/>
    <br/>
    <InputText class="@Bs.Css.FormControl" @bind-Value="Email"/>
    <BsButton Class="@Bs.Css.MarginTop2" Variant="BsButtonVariant.Primary" Type="BsButtonType.Submit">Submit</BsButton>
</EditForm>
@code{
    [Required]
    public string? Name { get; set; }
    
    [EmailAddress, Required]
    public string? Email { get; set; }
}
"""
		},
		{
			"FocusOnRenderExample",
"""
<RequiresInteractivity>
<div>
    <BdkFocusOnRender Selector="input" Delay="500"/>
    <input class="form-control"/>
</div>
</RequiresInteractivity>
"""
		},
		{
			"IMaskNumberBindingExample",
"""
<BdkIMaskNumber @bind-Value=DecimalValue 
                BindTarget="BdkIMaskBindTarget.TypedValue" 
                ThousandsSeparator=@(' ')>
    <input class="form-control"/>
</BdkIMaskNumber>
@(DecimalValue.HasValue ? DecimalValue.Value : "null")
@code {
    public decimal? DecimalValue { get; set; } = 12_345.67m;
}
"""
		},
		{
			"IMaskNumberExample",
"""
<BdkIMaskNumber T="decimal?">
    <input class="form-control" value="1" />
</BdkIMaskNumber>
"""
		},
		{
			"IMaskNumberParametersExample",
"""
<BdkIMaskNumber T="decimal?" PadFractionalZeros ThousandsSeparator=@('.') Max="10000" Min="0">
    <input class="form-control" value="10000" />
</BdkIMaskNumber>
"""
		},
		{
			"IMaskPatternExample",
"""
<BdkIMaskPattern Mask="{#}000[aaa]/NIC-`*[**]">
    <input class="form-control" value="#534/NIC-534" />
</BdkIMaskPattern>
"""
		},
		{
			"ErrorContentExample",
"""
<div class="d-flex flex-column align-items-center justify-content-center">
    <div class="mt-3 text-danger">
        @ErrorResult.Exception.Message
    </div>

    @if (ErrorResult.Loader.CanRetry)
    {
        <div class="mt-3">
            <button class="btn btn-primary" @onclick="ErrorResult.Loader.ReloadAsync">@ErrorResult.Loader.CanRetryTitle</button>
        </div>
    }
</div>

@code
{
    [Parameter] public required BdkLoaderErrorResult ErrorResult { get; set; }
}
"""
		},
		{
			"LoadingContentExample",
"""
<div class="d-flex flex-column align-items-center justify-content-center">
    <div class="spinner-border text-danger" role="status">
        <span class="visually-hidden">Loading...</span>
    </div>
    
    <div class="mt-3">@(string.IsNullOrEmpty(Message) ? "Loading..." : Message)</div>
</div>

@code 
{
    [Parameter] public string Message { get; set; } = string.Empty;
}
"""
		},
		{
			"LoaderBasicExample",
"""
@inject ISubjectService Service

<BdkLoader Load="Service.ListAsync">
    <ul>
        @foreach (var item in context)
        {
            <li>@item.Id - @item.CreatedOn</li>
        }
    </ul>
</BdkLoader>
"""
		},
		{
			"LoaderBasicWithErrorAndCanRetryAndLocalCustomExample",
"""
@inject ISubjectService Service

<BdkLoader Load="LoadAsync" CanRetry CanRetryTitle="Retry">
    <ErrorContent Context="errorResult">

        <div class="d-flex flex-column align-items-center justify-content-center">
            <div class="mt-3 text-info">
                @errorResult.Exception.Message
            </div>

            @if (errorResult.Loader.CanRetry)
            {
                <div class="mt-3">
                    <button class="btn btn-danger" @onclick="errorResult.Loader.ReloadAsync">@errorResult.Loader.CanRetryTitle</button>
                </div>
            }
        </div>
        
    </ErrorContent>
    <ChildContent>
        Content here
    </ChildContent>
</BdkLoader>

@code
{
    private async Task<ResponseItem[]> LoadAsync()
    {
        await Service.ProcessAsync(throwErrorAfterProcess: true); // Simulate error
        return await Service.ListAsync();
    }
}
"""
		},
		{
			"LoaderBasicWithErrorAndCanRetryExample",
"""
@inject ISubjectService Service

<BdkLoader Load="LoadAsync" CanRetry CanRetryTitle="Retry">
    <ul>
        @foreach (var item in context)
        {
            <li>@item.Id - @item.CreatedOn</li>
        }
    </ul>
</BdkLoader>

@code
{
    private async Task<ResponseItem[]> LoadAsync()
    {
        await Service.ProcessAsync(throwErrorAfterProcess: true); // Simulate error
        return await Service.ListAsync();
    }
}
"""
		},
		{
			"LoaderBasicWithErrorExample",
"""
@inject ISubjectService Service

<BdkLoader Load="LoadAsync">
    <ul>
        @foreach (var item in context)
        {
            <li>@item.Id - @item.CreatedOn</li>
        }
    </ul>
</BdkLoader>

@code
{
    private async Task<ResponseItem[]> LoadAsync()
    {
        await Service.ProcessAsync(throwErrorAfterProcess: true); // Simulate error
        return await Service.ListAsync();
    }
}
"""
		},
		{
			"LoaderBasicWithMessageExample",
"""
@inject ISubjectService Service

<BdkLoader Load="Service.ListAsync" Message="This is a custom message">
    <ul>
        @foreach (var item in context)
        {
            <li>@item.Id - @item.CreatedOn</li>
        }
    </ul>
</BdkLoader>

"""
		},
		{
			"LoaderVoidBasicExample",
"""
@inject ISubjectService Service

<BdkLoader T="object?" Load="LoadAsync">
    <p>
        Content displayed after loading
    </p>
</BdkLoader>

@code
{
    private async Task<object?> LoadAsync()
    {
        await Service.ProcessAsync();
        return null;
    }
}
"""
		},
		{
			"LoaderPreserveExample",
"""
@inject ISubjectService Service

<BdkLoader Load="Service.ListAsync" PreserveState >
    <ul>
        @foreach (var result in context)
        {
            <li>Item: @result.Id</li>
        }
    </ul>
</BdkLoader>
"""
		},
		{
			"LoaderPreserveVoidBasicExample",
"""
@inject ISubjectService Service

<BdkLoader T="object?" Load="LoadAsync" PreserveState>
    <p>
        Content displayed after loading
    </p>
</BdkLoader>

@code
{
    private async Task<object?> LoadAsync()
    {
        await Service.ProcessAsync();
        return null;
    }
}
"""
		},
		{
			"DateFieldExample",
"""
<BspDateField @bind-Value="_birthdate" Label="Birthdate" AutoFocus />
<div>Birthdate: @_birthdate</div>
@code{
    private DateTime? _birthdate;
}
"""
		},
		{
			"NumberFieldExample",
"""
<BspNumberField @bind-Value="_value" Immediate Label="Value" Step=".1M" Min="-1" Max="100" />
<div>Value: @_value</div>
@code{
    private decimal? _value;
}
"""
		},
		{
			"SelectFieldExample",
"""
<BspSelectField Label="Options" @bind-Value="_option">
    <option value="">Select an option...</option>
    <option value="1">Option 1</option>
    <option value="2">Option 2</option>
</BspSelectField>
<div>Option: @(_option is null ? "null" : _option.ToString())</div>
@code {
    private int? _option = null;
}

"""
		},
		{
			"TextAreaFieldExample",
"""
<BspTextAreaField @bind-Value="_description" Label="Description" Rows="3" Immediate />
<div style="white-space: pre">Description: @_description</div>
@code{
    private string? _description;
}
"""
		},
		{
			"TextFieldDataAnnotationsValidationExample",
"""
@using System.ComponentModel.DataAnnotations
<EditForm class="@Bs.Css.DisplayFlex.FlexColumn" Model="this">
    <DataAnnotationsValidator/>
    <BdkFocusFirstFieldOnInvalidSubmit/>
    <BspTextField @bind-Value="Name" Label="Name" />
    <BsButton Type="BsButtonType.Submit" Variant="BsButtonVariant.Primary">Send</BsButton>
</EditForm>
@code {
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

}
"""
		},
		{
			"TextFieldExample",
"""
<BspTextField @bind-Value="_name" Label="Name" AutoFocus/>
<div>Value: @_name</div>
@code{
    private string? _name;
}
"""
		},
		{
			"TextFieldFluentValidationExample",
"""
@using System.ComponentModel.DataAnnotations
@using FluentValidation
<EditForm class="@Bs.Css.DisplayFlex.FlexColumn" Model="this">
    <BdkFluentValidator Validator="new Validator()"/>
    <BdkFocusFirstFieldOnInvalidSubmit/>
    <BspTextField @bind-Value="Name" Label="Name" />
    <BsButton Type="BsButtonType.Submit" Variant="BsButtonVariant.Primary">Send</BsButton>
</EditForm>
@code {
    public string? Name { get; set; }
    class Validator : AbstractValidator<TextFieldFluentValidationExample>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
"""
		},
		{
			"BadgeBackgroundColorsExample",
"""
<BsBadge Color="BsThemeColor.Primary">Primary</BsBadge>
<BsBadge Color="BsThemeColor.Secondary">Secondary</BsBadge>
<BsBadge Color="BsThemeColor.Success">Success</BsBadge>
<BsBadge Color="BsThemeColor.Danger">Danger</BsBadge>
<BsBadge Color="BsThemeColor.Warning">Warning</BsBadge>
<BsBadge Color="BsThemeColor.Info">Info</BsBadge>
<BsBadge Color="BsThemeColor.Light">Light</BsBadge>
<BsBadge Color="BsThemeColor.Dark">Dark</BsBadge>
"""
		},
		{
			"BadgeButtonsExample",
"""
<BsButton Variant="BsButtonVariant.Primary">
    Notifications <BsBadge Color="BsThemeColor.Secondary">4</BsBadge>
</BsButton>
"""
		},
		{
			"BadgeHeadingsExample",
"""
<h1>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h1>
<h2>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h2>
<h3>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h3>
<h4>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h4>
<h5>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h5>
<h6>Example heading <BsBadge Color="BsThemeColor.Secondary">New</BsBadge></h6>
"""
		},
		{
			"BadgePillBadgesExample",
"""
<BsBadge Pill Color="BsThemeColor.Primary">Primary</BsBadge>
<BsBadge Pill Color="BsThemeColor.Secondary">Secondary</BsBadge>
<BsBadge Pill Color="BsThemeColor.Success">Success</BsBadge>
<BsBadge Pill Color="BsThemeColor.Danger">Danger</BsBadge>
<BsBadge Pill Color="BsThemeColor.Warning">Warning</BsBadge>
<BsBadge Pill Color="BsThemeColor.Info">Info</BsBadge>
<BsBadge Pill Color="BsThemeColor.Light">Light</BsBadge>
<BsBadge Pill Color="BsThemeColor.Dark">Dark</BsBadge>
"""
		},
		{
			"ButtonBaseExample",
"""
<BsButton>Base component</BsButton>

"""
		},
		{
			"ButtonDisabledExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Disabled>Primary button</BsButton>
<BsButton Variant="BsButtonVariant.Secondary" Disabled>Button</BsButton>
<BsButton Variant="BsButtonVariant.OutlinePrimary" Disabled>Primary button</BsButton>
<BsButton Variant="BsButtonVariant.OutlineSecondary" Disabled>Button</BsButton>
"""
		},
		{
			"ButtonOutlineVariantsExample",
"""
<BsButton Variant="BsButtonVariant.OutlinePrimary">Primary</BsButton>
<BsButton Variant="BsButtonVariant.OutlineSecondary">Secondary</BsButton>
<BsButton Variant="BsButtonVariant.OutlineSuccess">Success</BsButton>
<BsButton Variant="BsButtonVariant.OutlineDanger">Danger</BsButton>
<BsButton Variant="BsButtonVariant.OutlineWarning">Warning</BsButton>
<BsButton Variant="BsButtonVariant.OutlineInfo">Info</BsButton>
<BsButton Variant="BsButtonVariant.OutlineLight">Light</BsButton>
<BsButton Variant="BsButtonVariant.OutlineDark">Dark</BsButton>
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
			"ButtonTagsExample",
"""
<BsAnchorButton Variant="BsButtonVariant.Primary">Link</BsAnchorButton>
<BsButton Variant="BsButtonVariant.Primary">Button</BsButton>
<BsNavLinkButton Variant="BsButtonVariant.Primary">Nav link</BsNavLinkButton>
<BsLabelButton Variant="BsButtonVariant.Primary">Label</BsLabelButton>
"""
		},
		{
			"ButtonVariantsExample",
"""
<BsButton Variant="BsButtonVariant.Primary">Primary</BsButton>
<BsButton Variant="BsButtonVariant.Secondary">Secondary</BsButton>
<BsButton Variant="BsButtonVariant.Success">Success</BsButton>
<BsButton Variant="BsButtonVariant.Danger">Danger</BsButton>
<BsButton Variant="BsButtonVariant.Warning">Warning</BsButton>
<BsButton Variant="BsButtonVariant.Info">Info</BsButton>
<BsButton Variant="BsButtonVariant.Light">Light</BsButton>
<BsButton Variant="BsButtonVariant.Dark">Dark</BsButton>

<BsButton Variant="BsButtonVariant.Link">Link</BsButton>
"""
		},
		{
			"CardExample",
"""
<BsCard Style="width: 18rem;">
    <svg class="@Bs.Css.CardImageTop" style="text-anchor: middle" width="100%" height="180" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Image cap" preserveAspectRatio="xMidYMid slice" focusable="false">
        <title>Placeholder</title>
        <rect width="100%" height="100%" fill="#868e96"></rect>
        <text x="50%" y="50%" fill="#dee2e6" dy=".3em">Image cap</text>
    </svg>
    <BsCardBody>
        <BsCardTitle>Card title</BsCardTitle>
        <BsCardText>Some quick example text to build on the card title and make up the bulk of the card's content.</BsCardText>
        <BsAnchorButton Href="#" Variant="BsButtonVariant.Primary">Go somewhere</BsAnchorButton>
    </BsCardBody>
</BsCard>
"""
		},
		{
			"DropdownsDarkExample",
"""
<BsDropdown>
    <BsButton Toggle="BsButtonToggle.Dropdown" Variant="BsButtonVariant.Secondary" >
        Dropdown button
    </BsButton>
    <BsDropdownMenu Dark>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Something else here</BsAnchorDropdownItem>
        <BsDropdownDivider />
        <BsAnchorDropdownItem Href="#">Separated link</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsDropdown>
"""
		},
		{
			"DropdownsSingleButtonExample",
"""
<BsDropdown>
    <BsButton Toggle="BsButtonToggle.Dropdown" Variant="BsButtonVariant.Secondary" >
        Dropdown button
    </BsButton>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
        <BsDropdownDivider />
        <BsButtonDropdownItem OnClick="args => Console.WriteLine(args.Type)">Here is button item</BsButtonDropdownItem>
    </BsDropdownMenu>
</BsDropdown>
"""
		},
		{
			"DropdownsSingleButtonWithColorVariantesExample",
"""
<div class="@Bs.Css.DisplayFlex.FlexRow.Gap2.FlexWrap">

    @foreach (var variant in _variants)
    {
        <BsButtonGroup>
            <BsButton Toggle="BsButtonToggle.Dropdown" Variant="variant">
                Dropdown button
            </BsButton>
            <BsDropdownMenu>
                <BsAnchorDropdownItem>Action</BsAnchorDropdownItem>
                <BsAnchorDropdownItem>Another action</BsAnchorDropdownItem>
                <BsAnchorDropdownItem>Something else here</BsAnchorDropdownItem>
            </BsDropdownMenu>
        </BsButtonGroup>
    }

</div>

@code
{
    private readonly BsButtonVariant[] _variants = Enum.GetValues<BsButtonVariant>();
}
"""
		},
		{
			"DropdownsSizingExample",
"""
<BsDropdown>
    <BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Dropdown" Size="BsButtonSize.Small">
        Small button
    </BsButton>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsDropdown>

<BsDropdown>
    <BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Dropdown" Size="BsButtonSize.Large">
        Large button
    </BsButton>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsDropdown>

<BsButtonGroup>
    <BsButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Small">
        Small split button
    </BsButton>
    <BsDropdownToggleSplitButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Small"/>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsButtonGroup>

<BsButtonGroup>
    <BsButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Large">
        Large split button
    </BsButton>
    <BsDropdownToggleSplitButton Variant="BsButtonVariant.Primary" Size="BsButtonSize.Large"/>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsButtonGroup>
"""
		},
		{
			"DropdownsSplitButtonExample",
"""
<BsButtonGroup>
    <BsButton Variant="BsButtonVariant.Primary">Dropdown button</BsButton>
    <BsDropdownToggleSplitButton Variant="BsButtonVariant.Primary"/>
    <BsDropdownMenu>
        <BsAnchorDropdownItem Href="#">Here is anchor item</BsAnchorDropdownItem>
        <BsAnchorDropdownItem Href="#">Another anchor item</BsAnchorDropdownItem>
    </BsDropdownMenu>
</BsButtonGroup>
"""
		},
		{
			"FormsOverviewExample",
"""
<form>
    <div>
        <BsFormLabel For="exampleInputEmail1">Email address</BsFormLabel>
        <input id="exampleInputEmail1" class="@Bs.Css.FormControl" />
        <BsFormText>We'll never share your email with anyone else.</BsFormText>
    </div>
</form>
"""
		},
		{
			"ModalFullscreenExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreen">Full screen</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreenSm">Full screen below sm</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreenMd">Full screen below md</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreenLg">Full screen below lg</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreenXl">Full screen below xl</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalFullscreenXxl">Full screen below xxl</BsButton>
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
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModal">Launch demo modal</BsButton>
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
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#extraLargeModal">Extra large modal</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#largeModal">Large modal</BsButton>
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#smallModal">Small modal</BsButton>
<BsModalShorthand Id="extraLargeModal" Title="Extra large modal" Size="BsModalSize.ExtraLarge">...</BsModalShorthand>
<BsModalShorthand Id="largeModal" Size="BsModalSize.Large" Title="Large modal">...</BsModalShorthand>
<BsModalShorthand Id="smallModal" Size="BsModalSize.Small" Title="Small modal">...</BsModalShorthand>
"""
		},
		{
			"ModalRemoveAnimationExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#noAnimation">No animation</BsButton>
<BsModalShorthand Id="noAnimation" Centered Fade="false">
        No animation
</BsModalShorthand>
"""
		},
		{
			"ModalScrollingLongContentExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#scrollingModal">Launch demo modal</BsButton>
<BsModalShorthand Id="scrollingModal" ShowPrimaryButton PrimaryButtonText="Save changes">
    <p style="min-height: 1500px">This is some placeholder content to show the scrolling behavior for modals. Instead of repeating the text in the modal, we use an inline style to set a minimum height, thereby extending the length of the overall modal and demonstrating the overflow scrolling. When content becomes longer than the height of the viewport, scrolling will move the modal as needed.</p>
</BsModalShorthand>
"""
		},
		{
			"ModalScrollingLongContentScrollableExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#scrollableModal">Launch demo modal</BsButton>
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
          Toggle="BsButtonToggle.Modal"
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
<BsModal Class="position-static d-block h-auto" Fade="false">
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
<BsModal Class="position-static d-block h-auto" Fade="false">
    <BsModalDialogShorthand Title="Shorthand modal dialog title">
        Shortand Modal Dialog
    </BsModalDialogShorthand>
</BsModal>

"""
		},
		{
			"ModalStaticShorthandExample",
"""
<BsModalShorthand Class="position-static d-block h-auto" Title="Shortand modal title" Fade="false">
    Shortand Modal
</BsModalShorthand>

"""
		},
		{
			"ModalToggleBetweenModalsExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#exampleModalToggle">Open first modal</BsButton>
<BsModalShorthand Id="exampleModalToggle"
                  Title="Modal 1"
                  Centered>
    <ChildContent>
        Show a second modal and hide this one with the button below.
    </ChildContent>
    <CustomFooter>
        <BsButton Variant="BsButtonVariant.Primary" Dismiss="BsButtonDismiss.Modal"
                  Target="#exampleModalToggle2"
                  Toggle="BsButtonToggle.Modal">Open second modal</BsButton>
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
                  Toggle="BsButtonToggle.Modal">Back to first</BsButton>
    </CustomFooter>
</BsModalShorthand>
"""
		},
		{
			"ModalVerticallyCenteredExample",
"""
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#verticallyCentered">Vertically centered modal</BsButton>
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
<BsButton Variant="BsButtonVariant.Primary" Toggle="BsButtonToggle.Modal" Target="#verticallyCenteredScrollable">
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
			"SpinnerBorderExample",
"""
<BsSpinner/>
"""
		},
		{
			"SpinnerSizeExample",
"""
<BsSpinner Size="BsSpinnerSize.Small"/>
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
    <BsToast Class="@Bs.Css.TextBackgroundPrimary">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundSecondary">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundSuccess">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundDanger">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundWarning">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundInfo">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundLight">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Css.TextBackgroundDark">
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
    <BsToast Class="@Bs.Default("fade show").TextBackgroundPrimary" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundSecondary" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundSuccess" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundDanger" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto" White/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundWarning" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundInfo" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundLight" AutoHide="false">
        <BsToastBody>
            <div class="d-flex">
                Hello, world! This is a toast message.
                <BsToastCloseButton Class="me-2 m-auto"/>
            </div>
        </BsToastBody>
    </BsToast>
    <BsToast Class="@Bs.Default("fade show").TextBackgroundDark" AutoHide="false">
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
			"ToastServiceRenderFragmentExample",
"""
@inject  IToastService ToastService

<div class="d-flex flex-wrap" style="gap: 10px;">
    <BsButton Variant="BsButtonVariant.Primary" Type="BsButtonType.Button" OnClick="ShowToastAsync">
        Show toast
    </BsButton>
</div>

@code 
{
    private async Task ShowToastAsync()
    {
        await ToastService.ShowAsync(@<BsToastBody>Hi, I am a toast body</BsToastBody>);
    }
}
"""
		},
		{
			"ToastServiceStandaloneExample",
"""
@inject  IToastService ToastService

<div class="d-flex flex-wrap" style="gap: 10px;">
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
</div>

@code 
{
    private ToastOptions _options = new ()
    {
        Class = Bs.Css.TextBackgroundPrimary,
        Delay = 4000
    };
    
    private async Task ShowToastAsync()
    {
        var options = new ToastOptions
        {
            Color = BsToastColor.Secondary,
            Delay = 30000
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
            <MyIcon/>
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
            <MyIcon/>
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
			"TooltipBasicExample",
"""
<BsTooltip Text="Default tooltip" Placement="BsTooltipPlacement.Bottom">
    <a href="#">Basic sample</a>
</BsTooltip>

@code {

}
"""
		},
	};
}