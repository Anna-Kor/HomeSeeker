<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { useAuthStore } from '@/stores';

const authStore = useAuthStore();
const { user } = storeToRefs(authStore);
</script>

<template>
    <div v-if="user">
        <h4>Hi {{user.username}}!</h4>
    </div>
    <div v-else>
        <h4>You are not logged in!</h4>
    </div>
</template>