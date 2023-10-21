import { defineStore } from 'pinia';

import { getErrorMessage } from '@/helpers';
import { router } from '@/router';
import { useAlertStore } from '@/stores';
import { AuthenticateQuery, type IAuthenticateQuery, type IAuthenticateResponse, UsersClient } from '@/clients';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new UsersClient(baseUrl);

interface IUserState {
    user: IAuthenticateResponse | null,
    returnUrl: string | null
}

export const useAuthStore = defineStore({
    id: 'auth',
    state: (): IUserState => {
        const storedUser = localStorage.getItem('user');
        return {
            user: typeof (storedUser) === 'string' ? JSON.parse(storedUser) : null,
            returnUrl: null
        }
    },
    actions: {
        async login(query: IAuthenticateQuery) {
            try {
                const user = await client.authenticate(new AuthenticateQuery(query));
                this.user = user;
                localStorage.setItem('user', JSON.stringify(user));
                router.push(this.returnUrl || '/announcement/list');
            } catch (error) { 
                const alertStore = useAlertStore();
                alertStore.error(getErrorMessage(error));
            }
        },
        logout() {
            this.user = null;
            localStorage.removeItem('user');
            router.push('/announcement/list');
        }
    }
});