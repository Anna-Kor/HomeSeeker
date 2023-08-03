import { fileURLToPath, URL } from 'node:url'
import { defineConfig, loadEnv } from 'vite'
import vue from '@vitejs/plugin-vue'
import fs from 'fs';

// https://vitejs.dev/config/
export default ({ mode }) => {
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};

  return defineConfig({
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
          passphrase: process.env.VITE_ENV_PASSPHRASE,
      },
      strictPort: true,
      proxy: {
          '/api': {
              target: process.env.VITE_API_URL}
      }
    }
  });
}
