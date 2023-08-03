import AccountLayoutVue from '@/views/account/AccountLayout.vue';
import LoginComponentVue from '@/views/account/LoginComponent.vue';
import RegisterComponentVue from '@/views/account/RegisterComponent.vue';

export default {
    path: '/account',
    component: AccountLayoutVue,
    children: [
        { path: '', redirect: 'login' },
        { path: 'login', component: LoginComponentVue },
        { path: 'register', component: RegisterComponentVue }
    ]
};