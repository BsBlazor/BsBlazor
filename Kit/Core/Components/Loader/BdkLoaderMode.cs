namespace BlazorDevKit;

public enum BdkLoaderMode
{
    /// <summary>
    /// Load occurs during prerender and interactive rendering (default)
    /// </summary>
    Repeat = 0,
    /// <summary>
    /// Load during prerender and persist the loaded state for interactive rendering
    /// </summary>  
    Persist,
    /// <summary>
    /// Load only when running in WebAssembly (interactive rendering only)]
    /// </summary>
    WebAssemblyOnly,
}
