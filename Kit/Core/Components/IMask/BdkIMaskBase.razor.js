export class BdkIMask {
    constructor(dotNetReference, wrapperElement) {
        this.dotNetReference = dotNetReference;
        this.input = wrapperElement.querySelector('input');
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
        let mask = await this.dotNetReference.invokeMethodAsync('GetMask');
        if (mask.startsWith('/') && mask.endsWith('/')) {
            mask = new RegExp(mask);
        }
        else {
            mask = mask.split('|');
            mask = mask.map(m => { return { mask: m }; });
        }
        this.iMask = IMask(this.input, {
            mask,
        });
    }

    async createNumberMask() {
        const data = await this.dotNetReference.invokeMethodAsync('GetData');
        this.iMask = IMask(this.input, {
            mask: Number,
            ...data
        });
    }

    async setValue(value, target) {
        if (target == 'typedValue' && value === null) {
            value = '';
            target = 'value';
        }
        this.iMask[target] = value;
    }

    static async create(dotNetReference, wrapperElement) {
        const bdkIMask = new BdkIMask(dotNetReference, wrapperElement);
        await bdkIMask.initAsync();
        return bdkIMask;
    }
}