import Vue from 'vue';
import Router from 'vue-router';
import Home from '../components/HelloWorld.vue';
import PageLogin from '../pages/PageLogin.vue';
import PageRegister from '../pages/PageRegister.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/Home',
      name: 'Home',
      component: Home
    },
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
});