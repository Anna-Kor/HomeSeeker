<script setup lang="ts">
    import { useAuthStore, useThemeStore } from '@/stores';
    import { QAvatar, QBtn, QToggle, QToolbar, QSpace } from 'quasar';

    const authStore = useAuthStore();
    const themeStore = useThemeStore();
</script>

<template>
    <div v-show="authStore.user" class="q-pa-sm q-gutter-md">
        <q-toolbar class="q-my-md">
            <q-btn round to="/">
               <q-avatar rounded size="50px">
                   <img src="../assets/icons/magnifying-glass-front-house-icon-600w-577307164.png" />
               </q-avatar>
            </q-btn>
            <q-space />
            <q-btn flat>
                <q-toggle :model-value="themeStore.theme"
                          @update:model-value="themeStore.changeTheme()"
                          color="blue"
                          keep-color
                          true-value="dark-theme"
                          false-value="light-theme"
                          checked-icon="dark_mode"
                          unchecked-icon="light_mode"
                          class="q-btn-item" />
            </q-btn>
            <q-btn flat @click="authStore.logout()">Logout</q-btn>
        </q-toolbar>
    </div>
</template>