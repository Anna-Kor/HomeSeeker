<script setup lang="ts">
    import { Field } from "vee-validate";
    import { QInput } from "quasar";

    const props = defineProps < {
        label: string,
        name: string,
        type?: "number" | "text" | "password" | "textarea" | "email" | "search" | "tel" | "file" | "url" | "time" | "date" | undefined
    } > ();
</script>

<template>
    <Field class="q-py-lg" :name="props.name" v-slot="{ value, field, errors }">
        <q-input :model-value="value"
                 v-bind="field"
                 :type="props.type"
                 :label="props.label"
                 :error="!!errors[0]"
                 :error-message="errors[0]"
                 :class="{ 'is-invalid': value }" />
    </Field>
</template>