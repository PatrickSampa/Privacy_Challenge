import { createApp } from 'vue'
import App from './App.vue'
import './Global/index.css'
import router from './router/Config.js';

const app = createApp(App)
app.use(router)
app.mount('#app')