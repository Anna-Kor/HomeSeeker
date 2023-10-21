import FullScreenLayoutVue from '@/layouts/FullScreenLayout.vue';
import FormLayoutVue from '@/layouts/FormLayout.vue';
import AddAnnouncementPageVue from '@/views/announcements/AddAnnouncementPage.vue';

export default {
    path: '/announcement',
    component: FormLayoutVue,
    children: [
        { path: 'addAnnouncement', component: AddAnnouncementPageVue }
    ]
};