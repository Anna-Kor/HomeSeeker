import AnnouncementsLayoutVue from '@/views/announcements/AnnouncementsLayout.vue';
import AnnouncementsPageVue from '@/views/announcements/AnnouncementsPage.vue';

export default {
    path: '/announcement',
    component: AnnouncementsLayoutVue,
    children: [
        { path: '', redirect: 'list' },
        { path: 'list', component: AnnouncementsPageVue }
    ]
};