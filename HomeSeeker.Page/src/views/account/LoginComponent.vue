<script setup lang="ts">

import { Form } from 'vee-validate';
import { QBtn, QLayout } from 'quasar';
import QInputWithValidationVue from "@/components/QInputWithValidation.vue";

import * as Yup from 'yup';
import { type IAuthenticateQuery } from '@/clients';
import { useAuthStore } from '@/stores';

function getSubmitFn<IAuthenticateQuery extends Yup.ObjectSchema<Record<string, any>>>(
  _: IAuthenticateQuery,
  callback: (values: Yup.InferType<IAuthenticateQuery>) => void
) {
  return (values: Record<string, any>) => {
    return callback(values);
  };
}

const schema = Yup.object().shape({
    username: Yup.string().required('Username is required'),
    password: Yup.string().required('Password is required')
});

const onSubmit = getSubmitFn(schema, async (values: IAuthenticateQuery) => {
    const authStore = useAuthStore();
    const { username, password } = values;
    await authStore.login(username, password);
});
</script>


<template>
  <q-layout container style="height: 380px" class="shadow-2 rounded-borders">
  <Form class="q-pa-lg" @submit="onSubmit" :validation-schema="schema" v-slot="{ isSubmitting }" >
    <h4 class="q-py-lg">Login</h4>
    
    <QInputWithValidationVue label="Username" name="username" type="text" />
    <QInputWithValidationVue label="Password" name="password" type="password" />

    <div class="q-py-lg">
      <q-btn label="Login" type="submit" color="primary" :disabled="isSubmitting" />
      <q-btn to="register" label="Register" color="primary" flat class="q-ml-sm" />
    </div>
  </Form>
</q-layout>
  </template>