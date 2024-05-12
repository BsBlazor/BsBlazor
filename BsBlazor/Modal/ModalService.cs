﻿using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ModalService: IModalService
{
    public event Action<ModalReference>? OnModalAdded;
    public event Action<ModalReference>? OnModalRemoved;
    public List<ModalReference> ModalReferences { get; private set; } = [];

    public async Task<IModalReference> ShowDialogAsync(RenderFragment renderFragment)
    {
        var modalReference = new ModalReference
        {
            RenderFragment = renderFragment
        };
        return await ShowDialogAsync(modalReference);
    }


    public async Task<IModalReference> ShowDialogAsync(RenderFragment<IModalReference> contextualRenderFragment)
    {
        var modalReference = new ModalReference
        {
            ContextualRenderFragment = contextualRenderFragment
        };
        return await ShowDialogAsync(modalReference);
    }

    public async Task<IModalReference> ShowDialogAsync<TDialogComponent>()
    {
        var modalReference = new ModalReference
        {
            DialogType = typeof(TDialogComponent)
        };
       return await ShowDialogAsync(modalReference);
    }

    private async Task<IModalReference> ShowDialogAsync(ModalReference modalReference)
    {
        ModalReferences.Add(modalReference);
        OnModalAdded?.Invoke(modalReference);
        modalReference.OnHidden += () =>
        {
            ModalReferences.Remove(modalReference);
            OnModalRemoved?.Invoke(modalReference);
        };
        // The API would be ready for some async call
        await Task.CompletedTask;
        return modalReference;
    }
}
