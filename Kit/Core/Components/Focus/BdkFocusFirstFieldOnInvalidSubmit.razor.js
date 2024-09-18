export class BdkFocusFirstFieldOnInvalidSubmit {

    constructor(elementReference, invalidClass) {
        this.invalidClass = invalidClass;
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
    
    dispose() {
        this.form = null;
    }

    static create(elementReference, invalidClass) {
        return new BdkFocusFirstFieldOnInvalidSubmit(elementReference, invalidClass);
    }
}

window.BdkFocusFirstFieldOnInvalidSubmit = BdkFocusFirstFieldOnInvalidSubmit;