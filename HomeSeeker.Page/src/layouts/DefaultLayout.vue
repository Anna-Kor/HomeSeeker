<script setup lang="ts">
    import AlertItemVue from '@/components/common/AlertItem.vue';
    import NavItemVue from '@/components/common/NavItem.vue';
    import { QHeader, QLayout, QPage, QPageContainer } from 'quasar';
</script>

<template>
    <q-layout>
        <q-header reveal class="glossy">
            <NavItemVue />
        </q-header>
        <q-page-container>
            <AlertItemVue />
            <slot />
        </q-page-container>
    </q-layout>
</template>