<script setup lang="ts">
    import { useAuthStore, useThemeStore } from '@/stores';
    import { storeToRefs } from 'pinia';
    import { QAvatar, QBtn, QToggle, QToolbar, QSpace } from 'quasar';

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    const themeStore = useThemeStore();
    const { theme } = storeToRefs(themeStore);
</script>

<template>
    <div class="q-pa-md">
        <q-toolbar>
            <q-btn round to="/announcement/list">
               <q-avatar rounded size="50px">
                   <img src="@/assets/icons/magnifying-glass-front-house-icon-600w-577307164.png" />
               </q-avatar>
            </q-btn>
            <q-space />
            <q-toggle 
                    :model-value="theme"
                    @update:model-value="themeStore.changeTheme()"
                    class="q-px-md"
                    size="lg"
                    color="blue"
                    keep-color
                    true-value="dark-theme"
                    false-value="light-theme"
                    checked-icon="dark_mode"
                    unchecked-icon="light_mode"/>
            <q-btn v-if="user" flat @click="authStore.logout()">Logout</q-btn>
            <q-btn v-else to="/account/login" flat >Login</q-btn>
        </q-toolbar>
    </div>
</template>