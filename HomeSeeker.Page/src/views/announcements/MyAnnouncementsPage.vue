<script setup lang="ts">
    import { ref } from 'vue';
    import { storeToRefs } from 'pinia';

    import { getErrorMessage } from '@/helpers';
    import { useAlertStore, useAuthStore } from '@/stores';
    import { type IHomeModel, HomesClient } from '@/clients';

    import MyAnnouncementsListVue from '@/components/announcements/MyAnnouncementsList.vue';
    import { QSpinner } from 'quasar';

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    const isLoading = ref(true);
    let homes = ref(undefined as IHomeModel[] | undefined);

    try {
        isLoading.value = true;
        const baseUrl = `${import.meta.env.VITE_API_URL}`;
        const client = new HomesClient(baseUrl);
        client.setAuthToken(user.value?.token || undefined);
        client.getByUser().then((response) => {
            homes.value = response;
            isLoading.value = false;
        });
    } catch (error) {
        const alertStore = useAlertStore();
        alertStore.error(getErrorMessage(error));
    }
</script>

<template>
    <div style="flex: 0 1 1000px">
        <q-spinner class="fixed-center" color="white" size="4em" v-if="isLoading" />
        <MyAnnouncementsListVue v-else :items="homes" />
    </div>
</template>