import FullScreenLayoutVue from '@/layouts/FullScreenLayout.vue';
import AnnouncementsPageVue from '@/views/announcements/AnnouncementsPage.vue';
import AnnouncementDetailsPageVue from '@/views/announcements/AnnouncementDetailsPage.vue';

export default {
    path: '/announcement',
    component: FullScreenLayoutVue,
    children: [
        { path: '', redirect: 'list' },
        { path: 'list', component: AnnouncementsPageVue },
        { path: 'details/:id', name: 'announcementDetails', component: AnnouncementDetailsPageVue, props: true }
    ]
};