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
        const definitions = await this.dotNetReference.invokeMethodAsync('GetDefinitions');
        this.iMask = IMask(this.input, this.buildPatternMaskOptions(mask, definitions));
    }

    async refreshPatternMask() {
        const mask = await this.dotNetReference.invokeMethodAsync('GetMask');
        const definitions = await this.dotNetReference.invokeMethodAsync('GetDefinitions');
        this.iMask.updateOptions(this.buildPatternMaskOptions(mask, definitions));
    }

    buildPatternMaskOptions(mask, definitions) {
        if (definitions) {
            for (const key in definitions) {
                definitions[key] = new RegExp(definitions[key]);
            }
        }
     
        if (mask.startsWith('/') && mask.endsWith('/')) {
            mask = new RegExp(mask);
        }
        else {
            mask = mask.split('|');
            if (mask.length === 1) {
                mask = mask[0]; // definitions does not work with array of masks, so if there is only one, we will not use array
            } else {
                mask = mask.map(m => { return { mask: m }; });
            }
        }
        return { mask, definitions };
    }

    async createNumberMask() {
        const data = await this.dotNetReference.invokeMethodAsync('GetData');
        this.iMask = IMask(this.input, {
            mask: Number,
            ...data
        });
    }

    setValue(value, target) {
        if (value === null) {
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