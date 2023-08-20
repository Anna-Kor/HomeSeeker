<script setup lang="ts">
    import { QPage } from 'quasar';
</script>

<template>
    <q-page style="display: flex; align-items: center; justify-content: center;">
        <div style="flex: 0 1 1000px">
            <router-view />
        </div>
    </q-page>
</template>