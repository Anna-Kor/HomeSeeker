<script setup lang="ts">
    import { QImg, QItem, QItemSection, QItemLabel, QVirtualScroll } from 'quasar';
    import { type IHomeModel } from '@/clients';

    const props = defineProps < {
        items: IHomeModel[] | undefined,
    } > ();
</script>

<template>
    <q-virtual-scroll :items="props.items" v-slot="{ item, index }" separator>
        <q-item spinner-color="white" :key="index" dense clickable>
            <q-img src="@/assets/no-image.png">
                <div class="absolute-bottom text-left">
                    <q-item>
                        <q-item-section>
                            <q-item-label>{{ item.name }}</q-item-label>
                            <q-item-label caption>{{ item.price || item.rent }}</q-item-label>
                        </q-item-section>
                        <q-item-section side>
                            <q-item-label caption>Rooms: {{ item.roomsQuantity }}</q-item-label>
                            <q-item-label caption>Bathrooms: {{ item.bathroomsQuantity }}</q-item-label>
                        </q-item-section>
                    </q-item>
                </div>
            </q-img>
        </q-item>
    </q-virtual-scroll>
</template>