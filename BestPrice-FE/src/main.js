import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import "bootstrap/dist/js/bootstrap.bundle.min.js";

const app = createApp(App)

// Sử dụng router trong ứng dụng
app.use(router)
app.use(VueAxios,axios)
// Mount ứng dụng
app.mount('#app')
