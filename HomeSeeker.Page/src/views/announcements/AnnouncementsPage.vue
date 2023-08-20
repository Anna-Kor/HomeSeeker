<script setup lang="ts">
    import { ref } from 'vue';
    import { QSpinner } from 'quasar';
    import { getErrorMessage } from '@/helpers';
    import { useAlertStore } from '@/stores';
    import AnnouncementsListVue from '@/components/announcements/AnnouncementsList.vue';
    import { type IHomeModel, HomesClient } from '@/clients';

    const isLoading = ref(true);
    let homes = ref(undefined as IHomeModel[] | undefined);

    try {
        isLoading.value = true;
        const baseUrl = `${import.meta.env.VITE_API_URL}`;
        const client = new HomesClient(baseUrl);
        client.getActive().then(response => homes.value = response);
    } catch (error) {
        const alertStore = useAlertStore();
        alertStore.error(getErrorMessage(error));
    } finally {
        isLoading.value = false;
    }
</script>

<template>
    <div style="flex: 0 1 1000px">
        <q-spinner color="white" v-if="isLoading" />
        <AnnouncementsListVue v-else :items="homes" />
    </div>
</template>