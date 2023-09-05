<script setup lang="ts">
    import { ref } from 'vue';
    import { storeToRefs } from 'pinia';
    import { getErrorMessage } from '@/helpers';
    import { useAlertStore, useAuthStore } from '@/stores';
    import { type IHomeModel, HomesClient, Category } from '@/clients';
    import { QImg, QItem, QItemLabel, QItemSection, QSeparator, QSpinner } from 'quasar';

    const props = defineProps<{
        id: Number,
    }>();

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    const isLoading = ref(true);
    let home = ref(undefined as IHomeModel | undefined);

    try {
        isLoading.value = true;
        const baseUrl = `${import.meta.env.VITE_API_URL}`;
        const client = new HomesClient(baseUrl);
        client.setAuthToken(user.value?.token || undefined);
        client.getById(Number(props.id)).then((response) => {
            home.value = response;
            isLoading.value = false;
        });
    } catch (error) {
        const alertStore = useAlertStore();
        alertStore.error(getErrorMessage(error));
    }
</script>

<template>
    <div class="container shadow-2 rounded-borders" style="flex: 0 1 1000px">
        <q-spinner color="white" v-if="isLoading" />
        <div v-else>
            <q-img fit="cover" src="@/assets/no-image.png"></q-img>
            <q-item class="q-pa-lg">
                <q-item-section top>
                    <h5 class="text-weight-medium">{{ home?.name }} | {{ home?.city }}</h5>
                </q-item-section>

                <q-item-section side top>
                    <h5 class="text-weight-medium">{{ home?.price || home?.rent }} PLN</h5>
                </q-item-section>
            </q-item>

            <q-item class="q-px-lg q-pb-lg">
                <q-item-section top>
                    <q-item-label>Living area: {{ home?.livingArea }} m<sup>2</sup></q-item-label>
                    <q-item-label v-if="home?.category == Category.House">Lot area: {{ home?.lotArea }} m<sup>2</sup></q-item-label>
                </q-item-section>

                <q-item-section side top>
                    <q-item-label v-if="home?.category == Category.House">Floors quantity: {{ home?.floorsQuantity }}</q-item-label>
                    <q-item-label v-else>Floor: {{ home?.floor }}</q-item-label>
                    <q-item-label>Furnished: {{ home?.hasFurniture ? "Yes" : "No" }}</q-item-label>
                    <q-item-label>Rooms: {{ home?.roomsQuantity }}</q-item-label>
                    <q-item-label>Bathrooms: {{ home?.bathroomsQuantity }}</q-item-label>
                </q-item-section>
            </q-item>

            <q-separator />

            <q-item class="q-pa-lg">
                <q-item-section>
                    <q-item-label>{{ home?.description }}</q-item-label>
                </q-item-section>
            </q-item>
        </div>
    </div>
</template>