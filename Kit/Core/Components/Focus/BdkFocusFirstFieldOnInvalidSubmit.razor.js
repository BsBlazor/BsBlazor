export class BdkFocusFirstFieldOnInvalidSubmit {

    constructor(dotNetReference, elementReference, invalidSelector) {
        this.invalidSelector = invalidSelector;
        this.dotNetReference = dotNetReference;
        this.form = elementReference.closest('form');
    }

    async validationChangedAsync(forceFocus) {
        let invalidInput = this.form.querySelector(this.invalidSelector);
        let attempts = 1;
        let maxAttempts = 4;        
        
        while (invalidInput == null && attempts <= maxAttempts) {
            await new Promise(resolve => setTimeout(resolve, 50));
            invalidInput = this.form.querySelector(this.invalidSelector);
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

    static create(identifier, dotNetReference, elementReference, invalidSelector) {
        window[identifier] = new BdkFocusFirstFieldOnInvalidSubmit(dotNetReference, elementReference, invalidSelector);
        window[identifier].form.addEventListener('submit', () => window[identifier].dotNetReference.invokeMethodAsync('NotifySubmitAsync'));
        return window[identifier];        
    }
}

window.BdkFocusFirstFieldOnInvalidSubmit = BdkFocusFirstFieldOnInvalidSubmit;