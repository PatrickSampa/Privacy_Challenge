<template>
  <div class="order">
    <img
      src="../../assets/sharedImage.jpg"
      alt="Imagem do Produto"
      class="product-image"
    />
    <h2>{{ nome }}</h2>
    <p>Valor Total: R$ {{ order.priceTotal }}</p>
    <p>
      Data de Compra:
      {{ new Date(order.dateCreatedBuy).toLocaleDateString() }}
    </p>
    <p>Quantidade: {{ order.quantity }}</p>
    <p>
      Status do Pagamento:
      <span
        :class="{
          'status-label': true,
          'status-success': StatusProcess === 'Success',
          'status-canceled': StatusProcess === 'Canceled',
          'status-waiting': order.paymentCompleted === false,
        }"
        >{{
          order.paymentCompleted == false
            ? "Aguardando Pagamento"
            : StatusProcess
        }}</span
      >
    </p>
    <button v-if="order.paymentCompleted === false" @click="cancelOrder()">
      Cancelar Produto
    </button>
  </div>
</template>

<script>
import { GetProductId } from "../../Services/GetProductId";
import { GetPurchasingByIdProduct } from "../../Services/GetPurchasingByIdProduct";
import { CancelPay } from "../../Services/CancelPay";

export default {
  name: "OrdersComponents",
  props: {
    order: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      product: {
        name: "",
        price: "",
        quantity: "",
        total: "",
        date: "",
        id: "",
      },
      StatusProcess: "",
      nome: "",
      CurrentPurchansing: {},
    };
  },
  methods: {
    cancelOrder() {
      CancelPay(this.CurrentPurchansing)
        .then(() => {
          alert("Pedido cancelado com sucesso!");
        })
        .catch(() => {
          alert(
            "Pagamento já foi realizado. Pedido não pode ser cancelado no momento!"
          );
        })
        .finally(() => {
          window.location.reload();
        });
    },
    ToProducts() {
      this.$router.push({ name: "PageProducts" });
    },
  },
  mounted() {
    if (this.order.id) {
      GetProductId(this.order.productId).then((res) => {
        this.nome = res.nome;
      });
      GetPurchasingByIdProduct(this.order.id).then((res) => {
        this.CurrentPurchansing = res;
        this.StatusProcess = res.statusProcess;
      });
    }
  },
};
</script>

<style scoped>
.orders-page {
  max-width: 500px;
  margin: 0 auto;
  padding: 20px;
  font-family: Arial, sans-serif;
  color: #333;
}

.orders-page h1 {
  text-align: center;
  font-size: 2.5rem;
  margin-bottom: 20px;
  color: #2c3e50;
}

.order {
  background-color: #f9f9f9;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 20px;
  margin-bottom: 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: box-shadow 0.3s ease;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.order:hover {
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.product-image {
  max-width: 200px;
  border-radius: 8px;
  margin-bottom: 15px;
}

.order h2 {
  font-size: 1.5rem;
  margin-bottom: 10px;
  color: #34495e;
}

.order p {
  margin: 5px 0;
  font-size: 1rem;
  color: #555;
}

.status-label {
  padding: 5px 10px;
  border-radius: 4px;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 0.9rem;
}

.status-label.processando {
  background-color: #f39c12;
  color: #fff;
}

.status-label.aprovado {
  background-color: #2ecc71;
  color: #fff;
}

.status-label.cancelado {
  background-color: #e74c3c;
  color: #fff;
}

button {
  background-color: #3498db;
  color: #fff;
  border: none;
  padding: 10px 15px;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
  margin-top: 10px;
  transition: background-color 0.3s ease;
}

button:hover {
  background-color: #2980b9;
}

@media (max-width: 768px) {
  .orders-page {
    padding: 10px;
  }

  .order {
    padding: 15px;
  }

  .product-image {
    max-width: 80px;
  }

  .order h2 {
    font-size: 1.3rem;
  }

  .order p {
    font-size: 0.9rem;
  }

  button {
    font-size: 0.9rem;
    padding: 8px 12px;
  }
}

.status-label {
  padding: 5px 10px;
  border-radius: 4px;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 0.9rem;
}

.status-success {
  background-color: #2ecc71;
  color: #fff;
}

.status-canceled {
  background-color: #e74c3c;
  color: #fff;
}

.status-waiting {
  background-color: #f39c12;
  color: #fff;
}
</style>
