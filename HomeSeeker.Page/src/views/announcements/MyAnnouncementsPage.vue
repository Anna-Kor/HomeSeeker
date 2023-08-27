<script setup lang="ts">
    import { ref } from 'vue';
    import { QSpinner } from 'quasar';
    import { getErrorMessage } from '@/helpers';
    import { useAlertStore, useAuthStore } from '@/stores';
    import { storeToRefs } from 'pinia';
    import AnnouncementsListVue from '@/components/announcements/AnnouncementsList.vue';
    import { type IHomeModel, HomesClient } from '@/clients';

    const isLoading = ref(true);
    let homes = ref(undefined as IHomeModel[] | undefined);

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    try {
        isLoading.value = true;
        const baseUrl = `${import.meta.env.VITE_API_URL}`;
        const client = new HomesClient(baseUrl);
        if (user.value != null) {
            client.getByUserId(user.value.id).then((response) => {
                homes.value = response;
                isLoading.value = false;
            });
        }
    } catch (error) {
        const alertStore = useAlertStore();
        alertStore.error(getErrorMessage(error));
    }
</script>

<template>
    <div style="flex: 0 1 1000px">
        <q-spinner class="fixed-center" color="white" size="4em" v-if="isLoading" />
        <AnnouncementsListVue v-else :items="homes" />
    </div>
</template>