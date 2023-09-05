<script setup lang="ts">
    import { storeToRefs } from 'pinia';
    import { QBtn } from 'quasar';

    import { useAlertStore } from '@/stores';

    const alertStore = useAlertStore();
    const { alert } = storeToRefs(alertStore);
</script>

<template>
    <div v-if="alert">
        <div :class="alert.type">
            <q-btn roud flat icon="close" @click="alertStore.clear()"/>
            {{alert.message}}
        </div>
    </div>
</template>