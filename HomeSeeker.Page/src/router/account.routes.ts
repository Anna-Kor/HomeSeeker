import FormLayoutVue from '@/layouts/FormLayout.vue';
import LoginPageVue from '@/views/account/LoginPage.vue';
import RegisterPageVue from '@/views/account/RegisterPage.vue';

export default {
    path: '/account',
    component: FormLayoutVue,
    children: [
        { path: '', redirect: 'login' },
        { path: 'login', component: LoginPageVue },
        { path: 'register', component: RegisterPageVue }
    ]
};