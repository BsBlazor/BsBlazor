using Microsoft.AspNetCore.Components.Forms;

namespace BsBlazor.Plus;

internal static class BspFieldUtils
{
    public static string ComputeId(string? id, FieldIdentifier? fieldIdentifier, BspFieldGroup? group)
    {
        if (!string.IsNullOrEmpty(id))
        {
            return id;
        }
        if (!fieldIdentifier.HasValue)
        {
            return $"bsp-field-{Guid.NewGuid()}";
        }
        return group?.GetId(fieldIdentifier.Value.FieldName) ?? fieldIdentifier.Value.FieldName;
    }
}