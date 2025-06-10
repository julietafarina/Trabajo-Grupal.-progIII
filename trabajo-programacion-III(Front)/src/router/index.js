import FormView from '@/views/FormView.vue'
import HistoryView from '@/views/HistoryView.vue'
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'form',
      component: FormView,
    },
    {
      path: '/historial',
      name: 'historial',
      component: HistoryView,
    },
  ],
})

export default router
