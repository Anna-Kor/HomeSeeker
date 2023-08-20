<script setup lang="ts">
    import { QPage } from 'quasar';
    import DefaultLayoutVue from '@/layouts/DefaultLayout.vue';
</script>

<template>
    <DefaultLayoutVue>
        <q-page style="display: flex; align-items: center; justify-content: center;">
            <router-view />
        </q-page>
    </DefaultLayoutVue>
</template>
