<script setup lang="ts">
    import { onMounted, ref, watch } from 'vue';
    import { storeToRefs } from 'pinia';
    import { useRoute } from 'vue-router'

    import { type IHomeModel } from '@/clients';
    import { useAnnouncementsStore, type IGetActiveHomesQuery } from '@/stores';
    import { router } from '@/router';

    import AnnouncementsListVue from '@/components/announcements/AnnouncementsList.vue';
    import { QBtn, QForm, QInput, QRange, QSelect, QSpinner } from 'quasar';

    const route = useRoute()
    const announcementsStore = useAnnouncementsStore();
    const { homes, maxPrice } = storeToRefs(announcementsStore);

    const name = ref(route.query.name as string | null ?? null);
    const price = ref({
        min: route.query.priceFrom as number | null ?? 0,
        max: route.query.priceTo as number | null ?? null
    });
    const city = ref(route.query.city as string | null ?? null);

    const cities = [
        'Warszawa', 'Lublin', 'Rzeszów', 'Gdynia', 'Wrocław'
    ]

    const isLoading = ref(true);

    onMounted(() => {
        fetchData();
        getMaxPrice();
    });
    watch(route, () => fetchData());

    const filteredCities = ref(cities);

    function filterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredCities.value = cities
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredCities.value = cities.filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    }

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
            price.value.max = maxPrice.value as number | null;
        })
    };

    function onSubmit() {
        router.push({ path: 'list', query: { name: name.value, priceFrom: price.value.min, priceTo: price.value.max, city: city.value } });
    };

    function onReset() {
        router.push({ path: 'list' });
        name.value = null;
        price.value.min = 0;
        price.value.max = maxPrice.value as number | null;
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
                <q-select filled
                          use-input
                          input-debounce="0"
                          v-model="city"
                          :options="filteredCities"
                          label="City"
                          @filter="filterFn"
                          behavior="menu" />
                <div>
                    <q-btn label="Filter" type="submit" color="primary" />
                    <q-btn label="Remove filters" type="reset" color="primary" flat class="q-ml-sm" />
                </div>
            </q-form>
            <AnnouncementsListVue :items="(homes as IHomeModel[] | undefined)" />
        </div>
    </div>
</template>