import AccountLayoutVue from '@/views/account/AccountLayout.vue';
import LoginPageVue from '@/views/account/LoginPage.vue';
import RegisterPageVue from '@/views/account/RegisterPage.vue';

export default {
    path: '/account',
    component: AccountLayoutVue,
    children: [
        { path: '', redirect: 'login' },
        { path: 'login', component: LoginPageVue },
        { path: 'register', component: RegisterPageVue }
    ]
};