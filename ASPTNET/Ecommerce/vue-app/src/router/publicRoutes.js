import PageLogin from '../pages/PageLogin.vue';
import PageRegister from '../pages/PageRegister.vue';

export const publicRoutes = [
  {
    path: '/',
    name: 'PageLogin',
    component: PageLogin
  },
  {
    path: '/register',
    name: 'PageRegister',
    component: PageRegister
  }
]