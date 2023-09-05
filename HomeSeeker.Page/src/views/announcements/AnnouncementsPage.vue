<script setup lang="ts">
    import { onMounted, ref, watch } from 'vue';
    import { storeToRefs } from 'pinia';
    import { useRoute } from 'vue-router'

    import { useAnnouncementsStore, type IGetActiveHomesQuery } from '@/stores';
    import { router } from '@/router';

    import AnnouncementsListVue from '@/components/announcements/AnnouncementsList.vue';
    import { QBtn, QForm, QInput, QRange, QSpinner } from 'quasar';

    const route = useRoute()
    const announcementsStore = useAnnouncementsStore();
    const { homes, maxPrice } = storeToRefs(announcementsStore);

    const name = ref(route.query.name ?? null as string | null);
    const price = ref({
        min: route.query.priceFrom ?? 0 as number,
        max: route.query.priceTo ?? null as number | null
    });
    const city = ref(route.query.city ?? null as string | null);

    const isLoading = ref(true);

    onMounted(() => {
        fetchData();
        getMaxPrice();
    });
    watch(route, () => fetchData());

    function fetchData() {
        isLoading.value = true;
        announcementsStore.getActive({ name: name.value, priceFrom: price.value.min, priceTo: price.value.max, city: city.value } as IGetActiveHomesQuery).then(() => {
            isLoading.value = false;
        })
    };

    function getMaxPrice() {
        isLoading.value = true;
        announcementsStore.getMaxPrice().then(() => {
            isLoading.value = false;
            price.value.max = maxPrice.value;
        })
    };

    function onSubmit() {
        router.push({ path: 'list', query: { name: name.value, priceFrom: price.value.min, priceTo: price.value.max, city: city.value } });
    };

    function onReset() {
        router.push({ path: 'list' });
        name.value = null;
        price.value.min = 0;
        price.value.max = maxPrice.value;
        city.value = null;
    };
</script>

<template>
    <div style="flex: 0 1 1000px">
        <q-spinner class="fixed-center" color="white" size="4em" v-if="isLoading" />
        <div v-else>
            <q-form @submit="onSubmit"
                    @reset="onReset"
                    class="q-gutter-md">
                <q-input filled
                         v-model="name"
                         type="text"
                         label="Name" />
                <q-range v-model="price"
                         color="primary"
                         :min="0"
                         :max="maxPrice"
                         :left-label-value="'Price from: ' + price.min"
                         :right-label-value="'Price to: ' + price.max"
                         label-always />
                <div>
                    <q-btn label="Filter" type="submit" color="primary" />
                    <q-btn label="Remove filters" type="reset" color="primary" flat class="q-ml-sm" />
                </div>
            </q-form>
            <AnnouncementsListVue :items="homes" />
        </div>
    </div>
</template>