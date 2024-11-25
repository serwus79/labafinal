import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

export const apiUrl = import.meta.env.VITE_API_URL || 'http://localhost:5000'

createApp(App).mount('#app')
