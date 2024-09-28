export class BdkFocusOnRender {
    static focusAsync(elementReference, selector, delay) {
        setTimeout(() => {
            const element = elementReference.parentNode.querySelector(selector);
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