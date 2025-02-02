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
    <button class="exit-button" @click="logout">SAIR</button>
  </div>
</template>

<script>
import HeaderComponent from "../components/HeaderComponent.vue";
import OrdersComponents from "../components/MyOrders/OrdersComponents.vue";
import { GetPayAll } from "../Services/GetPayAll";
import { VerifyIsLogin } from "../Help/VerifyIsLogin";

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
    logout() {
      localStorage.removeItem("user");
      this.$router.push({ name: "PageLogin" });
    },
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
    if (!VerifyIsLogin()) {
      this.$router.push({ name: "PageLogin" });
    }
    GetPayAll()
      .then((res) => {
        this.orders = res.reverse();
      })
      .finally(() => {
        this.loading = false;
      });
  },
};
</script>

<style scoped>
.exit-button {
  position: fixed;
  bottom: 20px;
  right: 20px;
  padding: 10px 20px;
  background-color: #dc3545;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  transition: background-color 0.3s;
}

.exit-button:hover {
  background-color: #c82333;
}
</style>
