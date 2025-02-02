<template>
  <div class="wrapper-buy">
    <div class="product-page">
      <div class="product-image">
        <img src="../assets/sharedImage.jpg" :alt="product.nome" />
      </div>
      <div class="product-details">
        <h1>{{ product.nome }}</h1>
        <p class="price">Preço unitário: R$ {{ product.preco.toFixed(2) }}</p>
        <p class="total-price">
          Preço total: R$ {{ (product.preco * quantity).toFixed(2) }}
        </p>
        <div class="quantity-selector">
          <button @click="decrementQuantity" :disabled="quantity <= 1">
            -
          </button>
          <input
            type="number"
            v-model="quantity"
            :max="product.quantidade"
            readonly
          />
          <button
            @click="incrementQuantity"
            :disabled="quantity >= product.quantidade"
          >
            +
          </button>
        </div>
        <p class="stock">Quantidade em estoque: {{ product.quantidade }}</p>
        <p class="description">{{ product.descricao }}</p>
        <div class="payment-methods">
          <label
            ><input
              type="radio"
              name="payment"
              value="credit"
              v-model="paymentMethod"
            />
            Crédito</label
          >
          <label
            ><input
              type="radio"
              name="payment"
              value="debit"
              v-model="paymentMethod"
            />
            Débito</label
          >
        </div>
        <button @click="finalizePurchase">Finalizar Compra</button>
      </div>
    </div>
  </div>
</template>

<script>
import { PurchaseRequest } from "../Services/PurchaseRoutes";

export default {
  name: "PageBuy",
  data() {
    return {
      product: {
        nome: "",
        preco: 0,
        quantidade: 0,
        descricao: "",
      },
      quantity: 1,
      paymentMethod: "credit",
    };
  },
  created() {
    const state = history.state;
    if (state && state.productData) {
      this.product = state.productData;
    } else {
      this.$router.push({ name: "PageProducts" });
    }
  },
  methods: {
    incrementQuantity() {
      if (this.quantity < this.product.quantidade) {
        this.quantity++;
      }
    },
    decrementQuantity() {
      if (this.quantity > 1) {
        this.quantity--;
      }
    },
    async finalizePurchase() {
      try {
        const response = await PurchaseRequest(
          this.product.id,
          this.quantity,
          this.product.preco * this.quantity,
          false,
          new Date(),
          new Date()
        );
        alert(`Seu Pagamento esta sendo processado. Aguarde..`);
        console.log(response);
      } catch (error) {
        console.log(error);
      }
      this.$router.push({ name: "PageProducts" });
    },
  },
};
</script>

<style scoped>
.wrapper-buy {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 50px;
}
.product-page {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  padding: 50px;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 6px 20px rgba(0, 0, 0, 0.15);
  margin: 30px auto;
  max-width: 960px;
}

.product-image img {
  width: 400px;
  height: auto;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  margin-right: 10px;
}

.product-details {
  padding-left: 50px;
  border-left: 3px solid #f0f0f0;
}

.quantity-selector {
  display: flex;
  align-items: center;
  margin: 20px 0;
}

.quantity-selector button {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 0;
  font-size: 20px;
  cursor: pointer;
  border-radius: 50%;
  width: 35px;
  height: 35px;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: background-color 0.3s, transform 0.2s;
}

.quantity-selector button:hover {
  background-color: #0056b3;
  transform: scale(1.1);
}

.quantity-selector button:active {
  transform: scale(0.9);
}

.quantity-selector input {
  width: 60px;
  text-align: center;
  margin: 0 15px;
  font-size: 16px;
  border: 2px solid #ccc;
  border-radius: 8px;
  background: #f9f9f9;
}

.price,
.total-price {
  color: #e85555;
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 15px;
}

.stock,
.description {
  color: #666;
  font-size: 16px;
  margin-bottom: 20px;
}

.payment-methods label {
  font-size: 16px;
  color: #444;
  margin-right: 20px;
}

button {
  background-color: #28a745;
  color: white;
  border: none;
  padding: 12px 24px;
  font-size: 18px;
  cursor: pointer;
  border-radius: 8px;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #218838;
}
</style>
