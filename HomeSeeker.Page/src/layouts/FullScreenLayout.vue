<script setup lang="ts">
    import { QPage } from 'quasar';
    import DefaultLayoutVue from '@/layouts/DefaultLayout.vue';
</script>

<template>
    <DefaultLayoutVue>
        <q-page style="display: flex; justify-content: center;">
            <router-view />
        </q-page>
    </DefaultLayoutVue>
</template>
