<script setup lang="ts">
    import { QImg, QItem, QItemSection, QItemLabel, QVirtualScroll } from 'quasar';
    import { type IHomeModel } from '@/clients';
    import { router } from '@/router';

    const props = defineProps < {
        items: IHomeModel[] | undefined,
    }>();

    function onClick(item: IHomeModel) {
        router.push({ name: 'announcementDetails', params: { id: item.id as number } });
    };
</script>

<template>
    <q-virtual-scroll :items="props.items" v-slot="{ item, index }" separator>
        <q-item spinner-color="white" style="height: 400px" :key="index" dense clickable @click="onClick(item)">
            <q-img fit="cover" src="@/assets/no-image.png">
                <div class="absolute-bottom text-left">
                    <q-item>
                        <q-item-section>
                            <q-item-label>{{ item.name }}</q-item-label>
                            <q-item-label>${{ item.price || item.rent }}</q-item-label>
                        </q-item-section>
                        <q-item-section side>
                            <q-item-label>Rooms: {{ item.roomsQuantity }}</q-item-label>
                            <q-item-label>Bathrooms: {{ item.bathroomsQuantity }}</q-item-label>
                        </q-item-section>
                    </q-item>
                </div>
            </q-img>
        </q-item>
    </q-virtual-scroll>
</template>