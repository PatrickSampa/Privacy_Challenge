<template>
  <div class="wrapper-register">
    <div class="form-box">
      <form action="">
        <h1>Register</h1>
        <div class="input-box">
          <input type="text" placeholder="Name" v-model="name">
          <i class='bx bxs-user'></i>
        </div>
        <div class="input-box">
          <input type="email" placeholder="Email" v-model="email">
          <i class='bx bxs-envelope'></i>
        </div>
        <div class="input-box">
          <input type="password" placeholder="Password" v-model="password">
          <i class='bx bxs-lock-alt'></i>
        </div>
        <button type="button" class="btn" @click="register">Register</button>
        <div class="login-link">
          <p>Already have an account? <router-link :to="{name: 'PageLogin'}">Login</router-link></p>
        </div>
        <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
      </form>
    </div>
  </div>
</template>

<script>
import { RegisterRequest } from '../Services/RegisterRequest';

export default {
  name: 'PageRegister',
  data() {
    return {
      name: '',
      email: '',
      password: '',
      errorMessage: ''
    }
  },
  methods: {
    register() {
      RegisterRequest(this.name, this.email, this.password).then(() => {
        this.$router.push({ name: 'PageLogin' });
      }).catch((error) => {
        this.errorMessage = error.message;
      });

    }
  }
}
</script>


<style scoped>
.wrapper-register {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: url("../assets/black-aesthetic-mountains-4k-9k.jpg") no-repeat;
  background-size: cover;
  background-position: center;
}

.form-box {
  width: 420px;
  background-color: transparent;
  color: #fff;
  border-radius: 10px;
  padding: 30px 40px;
  border: 2px solid rgba(255, 255, 255, 0.2);
  backdrop-filter: blur(6px);
  box-shadow: 0 0 10px rgba(163, 159, 159, 0.2);
}

.form-box h1 {
  font-size: 36px;
  text-align: center;
}

.form-box .input-box {
  position: relative;
  margin: 30px 0;
  width: 100%;
  height: 50px;
}

.input-box input {
  width: 100%;
  height: 100%;
  background: transparent;
  border: none;
  font-size: 16px;
  outline: none;
  border: 2px solid rgba(255, 255, 255, 0.2);
  border-radius: 40px;
  color: #fff;
  padding: 20px 45px 20px 20px;
}

.input-box input::placeholder {
  color: #fff;
}

.input-box i {
  position: absolute;
  right: 20px;
  top: 50%;
  transform: translateY(-50%);
  font-size: 20px;
}

.form-box .btn {
  width: 100%;
  height: 45px;
  background-color: #fff;
  border: none;
  outline: none;
  border-radius: 40px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  font-size: 16px;
  color: #333;
  font-weight: 600;
}

.form-box .btn:hover {
  background-color: rgb(255, 255, 255, 0.5);
  color: #fff;
  border-color: #fff;
}

.form-box .login-link {
  font-size: 14.5px;
  text-align: center;
  margin: 20px 0 15px;
}

.login-link p a {
  color: #fff;
  text-decoration: none;
  font-weight: 600;
}

.login-link p a:hover {
  text-decoration: underline;
}

.error-message {
  color: #d9534f;
  font-size: 14px;
  text-align: center;
}
</style>