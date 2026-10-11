import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'

import axios from 'axios'
import router from './router'

import './assets/style.css'

import { createApp } from 'vue'
import App from './App.vue'
import Openpage from "./pages/Openpage.vue";
import Offers from "./pages/Offers.vue";
import Newad from './pages/Newad.vue'

createApp(App)
    .component('Newad', Newad)
    .component('Openpage', Openpage)
    .component('Offers', Offers)
    .use(router)
    .use(axios)
    .mount('#app')
