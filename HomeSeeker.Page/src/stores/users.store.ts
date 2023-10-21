import { defineStore } from 'pinia';
import { RegisterUserCommand, type IRegisterUserCommand, UsersClient } from '@/clients';
import { getErrorMessage } from '@/helpers';
import { useAlertStore } from '@/stores';
import { router } from '@/router';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new UsersClient(baseUrl);

export const useUsersStore = defineStore({
    id: 'users',
    actions: {
        async register(user: IRegisterUserCommand) {
            const alertStore = useAlertStore();
            try {
                await client.register(new RegisterUserCommand(user));
                await router.push('/account/login');
                alertStore.success('Registration successful');
            } catch (error) {
                alertStore.error(getErrorMessage(error));
            }
        }
    }
});