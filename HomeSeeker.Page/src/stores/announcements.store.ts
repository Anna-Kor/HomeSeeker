import { defineStore, storeToRefs } from 'pinia';
import { type IHomeModel, HomesClient } from '@/clients';
import { getErrorMessage } from '@/helpers';
import { useAlertStore, useAuthStore } from '@/stores';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new HomesClient(baseUrl);

interface IAnnouncementsState {
    home: IHomeModel | null,
    homes: IHomeModel[] | null,
    maxPrice: number | undefined
}

export interface IGetActiveHomesQuery {
    name: string | null,
    priceFrom: number | null,
    priceTo: number | null,
    city: string | null
}

export const useAnnouncementsStore = defineStore({
    id: 'announcements',
    state: (): IAnnouncementsState => {
        return {
            home: null,
            homes: null,
            maxPrice: undefined
        }
    },
    actions: {
        async getMaxPrice() {
            const alertStore = useAlertStore();
            try {
                this.maxPrice = await client.getMaxPrice();
            } catch (error) {
                alertStore.error(getErrorMessage(error));
            }
        },
        async getActive(query: IGetActiveHomesQuery) {
            const alertStore = useAlertStore();
            try {
                this.homes = await client.getActive(query.name, query.priceFrom, query.priceTo, query.city) as IHomeModel[];
            } catch (error) {
                alertStore.error(getErrorMessage(error));
            }
        },
        async getById(id: number) {
            const alertStore = useAlertStore();

            const authStore = useAuthStore();
            const { user } = storeToRefs(authStore);
            try {
                client.setAuthToken(user.value?.token || undefined);
                this.home = await client.getById(id) as IHomeModel;
            } catch (error) {
                alertStore.error(getErrorMessage(error));
            }
        },
        async getByUser() {
            const alertStore = useAlertStore();

            const authStore = useAuthStore();
            const { user } = storeToRefs(authStore);
            try {
                client.setAuthToken(user.value?.token || undefined);
                this.homes = await client.getByUser() as IHomeModel[];
            } catch (error) {
                alertStore.error(getErrorMessage(error));
            }
        }
    }
});