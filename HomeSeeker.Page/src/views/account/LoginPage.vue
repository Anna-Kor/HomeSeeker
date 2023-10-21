<script setup lang="ts">
    import { Form } from 'vee-validate';
    import { QBtn } from 'quasar';
    import QInputWithValidationVue from '@/components/quasar-extensions/QInputWithValidation.vue';

    import * as Yup from 'yup';
    import { type IAuthenticateQuery } from '@/clients';
    import { useAuthStore } from '@/stores';

    const schema = Yup.object().shape({
        username: Yup.string().required('Username is required'),
        password: Yup.string().required('Password is required')
    });

    async function onSubmit(values: any) {
        try {
            schema.validateSync(values);
            const authStore = useAuthStore();
            await authStore.login(values as IAuthenticateQuery);
        } catch (error) {
            console.log(error);
        }
    };
</script>


<template>
    <Form class="q-pa-lg rounded-borders" style="width: 400px" @submit="onSubmit" :validation-schema="schema" v-slot="{ isSubmitting }">
        <h4 class="q-py-lg">Login</h4>

        <QInputWithValidationVue label="Username" name="username" type="text" />
        <QInputWithValidationVue label="Password" name="password" type="password" />

        <div class="q-py-lg">
            <q-btn label="Login" type="submit" color="primary" :disabled="isSubmitting" />
            <q-btn to="register" label="Register" color="primary" flat class="q-ml-sm" />
        </div>
    </Form>
</template>