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
            <q-item clickable flat v-close-popup>
                <q-item-section>Add home</q-item-section>
            </q-item>
            <q-item clickable flat v-close-popup to="/announcement/myHomesList">
                <q-item-section>My homes</q-item-section>
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