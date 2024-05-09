namespace BsBlazor;
public static class Examples 
{
	public static readonly IReadOnlyDictionary<string, string> Contents = new Dictionary<string, string>(){
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
		}
	};
}