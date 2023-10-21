<script setup lang="ts">
    import { toRef } from 'vue';
    import { useField } from "vee-validate";
    import { QInput } from "quasar";

    const props = defineProps < {
        label: string,
        name: string,
        type?: string | undefined
    }>();

    const { errorMessage, value } = useField(toRef(props, 'name'));
</script>

<template>
    <q-input
            v-model="value"
            :type="props.type"
            :label="props.label"
            :error="!!errorMessage"
            :error-message="errorMessage" />
</template>