import FullScreenLayoutVue from '@/layouts/FullScreenLayout.vue';
import AnnouncementsPageVue from '@/views/announcements/AnnouncementsPage.vue';

export default {
    path: '/announcement',
    component: FullScreenLayoutVue,
    children: [
        { path: '', redirect: 'list' },
        { path: 'list', component: AnnouncementsPageVue }
    ]
};