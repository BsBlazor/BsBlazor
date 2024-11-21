
export function afterWebStarted(blazor) {
    function registerSimpleEvent(eventName) {
        blazor.registerCustomEventType(eventName, {
            createEventArgs: () => {
                return {};
            }
        });
    }

    // Dropdown events
    registerSimpleEvent('show.bs.dropdown');
    registerSimpleEvent('shown.bs.dropdown');
    registerSimpleEvent('hide.bs.dropdown');
    registerSimpleEvent('hidden.bs.dropdown');
    
    // Modal events
    registerSimpleEvent('show.bs.modal');
    registerSimpleEvent('shown.bs.modal');
    registerSimpleEvent('hide.bs.modal');
    registerSimpleEvent('hideprevented.bs.modal');
    registerSimpleEvent('hidden.bs.modal');
    
    // Toast events
    registerSimpleEvent('hide.bs.toast');
    registerSimpleEvent('hidden.bs.toast');
    registerSimpleEvent('show.bs.toast');
    registerSimpleEvent('shown.bs.toast');
}