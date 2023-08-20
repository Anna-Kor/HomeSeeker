<script setup lang="ts">
    import { QLayout, QPage } from 'quasar';
    import DefaultLayoutVue from '@/layouts/DefaultLayout.vue';
</script>

<template>
    <DefaultLayoutVue>
        <q-page style="display: flex; flex-wrap: wrap; align-items: center; justify-content: center;">
            <div style="flex: initial; width: 400px;">
                <div container class="shadow-2 rounded-borders">
                    <router-view />
                </div>
            </div>
        </q-page>
    </DefaultLayoutVue>
</template>