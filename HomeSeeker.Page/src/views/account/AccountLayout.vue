<script setup lang="ts">
import { useAuthStore } from '@/stores';
import { router } from '@/router';
import { QPage } from 'quasar';

const authStore = useAuthStore();
if (authStore.user) {
    router.push('/announcement/list');
}
</script>

<template>
    <q-page style="display: flex; align-items: center; justify-content: center;">
        <div style="flex: 0 1 400px">
            <router-view />
        </div>
    </q-page>
</template>