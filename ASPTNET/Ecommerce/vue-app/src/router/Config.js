import { createRouter, createWebHistory } from 'vue-router'
import { privateRoutes } from './privateRoutes'
import { publicRoutes } from './publicRoutes'

const router = createRouter({
  history: createWebHistory(),
  routes: [...privateRoutes, ...publicRoutes]
})

export default router