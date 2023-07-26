import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import fs from 'fs';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue(),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    host: "localhost",
    port: 3000,
    https: {
        key: fs.readFileSync('./.cert/key.pem'),
        cert: fs.readFileSync('./.cert/cert.pem'),
        requestCert: true,
        rejectUnauthorized: false,
        passphrase: import.meta.env.VITE_ENV_PASSPHRASE,
    },
    strictPort: true,
    proxy: {
        '/api': {
            target: import.meta.env.VITE_API_URL}
    }
  }
})
