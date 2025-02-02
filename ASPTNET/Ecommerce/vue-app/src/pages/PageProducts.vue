<template>
  <div>
    <HeaderComponent />
    <CategoryOptionComponent @categoryChanged="filterProducts" />
    <div class="container-products">
      <ProductsBoxComponents
        v-for="product in products"
        :key="product.id"
        :product="product"
      />
    </div>
    <button class="exit-button" @click="logout">SAIR</button>
  </div>
</template>

<script>
import HeaderComponent from "../components/HeaderComponent.vue";
import CategoryOptionComponent from "../components/Products/CategoryOptionComponent.vue";
import ProductsBoxComponents from "../components/Products/ProductsBoxComponents.vue";
import { GetProductsByCategory } from "../Services/GetProductsByCategory";
import { GetCategory } from "../Services/GetCategory";
import { VerifyIsLogin } from "../Help/VerifyIsLogin";

export default {
  name: "PageProducts",
  components: {
    HeaderComponent,
    CategoryOptionComponent,
    ProductsBoxComponents,
  },
  data() {
    return {
      products: [],
    };
  },
  methods: {
    logout() {
      localStorage.removeItem("user");
      this.$router.push({ name: "PageLogin" });
    },
    filterProducts(category) {
      if (category === "Todos") {
        this.products = this.getCategory();
      } else {
        this.products = this.getProductsByCategory(category);
      }
    },
    getProductsByCategory(category) {
      GetProductsByCategory(category).then((response) => {
        this.products = response;
      });
    },
    getCategory() {
      GetCategory().then((response) => {
        this.products = response;
      });
    },
  },
  mounted() {
    if (!VerifyIsLogin()) {
      this.$router.push({ name: "PageLogin" });
    }
    GetCategory().then((response) => {
      this.products = response;
    });
  },
};
</script>

<style scoped>
.container-products {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  padding-left: 50px;
  padding-right: 50px;
  gap: 1.5rem;
}
.container-products {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  padding-left: 50px;
  padding-right: 50px;
  gap: 1.5rem;
}

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
