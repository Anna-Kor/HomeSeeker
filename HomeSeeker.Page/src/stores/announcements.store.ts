import { defineStore } from 'pinia';
import { type IHomeModel, HomesClient } from '@/clients';
import { getErrorMessage } from '@/helpers';
import { useAlertStore } from '@/stores';

const baseUrl = `${import.meta.env.VITE_API_URL}`;
const client = new HomesClient(baseUrl);

interface IAnnouncementsState {
    homes: IHomeModel[] | null,
    maxPrice: number | null
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
            homes: null,
            maxPrice: null
        }
    },
    actions: {
        async getMaxPrice() {
            try {
                this.maxPrice = await client.getMaxPrice();
            } catch (error) {
                const alertStore = useAlertStore();
                alertStore.error(getErrorMessage(error));
            }
        },
        async getActive(query: IGetActiveHomesQuery) {
            try {
                this.homes = await client.getActive(query.name, query.priceFrom, query.priceTo, query.city);
            } catch (error) {
                const alertStore = useAlertStore();
                alertStore.error(getErrorMessage(error));
            }
        }
    }
});