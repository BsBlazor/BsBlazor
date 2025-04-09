export class BdkFocusOnRender {
    static focusAsync(elementReference, selector, delay) {
        const parentElement = elementReference.parentNode;
        setTimeout(() => {
            const element = parentElement.querySelector(selector);
            if (element) {
                if (!element.hasAttribute('tabindex')) {
                    element.tabIndex = -1;
                }
                element.focus();
            }
        }, delay);
        
    }
}
window.BdkFocusOnRender = BdkFocusOnRender;