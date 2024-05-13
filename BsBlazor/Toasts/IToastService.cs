// namespace BsBlazor;
//
// public interface IToastService
// {
//     Task ShowAsync(string message, BsToastVariant? variant = null);
//     Task ShowAsync(string title, string message, BsToastVariant? variant = null);
// }
//
// internal class ToastService : IToastService
// {
//     public event Action<ModalReference>? OnToastAdded;
//     public event Action<ModalReference>? OnToastRemoved;
// }
//
// public class ToastOptions
// {
//     public BsToastVariant Variant { get; set; } = BsToastVariant.Default;
// }