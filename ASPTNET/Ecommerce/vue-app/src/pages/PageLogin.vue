<template>
  <div class="wapper-login">
    <div class="form-box">
      <form action="">
      <h1>Login</h1>
      <div class="input-box">
        <input type="text" placeholder="Name">
        <i class='bx bxs-user'></i>
      </div>
      <div class="input-box">
        <input type="password" placeholder="Password">
        <i class='bx bxs-lock-alt'></i>
      </div>
      <div class="remember-forget">
        <label for="">
          <input type="checkbox">Remember me
        </label>
        <a href="#">Forgot Password</a>
      </div>
      <button type="submit" class="btn">Login</button>
      <div class="register-link">
        <p>Don't have an account? <a href="/register">Register</a></p>
      </div>
    </form>
</div>
  </div>
</template>

<script>



export default {
  name: 'PageLogin'
}
</script>

<style scoped>
.wapper-login {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: url("../assets/black-aesthetic-mountains-4k-9k.jpg") no-repeat;
  background-size: cover;
  background-position: center;
}

.form-box{
  width: 420px;
  background-color: transparent;
  color: #fff;
  border-radius: 10px;
  padding: 30px 40px;
  border: 2px solid rgba(255, 255, 255, 0.2);
  backdrop-filter: blur(6px);
  box-shadow: 0 0 10px rgba(163, 159, 159, 0.2);
}

.form-box h1{
  font-size: 36px;
  text-align: center;
}

.form-box .input-box{
  position: relative;
  margin: 30px 0;
  width: 100%;
  height: 50px;
}

.input-box input{
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

.input-box input::placeholder{
  color: #fff;
}

.input-box i{
  position: absolute;
  right: 20px;
  top: 50%;
  transform: translateY(-50%);
  font-size: 20px;
}

.form-box .remember-forget{
  margin: -15px 0 15px;
  font-size: 14.5px;
  color: #fff;
  display: flex;
  justify-content: space-between;
}

.remember-forget label input{
  accent-color: #fff;
  margin-right: 3px;
}

.remember-forget a{
  color: #fff;
  text-decoration: none;
}

.remember-forget a:hover{
  text-decoration: underline;
}

.form-box .btn{
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

.form-box .btn:hover{
  background-color: rgb(255, 255, 255, 0.5);
  color: #fff;
  border-color: #fff;
}

.form-box .register-link{
  font-size: 14.5px;
  text-align: center;
  margin: 20px 0 15px;
}

.register-link p a{
  color: #fff;
  text-decoration: none;
  font-weight: 600;
}

.register-link p a:hover{
  text-decoration: underline;
}

</style>

