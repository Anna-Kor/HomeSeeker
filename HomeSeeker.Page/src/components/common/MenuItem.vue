<script setup lang="ts">
    import { useAuthStore } from '@/stores';
    import { storeToRefs } from 'pinia';
    import { QItem, QItemSection, QList, QMenu, QSeparator } from 'quasar';

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);
</script> 

<template>
    <q-menu v-if="user">
        <q-list>
            <q-item clickable flat v-close-popup to="/announcement/addAnnouncement">
                <q-item-section>Add announcement</q-item-section>
            </q-item>
            <q-item clickable flat v-close-popup to="/announcement/myAnnouncements">
                <q-item-section>My announcements</q-item-section>
            </q-item>
            <q-separator />
            <q-item clickable flat v-close-popup @click="authStore.logout()">
                <q-item-section>Logout</q-item-section>
            </q-item>
        </q-list>
    </q-menu>
    <q-menu v-else>
        <q-list>
            <q-item clickable flat v-close-popup to="/account/login">
                <q-item-section>Login</q-item-section>
            </q-item>
        </q-list>
    </q-menu>
</template>