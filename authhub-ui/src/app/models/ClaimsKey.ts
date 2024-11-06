export interface ClaimsKey {
    id: number; // Assuming EntityBase<int> translates to an `id` property
    name: string;
    defaultValue: string;
    authSettingsId: number;
    isDefault: boolean;
}

// Example of a constructor if you prefer using a class
export class ClaimsKeyModel implements ClaimsKey {
    constructor(
        public id: number,
        public name: string,
        public defaultValue: string,
        public authSettingsId: number,
        public isDefault: boolean
    ) {}
}