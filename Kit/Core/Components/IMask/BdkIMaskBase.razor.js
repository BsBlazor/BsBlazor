export class BdkIMask {
    constructor(dotNetReference, refElement) {
        this.dotNetReference = dotNetReference;
        const nextElement = refElement.nextElementSibling;
        if (nextElement.tagName.toLowerCase() === 'input') {
            this.input = nextElement;
        } else {
            this.input = nextElement.querySelector('input');
        }
    }
    async initAsync() {
        const type = await this.dotNetReference.invokeMethodAsync('GetIMaskType');
        switch (type) {
            case 'Pattern': await this.createPatternMask(); break;
            case 'Number': await this.createNumberMask(); break;
        }
        this.iMask.on('accept', () => {
            this.dotNetReference.invokeMethodAsync('AcceptValue',
                this.iMask.value,
                this.iMask.unmaskedValue,
                this.iMask.value !== '' ? this.iMask.typedValue : null);
        });
    }

    async createPatternMask() {
        const mask = await this.dotNetReference.invokeMethodAsync('GetMask');
        this.iMask = IMask(this.input, this.buildPatternMaskOptions(mask));
    }

    async refreshPatternMask() {
        const mask = await this.dotNetReference.invokeMethodAsync('GetMask');
        this.iMask.updateOptions(this.buildPatternMaskOptions(mask));
    }

    buildPatternMaskOptions(mask) {
        if (mask.startsWith('/') && mask.endsWith('/')) {
            mask = new RegExp(mask);
        }
        else {
            mask = mask.split('|');
            mask = mask.map(m => { return { mask: m }; });
        }
        return { mask };
    }

    async createNumberMask() {
        const data = await this.dotNetReference.invokeMethodAsync('GetData');
        this.iMask = IMask(this.input, {
            mask: Number,
            ...data
        });
    }

    setValue(value, target) {
        if ((target == 'typedValue' || target == 'unmaskedValue') && value === null) {
            value = '';
            target = 'value';
        }
        this.iMask[target] = value;
    }

    getUnmaskedValue() { return this.iMask.unmaskedValue; }

    static async create(dotNetReference, wrapperElement) {
        const bdkIMask = new BdkIMask(dotNetReference, wrapperElement);
        await bdkIMask.initAsync();
        return bdkIMask;
    }
}