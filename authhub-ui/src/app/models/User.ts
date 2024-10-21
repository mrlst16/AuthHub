export interface User {
    id: number; // Assuming EntityBase<int> translates to an `id` property
    userName: string;
    email: string;
    firstName: string;
    lastName: string;
    phoneNumber?: string; // Optional property
}