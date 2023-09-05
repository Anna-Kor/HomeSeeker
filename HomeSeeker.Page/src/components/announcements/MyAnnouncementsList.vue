<script setup lang="ts">
    import { QImg, QItem, QItemSection, QItemLabel, QVirtualScroll } from 'quasar';
    import { type IHomeModel } from '@/clients';

    const props = defineProps < {
        items: IHomeModel[] | undefined,
    }>();
</script>

<template>
    <q-virtual-scroll :items="props.items" v-slot="{ item, index }" separator>
        <q-item spinner-color="white" style="height: 400px" :key="index" dense>
            <q-img fit="cover" src="@/assets/no-image.png">
                <div class="absolute-bottom text-left">
                    <q-item>
                        <q-item-section>
                            <q-item-label>{{ item.name }}</q-item-label>
                            <q-item-label>{{ item.price || item.rent }} PLN</q-item-label>
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