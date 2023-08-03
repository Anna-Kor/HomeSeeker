import { defineStore } from 'pinia';

export type Alert = {
    message: string | null;
    type: string
};

export const useAlertStore = defineStore({
    id: 'alert',
    state: () => ({
        alert: null as Alert | null
    }),
    actions: {
        success(message: string) {
            this.alert = { message, type: 'alert-success' };
        },
        error(message: string) {
            this.alert = { message, type: 'alert-danger' };
        },
        clear() {
            this.alert = null;
        }
    }
});