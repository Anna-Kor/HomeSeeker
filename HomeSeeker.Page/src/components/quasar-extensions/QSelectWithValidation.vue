<script setup lang="ts">
    import { ref, toRef } from 'vue';
    import { useField } from "vee-validate";
    import { QSelect } from "quasar";

    const props = defineProps < {
        label: string,
        name: string,
        options: Array<string>
    }>();

    const { errorMessage, value } = useField(toRef(props, 'name'));
    const filteredOptions = ref(props.options);

    function filterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredOptions.value = props.options
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredOptions.value = props.options.filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    }
</script>

<template>
    <q-select
            filled
            use-input
            input-debounce="0"
            v-model="value"
            :options="filteredOptions"
            :label="props.label"
            @filter="filterFn"
            behavior="menu"
            :error="!!errorMessage"
            :error-message="errorMessage" />
</template>