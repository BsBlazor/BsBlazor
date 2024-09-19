export class BdkIMask {
    constructor(dotNetReference, wrapperElement) {
        this.dotNetReference = dotNetReference;
        this.input = wrapperElement.querySelector('input');
    }
    async initAsync() {
        let mask = await this.dotNetReference.invokeMethodAsync('GetMask');
        if (mask.startsWith('/') && mask.endsWith('/')) {
            mask = new RegExp(mask);
        }
        else {
            mask = mask.split('|');
            mask = mask.map(m => { return { mask: m }; });
        }
        this.iMask = IMask(this.input, { mask });
    }
    static async create(dotNetReference, wrapperElement) {
        const bdkIMask = new BdkIMask(dotNetReference, wrapperElement);
        await bdkIMask.initAsync();
        return bdkIMask;
    }
}