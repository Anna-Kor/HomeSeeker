<script setup lang="ts">
import AlertItemVue from '@/components/AlertItem.vue';
import NavItemVue from '@/components/NavItem.vue';
import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
</script>

<template>
    <div class="app-container" :class="authStore.user && 'bg-light'">
        <NavItemVue />
        <AlertItemVue />
        <div class="container pt-4 pb-4">
            <router-view></router-view>
        </div>
    </div>
</template>

<style>
@import '@/assets/base.css';
</style>