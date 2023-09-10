<script setup lang="ts">
    import { ref } from 'vue';
    import { storeToRefs } from 'pinia';

    import { type IHomeModel } from '@/clients';
    import { useAnnouncementsStore } from '@/stores';

    import MyAnnouncementsListVue from '@/components/announcements/MyAnnouncementsList.vue';
    import { QSpinner } from 'quasar';

    const announcementsStore = useAnnouncementsStore();
    const { homes } = storeToRefs(announcementsStore);

    const isLoading = ref(true);

    isLoading.value = true;
    announcementsStore.getByUser().then(() => {
        isLoading.value = false;
    });
</script>

<template>
    <div style="flex: 0 1 1000px">
        <q-spinner class="fixed-center" color="white" size="4em" v-if="isLoading" />
        <MyAnnouncementsListVue v-else :items="(homes as IHomeModel[] | undefined)" />
    </div>
</template>