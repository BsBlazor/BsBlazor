
export function afterWebStarted(blazor) {
    function registerSimpleEvent(eventName) {
        blazor.registerCustomEventType(eventName, {
            createEventArgs: () => {
                return {};
            }
        });
    }
    registerSimpleEvent('show.bs.modal');
    registerSimpleEvent('shown.bs.modal');
    registerSimpleEvent('hide.bs.modal');
    registerSimpleEvent('hideprevented.bs.modal');
    registerSimpleEvent('hidden.bs.modal');
}