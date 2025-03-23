namespace BsBlazor.Plus;
public partial class BspSelectMultiSearchField<TValue, TItem> where TValue : notnull
{
    private ElementReference _bsDropdownToggleElement;
    private IJSObjectReference _bsDropdownJs = default!;

    private ElementReference _firstItem;
    private ElementReference _inputReference;
    private IJSObjectReference _inputJs = default!;
    private System.Timers.Timer? _timer;
    private string _searchTerm = "";
    private readonly List<Guid> _searchCalls = [];
    private TItem[] _items = [];
    private readonly Dictionary<TValue, TItem> _knownItems = [];
    private bool _firstShow = true;
    [Parameter] public string Placeholder { get; set; } = "";
    [Parameter] public string Label { get; set; } = "";
    [Parameter] public TValue[] Value { get; set; } = [];
    [Parameter] public EventCallback<TValue[]> ValueChanged { get; set; }
    [Parameter] public required Expression<Func<TValue[]>> ValueExpression { get; set; }
    [Parameter] public Func<string, Task<TItem[]>> Search { get; set; } = term => Task.FromResult(new TItem[0]);
    [Parameter] public Func<TValue[], Task<TItem[]>> Recover { get; set; } = value => Task.FromResult(new TItem[0]);
    [Parameter] public Func<TItem, string> TextAccessor { get; set; } = item => "";
    [Parameter] public Func<TItem, TValue> ValueAccessor { get; set; } = item => default!;
    [Parameter] public string MaxHeight { get; set; } = "300px";
    [CascadingParameter] private EditContext? EditContext { get; set; }
    private FieldIdentifier Field => FieldIdentifier.Create(ValueExpression);


    private Item[] GetCurrentItems() => Value.Select(v => _knownItems.TryGetValue(v, out TItem? value) ? new Item
    {
        Label = TextAccessor(value),
        Value = v
    }
    : new Item
    {
        Label = v?.ToString() ?? "null",
        Value = v
    }).ToArray();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _bsDropdownJs = await JS.InvokeAsync<IJSObjectReference>("bootstrap.Dropdown.getOrCreateInstance", _bsDropdownToggleElement);
            _inputJs = await JS.InvokeAsync<IJSObjectReference>("getJsReference", _inputReference);
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        var unknownItems = Value.Where(v => !_knownItems.ContainsKey(v)).ToArray();
        if (unknownItems.Length > 0)
        {
            var items = await Recover(unknownItems);
            foreach (var item in items)
            {
                var value = ValueAccessor(item);
                _knownItems[value] = item;
            }
        }
    }

    private async Task OnControlKeyDown(KeyboardEventArgs e)
    {
        // Don't open if it does not represent a character
        if (e.Code is "Tab"
                  or "Escape"
                  or "ShiftLeft"
                  or "ShiftRight"
                  or "ArrowUp"
                  or "ArrowDown"
                  or "ArrowLeft"
                  or "ArrowRight"
                  or "PageUp"
                  or "PageDown"
                  or "Home"
                  or "End"
                  or "Insert"
                  or "Delete"
                  or "NumLock"
                  or "ScrollLock"
                  or "CapsLock"
                  or "Enter")
        {
            return;
        }
        await _bsDropdownJs.InvokeVoidAsync("show");
        await _inputJs.InvokeVoidAsync("focus");
    }

    private bool _lastKeyWasArrowDown = false;
    private async Task OnInputKeyDown(KeyboardEventArgs e)
    {
        _lastKeyWasArrowDown = false;
        if (e.Code == "ArrowDown")
        {
            _lastKeyWasArrowDown = true;
            var firstItemJs = await JS.InvokeAsync<IJSObjectReference>("getJsReference", _firstItem);
            await firstItemJs.InvokeVoidAsync("focus");
        }
    }

    private bool IsSelected(TItem item)
    {
        var itemValue = ValueAccessor(item);
        return Value.Contains(itemValue);
    }

    private async Task SelectAsync(TItem item)
    {
        var itemValue = ValueAccessor(item);
        if (Value.Contains(itemValue))
        {
            Value = Value.Where(v => v?.Equals(itemValue) is false).ToArray();
        }
        else
        {
            Value = [.. Value, itemValue];
        }

        await ValueChanged.InvokeAsync(Value);
        await _bsDropdownJs.InvokeVoidAsync("update");
        EditContext?.NotifyFieldChanged(Field);

    }

    private async Task SearchAsync()
    {
        var callId = Guid.NewGuid();
        try
        {
            _searchCalls.Add(callId);
            _items = await Search(_searchTerm);
            foreach (var item in _items)
            {
                _knownItems[ValueAccessor(item)!] = item;
            }
            StateHasChanged();
        }
        finally
        {
            _searchCalls.Remove(callId);
        }
    }

    private async Task OnShow()
    {
        if (!_firstShow)
        {
            return;
        }
        _firstShow = false;
        await SearchAsync();
    }

    private void Debounce(Func<Task> action, int milliseconds)
    {
        _timer?.Stop();
        _timer = null;

        _timer = new System.Timers.Timer() { Interval = milliseconds, Enabled = false, AutoReset = false };
        _timer.Elapsed += (s, e) =>
        {
            if (_timer == null)
            {
                return;
            }

            _timer?.Stop();
            _timer = null;

            try
            {
                Task.Run(action);
            }
            catch (TaskCanceledException)
            {
                // Ignore
            }
        };

        _timer.Start();
    }

    private class Item
    {
        public string Label { get; set; } = "";
        public TValue? Value { get; set; }
    }
}