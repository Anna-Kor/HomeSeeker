/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_API_URL: string
    readonly VITE_ENV_PASSPHRASE: string
  }
  
  interface ImportMeta {
    readonly env: ImportMetaEnv
  }