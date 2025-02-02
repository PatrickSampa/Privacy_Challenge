<template>
  <nav class="navbar">
    <div class="navbar-brand">
      <img src="../assets/game-over-minimalist-ed.jpg" alt="Logo" />
    </div>
    <ul class="navbar-links">
      <li>
        <router-link :to="{ name: 'PageProducts' }">Produtos</router-link>
      </li>
      <li>
        <router-link :to="{ name: 'PageMyOrders' }">Meus Pedidos</router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: "HeaderComponent",
  data() {
    return {
      productsCart: 1,
    };
  },
};
</script>

<style scoped>
.navbar {
  background-color: rgb(0, 18, 30);
  color: white;
  display: flex;
  justify-content: space-between;
  padding: 10px 20px;
  align-items: center;
}

.navbar-brand {
  margin-left: 70px;
  width: 100px;
  height: 60px;
}

.navbar-brand img {
  width: 100%;
  height: 100%;
  border-radius: 5px;
}

.navbar-links {
  list-style: none;
  display: flex;
  margin-left: 10rem;
}

.navbar-links li {
  margin-right: 150px;
}

.navbar-links li a {
  color: white;
  text-decoration: none;
}

.navbar-links li a:hover {
  text-decoration: underline;
}

.cart-count {
  color: white;
  background-image: linear-gradient(
    rgba(241, 116, 116, 1),
    rgba(241, 116, 116, 0.1)
  );
  backdrop-filter: blur(2px);
  border-radius: 50%;
  padding: 2px 6px;
  font-size: 0.75rem;
  position: absolute;
  right: 165px;
  top: 14px;
}
</style>
