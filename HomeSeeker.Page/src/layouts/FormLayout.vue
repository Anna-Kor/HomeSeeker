<script setup lang="ts">
    import { QPage } from 'quasar';
    import DefaultLayoutVue from '@/layouts/DefaultLayout.vue';
</script>

<template>
    <DefaultLayoutVue>
        <q-page style="display: flex; flex-wrap: wrap; align-items: center; justify-content: center;">
            <div style="flex: initial;" class="q-pa-md q-gutter-sm">
                <div class="container shadow-2 rounded-borders">
                    <router-view />
                </div>
            </div>
        </q-page>
    </DefaultLayoutVue>
</template>