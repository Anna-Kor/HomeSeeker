<script setup lang="ts">
    import { QBtn, QImg, QItem, QItemSection, QItemLabel, QVirtualScroll } from 'quasar';
    import { type IHomeModel, type IDeleteHomeCommand, DeleteHomeCommand, HomeStatus } from '@/clients';
    import { router } from '@/router';
    import { useAnnouncementsStore } from '@/stores';

    const props = defineProps < {
        items: IHomeModel[] | undefined,
    }>();

    async function onClick(item: IHomeModel) {
        const announcementsStore = useAnnouncementsStore();
        await announcementsStore.delete(item.id as number);
    };
</script>

<template>
    <q-virtual-scroll :items="props.items" v-slot="{ item, index }" separator>
        <q-item spinner-color="white" style="height: 400px" :key="index" dense>
            <q-btn v-if="item.status != HomeStatus.Archived" square class="absolute z-top" color="red" text-color="white" label="Remove" @click="onClick(item)" />
            <q-img fit="cover" src="@/assets/no-image.png">
                <div v-if="item.status == HomeStatus.Archived" class="absolute-full text-body1 flex flex-center">
                    Archive
                </div>
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