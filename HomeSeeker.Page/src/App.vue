<script setup lang="ts">
import AlertItemVue from '@/components/AlertItem.vue';
import NavItemVue from '@/components/NavItem.vue';
    import { useAuthStore } from '@/stores';
    import { QHeader, QLayout, QPageContainer } from 'quasar';

const authStore = useAuthStore();
</script>

<template>
    <q-layout>
        <q-header class="glossy">
            <NavItemVue />
        </q-header>
        <q-page-container>
            <AlertItemVue />
            <div class="container pt-4 pb-4">
                <router-view></router-view>
            </div>
        </q-page-container>
    </q-layout>
</template>

<style>
@import '@/assets/base.css';
</style>