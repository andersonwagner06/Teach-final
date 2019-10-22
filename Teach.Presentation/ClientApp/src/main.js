import Vue from 'vue'
import App from './App.vue'
import store from './store/index'
import router from './routes/router'
import DashboardPlugin from './plugins/dashboard-plugin'
import ApiService from './services/api.service'
import { VueSpinners } from '@saeris/vue-spinners'
import './registerServiceWorker'

Vue.use(DashboardPlugin)
Vue.use(VueSpinners)

// Set the base URL of the API
ApiService.init(process.env.BASE_URL)

/* eslint-disable no-new */
new Vue({
    el: '#app',
    store,
    router,
    render: h => h(App)
})
