export function afterWebStarted(blazor) {
    function registerSimpleEvent(eventName) {
        blazor.registerCustomEventType(eventName, {
            createEventArgs: () => {
                return {};
            }
        });
    }

    // Dropdown events
    registerSimpleEvent('internalclick.bsp.selectmultisearch');
}