import { defineStore } from 'pinia';
import { RegisterUser, type IRegisterUser, UsersClient } from '@/clients';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new UsersClient(baseUrl);

export const useUsersStore = defineStore({
    id: 'users',
    state: () => ({
        users: {},
        user: {}
    }),
    actions: {
        async register(user: IRegisterUser) {
            await client.register(new RegisterUser(user as IRegisterUser));
        }
    }
});