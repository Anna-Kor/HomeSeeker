<script setup lang="ts">
import { Form, Field } from 'vee-validate';
import * as Yup from 'yup';
import { QBtn, QInput, QLayout } from 'quasar';

import { type IRegisterUserCommand } from '@/clients';
import { getErrorMessage } from '@/helpers';
import { useUsersStore, useAlertStore } from '@/stores';
import { router } from '@/router';

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
        .required('First Name is required'),
    lastName: Yup.string()
        .required('Last Name is required'),
    username: Yup.string()
        .required('Username is required'),
    password: Yup.string()
        .required('Password is required')
        .min(6, 'Password must be at least 6 characters')
});

const onSubmit = getSubmitFn(schema, async (values: IRegisterUserCommand) => {
    const usersStore = useUsersStore();
    const alertStore = useAlertStore();
    try {
        await usersStore.register(values);
        await router.push('/account/login');
        alertStore.success('Registration successful');
    } catch (error) { 
        alertStore.error(getErrorMessage(error));
    }
});
</script>

<template>
    <q-layout container style="height: 550px" class="shadow-2 rounded-borders">
    <Form class="q-pa-lg" @submit="onSubmit" :validation-schema="schema" v-slot="{ isSubmitting }">
        <h4 class="q-py-lg">Register</h4>

        <Field class="q-py-lg" name="firstName" v-slot="{ value, field, errors }" >
            <q-input
            :model-value="value"
            v-bind="field"
            type="text"
            label="First Name"
            :error="!!errors[0]"
            :error-message="errors[0]"
            :class="{ 'is-invalid': value }"/>
        </Field>

        <Field class="q-py-lg" name="lastName" v-slot="{ value, field, errors }" >
            <q-input
            :model-value="value"
            v-bind="field"
            type="text"
            label="Last Name"
            :error="!!errors[0]"
            :error-message="errors[0]"
            :class="{ 'is-invalid': value }"/>
        </Field>

        <Field class="q-py-lg" name="username" v-slot="{ value, field, errors }" >
            <q-input
            :model-value="value"
            v-bind="field"
            type="text"
            label="Username"
            :error="!!errors[0]"
            :error-message="errors[0]"
            :class="{ 'is-invalid': value }"/>
        </Field>

        <Field class="q-py-lg" name="password" v-slot="{ value, field, errors }" >
            <q-input
            :model-value="value"
            v-bind="field"
            type="password"
            label="Password"
            :error="!!errors[0]"
            :error-message="errors[0]"
            :class="{ 'is-invalid': value }"/>
        </Field>

        <div class="q-py-lg">
            <q-btn label="Register" type="submit" color="primary" :disabled="isSubmitting" />
            <q-btn to="login" label="Cancel" color="primary" flat class="q-ml-sm" />
        </div>
    </Form>
    </q-layout>
</template>