import { defineStore } from 'pinia';
import { RegisterUserCommand, type IRegisterUserCommand, UsersClient } from '@/clients';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new UsersClient(baseUrl);

export const useUsersStore = defineStore({
    id: 'users',
    state: () => ({
        users: {},
        user: {}
    }),
    actions: {
        async register(user: IRegisterUserCommand) {
            await client.register(new RegisterUserCommand(user as IRegisterUserCommand));
        }
    }
});