import { createRouter, createWebHistory } from 'vue-router';

import { useAuthStore, useAlertStore } from '@/stores';
import accountRoutes from './account.routes';
import announcementDisplayRoutes from './announcement-display.routes';
import announcementOperationsRoutes from './announcement-operations.routes';

export const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes: [
        { path: '/', redirect: 'announcement/list' },
        { ...announcementDisplayRoutes },
        { ...announcementOperationsRoutes },
        { ...accountRoutes },
        { path: '/:pathMatch(.*)*', redirect: 'announcement/list' }
    ]
});

router.beforeEach(async (to) => {
    const alertStore = useAlertStore();
    alertStore.clear();

    const publicPages = ['/', '/announcement/details', '/announcement/list', '/account/login', '/account/register'];
    const authRequired = !publicPages.includes(to.path);
    const authStore = useAuthStore();

    if (authRequired && !authStore.user) {
        authStore.returnUrl = to.fullPath;
        return '/account/login';
    }
});