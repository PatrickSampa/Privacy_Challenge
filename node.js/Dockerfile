FROM node:20

WORKDIR /app

# Copiar arquivos de configuração
COPY package*.json ./
COPY tsconfig.json ./

# Instalar dependências
RUN npm install

# Copiar código fonte
COPY . .

# Build do TypeScript
RUN npm run build

EXPOSE 3000

# Comando para iniciar a aplicação
CMD ["node", "dist/server.js"]