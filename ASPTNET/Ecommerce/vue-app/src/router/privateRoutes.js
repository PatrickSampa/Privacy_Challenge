import PageProducts from '../pages/PageProducts.vue';
import PageBuy from '../pages/PageBuy.vue';
import PageMyOrders from '../pages/PageMyOrders.vue';

export const privateRoutes = [
  {
    path: '/Home/Products',
    name: 'PageProducts',
    component: PageProducts
  },
  {
    path: '/Home/Buy',
    name: 'PageBuy',
    component: PageBuy,
    props: true
  },
  {
    path: '/Home/MyOrders',
    name: 'PageMyOrders',
    component: PageMyOrders,
    props: true
  }
]

