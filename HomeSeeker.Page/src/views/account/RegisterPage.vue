<script setup lang="ts">
    import { Form } from 'vee-validate';
    import * as Yup from 'yup';
    import { QBtn, QLayout } from 'quasar';
    import QInputWithValidationVue from '@/components/common/QInputWithValidation.vue';

    import { type IRegisterUserCommand } from '@/clients';
    import { useUsersStore } from '@/stores';

    function getSubmitFn<IRegisterUser extends Yup.ObjectSchema<Record<string, any>>>(
      _: IRegisterUser,
      callback: (values: Yup.InferType<IRegisterUser>) => void
    ) {
      return (values: Record<string, any>) => {
        return callback(values);
      };
    }

    const schema = Yup.object().shape({
        firstName: Yup.string()
            .required('First name is required'),
        lastName: Yup.string()
            .required('Last name is required'),
        username: Yup.string()
            .required('Username is required'),
        password: Yup.string()
            .required('Password is required')
            .min(6, 'Password must be at least 6 characters')
    });

    const onSubmit = getSubmitFn(schema, async (values: IRegisterUserCommand) => {
        const usersStore = useUsersStore();
        await usersStore.register(values);
    });
</script>

<template>
    <q-layout container style="height: 550px" class="shadow-2 rounded-borders">
    <Form class="q-pa-lg" @submit="onSubmit" :validation-schema="schema" v-slot="{ isSubmitting }">
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
    </q-layout>
</template>