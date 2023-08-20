<script setup lang="ts">
    import AlertItemVue from '@/components/common/AlertItem.vue';
    import NavItemVue from '@/components/common/NavItem.vue';
    import { QHeader, QLayout, QPageContainer } from 'quasar';
</script>

<template>
    <q-layout>
        <q-header class="glossy">
            <NavItemVue />
        </q-header>
        <q-page-container >
            <AlertItemVue />
            <router-view />
        </q-page-container>
    </q-layout>
</template>

<style>
@import '@/assets/base.css';
</style>