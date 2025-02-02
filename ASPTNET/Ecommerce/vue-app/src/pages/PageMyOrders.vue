<template>
  <div class="orders-page-wrapper">
    <HeaderComponent />
    <div v-if="loading" class="loading">Carregando pedidos...</div>
    <div v-else-if="orders.length">
      <OrdersComponents
        v-for="order in orders"
        :key="order.id"
        :order="order"
      />
    </div>
    <div v-else class="no-orders">Nenhum pedido encontrado</div>
  </div>
</template>

<script>
import HeaderComponent from "../components/HeaderComponent.vue";
import OrdersComponents from "../components/MyOrders/OrdersComponents.vue";
import { GetPayAll } from "../Services/GetPayAll";

export default {
  name: "PageMyOrders",
  components: {
    HeaderComponent,
    OrdersComponents,
  },

  data() {
    return {
      orders: [],
      loading: true,
    };
  },
  methods: {
    cancelOrder(id) {
      const order = this.orders.find((o) => o.id === id);
      if (order && order.status === "Processando") {
        order.status = "Cancelado";
        alert("Pedido cancelado com sucesso!");
      }
    },
    ToProducts() {
      this.$router.push({ name: "PageProducts" });
    },
  },
  mounted() {
    GetPayAll()
      .then((res) => {
        this.orders = res;
      })
      .finally(() => {
        this.loading = false;
      });
  },
};
</script>

<style scoped></style>
