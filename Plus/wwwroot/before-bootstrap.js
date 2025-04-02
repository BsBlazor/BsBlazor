// Avoid event propagation in BspSelectMultiField component when clicking on the close/remove button of a selected item
document.addEventListener(
    'click',
    function (e) {
        if ('bsp-select-multi-remove-button' in e.target.attributes) {
            e.stopImmediatePropagation();
            e.target.dispatchEvent(new Event('internalclick.bsp.selectmultisearch', { bubbles: true }));
        }
    },
    true // Add listener to capturing phase
);