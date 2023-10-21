<script setup lang="ts">
    import { Form } from 'vee-validate';
    import * as Yup from 'yup';
    import { QBtn } from 'quasar';
    import QInputWithValidationVue from '@/components/quasar-extensions/QInputWithValidation.vue';

    import { type IRegisterUserCommand } from '@/clients';
    import { useUsersStore } from '@/stores';

    const schema = Yup.object().shape({
        firstName: Yup.string(),
        lastName: Yup.string(),
        username: Yup.string()
            .required('Username is required'),
        password: Yup.string()
            .required('Password is required')
            .min(6, 'Password must be at least 6 characters')
    });

    async function onSubmit(values: any) {
        try {
            schema.validateSync(values);
            const usersStore = useUsersStore();
            await usersStore.register(values as IRegisterUserCommand);
        } catch (error) {
            console.log(error);
        }
    };
</script>

<template>
    <Form class="q-pa-lg rounded-borders" style="width: 400px" @submit="onSubmit" :validation-schema="schema" v-slot="{ isSubmitting }">
        <h4 class="q-py-lg">Register</h4>

        <QInputWithValidationVue label="First name" name="firstName" type="text" />
        <QInputWithValidationVue label="Last name" name="lastName" type="text" />
        <QInputWithValidationVue label="Username" name="username" type="text" />
        <QInputWithValidationVue label="Password" name="password" type="password" />

        <div class="q-py-lg">
            <q-btn label="Register" type="submit" color="primary" :disabled="isSubmitting" />
            <q-btn to="login" label="Cancel" color="primary" flat class="q-ml-sm" />
        </div>
    </Form>
</template>