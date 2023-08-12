<script setup lang="ts">
    import AlertItemVue from '@/components/AlertItem.vue';
    import NavItemVue from '@/components/NavItem.vue';
    import { QHeader, QLayout, QPageContainer } from 'quasar';
</script>

<template>
    <q-layout>
        <q-header class="glossy">
            <NavItemVue />
        </q-header>
        <q-page-container >
            <AlertItemVue />
            <router-view></router-view>
        </q-page-container>
    </q-layout>
</template>

<style>
@import '@/assets/base.css';
</style>