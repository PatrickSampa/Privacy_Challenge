<template>
  <div class="product-card" @click="goToProductPage">
    <img src="../../assets/sharedImage.jpg" class="product-image" />
    <div class="product-info">
      <h3 class="product-name">{{ product.nome }}</h3>
      <p class="product-price">R$ {{ product.preco.toFixed(2) }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProductsBoxComponents",
  props: {
    product: {
      type: Object,
      required: true,
    },
  },
  methods: {
    goToProductPage() {
      this.$router.push({
        name: "PageBuy",
        state: {
          productData: {
            id: this.product.id,
            nome: this.product.nome,
            preco: this.product.preco,
            descricao: this.product.descricao,
            quantidade: this.product.quantidade,
          },
        },
      });
    },
  },
};
</script>

<style scoped>
.product-card {
  width: 200px;
  border: 1px solid #ccc;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease-in-out;
  margin: 10px;
  display: inline-block;
  vertical-align: top;
}

.product-card:hover {
  transform: translateY(-5px);
  cursor: pointer;
}

.product-image {
  width: 100%;
  height: 150px;
  object-fit: cover;
}

.product-info {
  padding: 10px;
  text-align: center;
}

.product-name {
  font-size: 16px;
  color: #333;
  margin: 5px 0;
}

.product-price {
  font-size: 14px;
  color: #666;
  font-weight: bold;
}
</style>
