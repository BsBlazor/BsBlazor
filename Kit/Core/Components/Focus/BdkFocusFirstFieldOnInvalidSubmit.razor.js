export class BdkFocusFirstFieldOnInvalidSubmit {

    constructor(dotNetReference, elementReference, invalidClass) {
        this.invalidClass = invalidClass;
        this.dotNetReference = dotNetReference;
        this.form = elementReference.closest('form');
    }

    async validationChangedAsync(forceFocus) {
        let invalidInput = this.form.querySelector(`.${this.invalidClass}`);
        let attempts = 1;
        let maxAttempts = 4;        
        
        while (invalidInput == null && attempts <= maxAttempts) {
            await new Promise(resolve => setTimeout(resolve, 50));
            invalidInput = this.form.querySelector(`.${this.invalidClass}`);
            attempts++;
        }
        
        if(!invalidInput) { return; }
        
        if (this.isFocusable(invalidInput)) {
            invalidInput.focus();
        } else if (forceFocus) {
            invalidInput.tabIndex = 0;
            invalidInput.focus();
            invalidInput.tabIndex = -1;
        } else {
            console.log('The .invalid input is not focusable');
        }
    }    
    
    isFocusable(element) {
        return element.tabIndex >= 0;
    }
    
    dispose(identifier) {
        this.form = null;
        delete window[identifier];
    }

    static create(identifier, dotNetReference, elementReference, invalidClass) {
        window[identifier] = new BdkFocusFirstFieldOnInvalidSubmit(dotNetReference, elementReference, invalidClass);
        window[identifier].form.addEventListener('submit', () => window[identifier].dotNetReference.invokeMethodAsync('NotifySubmitAsync'));
        return window[identifier];        
    }
}

window.BdkFocusFirstFieldOnInvalidSubmit = BdkFocusFirstFieldOnInvalidSubmit;