using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace BlazorDevKit;

public static class BdkLoaderOptions
{
    public static class Error
    {
        private static Dictionary<Type, Type> ErrorTemplatesTypes { get; } = [];
        private static Dictionary<Type, RenderFragment<BdkLoaderErrorResult>> ErrorTemplatesRenderFragments { get; } = [];
        
        public static void RegisterContent<TException, TContentComponent>() where TException : Exception where TContentComponent : IComponent
        {
            var exceptionType = typeof(TException);
            ErrorTemplatesTypes[exceptionType] = typeof(TContentComponent);
            ErrorTemplatesRenderFragments.Remove(exceptionType);
        }
        
        public static void RegisterContent<TException>(RenderFragment<BdkLoaderErrorResult> renderFragment) where TException : Exception
        {
            var exceptionType = typeof(TException);
            ErrorTemplatesRenderFragments[exceptionType] = renderFragment;
            ErrorTemplatesTypes.Remove(exceptionType);
        }
        
        internal static bool HasRenderFragmentContent(Type exception) => ErrorTemplatesRenderFragments.ContainsKey(exception);
        internal static bool HasComponentTypeContent(Type exception) => ErrorTemplatesTypes.ContainsKey(exception);

        internal static bool HasRenderFragmentGenericContent => ErrorTemplatesRenderFragments.ContainsKey(typeof(Exception));
        internal static bool HasComponentTypeGenericContent => ErrorTemplatesTypes.ContainsKey(typeof(Exception));
        
        internal static RenderFragment BuildComponentTypeContent(BdkLoaderErrorResult errorResult)
        {
            var exceptionType = errorResult.GetExceptionType();
            if (!ErrorTemplatesTypes.TryGetValue(exceptionType, out var componentType))
            {
                throw new InvalidOperationException($"Error content for {exceptionType.FullName} is not set");
            }
            return BuildRenderFragment(componentType, new Dictionary<string, object> { ["ErrorResult"] = errorResult });
        }
        internal static RenderFragment<BdkLoaderErrorResult> GetRenderFragmentContent(Type exceptionType)
        {
            if (!ErrorTemplatesRenderFragments.TryGetValue(exceptionType, out var renderFragment))
            {
                throw new InvalidOperationException($"Error content for {exceptionType.FullName} is not set");
            }
            return renderFragment;
        }
        
        internal static RenderFragment BuildComponentTypeGenericContent(BdkLoaderErrorResult errorResult)
        {
            if (!ErrorTemplatesTypes.TryGetValue(typeof(Exception), out var componentType))
            {
                throw new InvalidOperationException("Error content for generic exception is not set");
            }
            
            return BuildRenderFragment(componentType, new Dictionary<string, object> { ["ErrorResult"] = errorResult });
        }
        internal static RenderFragment<BdkLoaderErrorResult> GetRenderFragmentGenericContent()
        {
            if (!ErrorTemplatesRenderFragments.TryGetValue(typeof(Exception), out var renderFragment))
            {
                throw new InvalidOperationException("Error content for generic exception is not set");
            }
            return renderFragment;
        }
    }
    
    public static class Loading
    {
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] private static Type? ContentType { get; set; }
        private static MarkupString? ContentMarkupString { get; set; }
        private static RenderFragment<string>? ContentRenderFragment { get; set; }
        
        /// <summary>
        /// Set the loading content to be displayed when the loader is at loading state
        /// </summary>
        /// <typeparam name="TContentComponent"> Should contain parameter `Message` typed string</typeparam>
        public static void ChangeContent<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TContentComponent>() where TContentComponent : IComponent
        {
            ContentMarkupString = null;
            ContentRenderFragment = null;
            ContentType = typeof(TContentComponent);
        }
        
        /// <summary>
        /// Set the loading content to be displayed when the loader is at loading state
        /// </summary>
        /// <param name="markupString"></param>
        public static void ChangeContent(MarkupString markupString)
        {
            ContentType = null;
            ContentRenderFragment = null;
            ContentMarkupString = markupString;
        }
        
        /// <summary>
        /// Set the loading content to be displayed when the loader is at loading state
        /// </summary>
        /// <param name="renderFragment"></param>
        public static void ChangeContent(RenderFragment<string> renderFragment)
        {
            ContentType = null;
            ContentMarkupString = null;
            ContentRenderFragment = renderFragment;
        }
        
        internal static bool HasRenderFragmentContent => ContentRenderFragment is not null;
        internal static bool HasMarkupStringContent => ContentMarkupString is not null;
        internal static bool HasComponentTypeContent => ContentType is not null;
        
        internal static RenderFragment BuildComponentTypeContent(string message)
        {
            if (ContentType is null) throw new InvalidOperationException("Loading content is not set");
            return BuildRenderFragment(ContentType, new Dictionary<string, object> { ["Message"] = message });
        }
        
        internal static MarkupString GetMarkupStringContent()
        {
            if (ContentMarkupString is null) throw new InvalidOperationException("Loading content is not set");
            return ContentMarkupString.Value;
        }
        
        internal static RenderFragment<string> GetRenderFragmentContent()
        {
            if (ContentRenderFragment is null) throw new InvalidOperationException("Loading content is not set");
            return ContentRenderFragment;
        }
        
    }
    
    private static RenderFragment BuildRenderFragment(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type componentType, 
        Dictionary<string, object> parameters)
    {
        if (!typeof(IComponent).IsAssignableFrom(componentType))
        {
            throw new ArgumentException($"{componentType.FullName} must be a Blazor IComponent");
        }
            
        var renderFragment = new RenderFragment(builder =>
        {
            var i = 0;
            builder.OpenComponent(i++, componentType);
            builder.AddMultipleAttributes(i, parameters);
            builder.CloseComponent();
        });
            
        return renderFragment;
    }
    
}