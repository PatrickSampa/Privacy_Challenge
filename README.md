# 🎮 Loja de Games

Uma simulação de e-commerce para venda de jogos e consoles.

## 📝 Sobre o Projeto

Este projeto simula uma loja virtual de games com sistema de pagamentos, gerenciamento de pedidos e autenticação de usuários.

## 🏗️ Arquitetura do Sistema

O projeto utiliza uma arquitetura distribuída com as seguintes camadas:

1. **Vue.js**: Interface web para interação do usuário
2. **.NET Core**: Gerenciamento de produtos e pedidos
3. **Node.js**: Processamento de pagamentos
4. **RabbitMQ**: Mensageria para comunicação assíncrona
5. **MongoDB**: Persistência de dados

### 📊 Fluxo de Processamento

1. Cliente realiza uma compra
2. API .NET salva o pedido no MongoDB
3. Pedido é enviado para fila RabbitMQ
4. API Node.js processa o pagamento (simulação)
5. Resultado é enviado de volta para API .NET
6. Status do pedido é atualizado

## 🔄 Fluxo do Usuário

### 🔐 Autenticação

- Login no sistema com email e senha
- Opção de cadastro para novos usuários
- Redirecionamento para login após cadastro

### 🛍️ Compras

1. Visualização de jogos e consoles disponíveis
2. Acesso aos detalhes do produto
3. Seleção de quantidade e forma de pagamento
4. Finalização da compra

### 📦 Gerenciamento de Pedidos

- Acompanhamento do status de pagamento
- Possibilidade de cancelamento antes do processamento
- Tempo médio de aprovação: 7 segundos

### 💳 Status de Pagamento

- **PENDING**: Aguardando processamento
- **CANCELED**: Pagamento cancelado pelo usuário
- **SUCCESS**: Pagamento aprovado

## 🚀 Como Executar

### Pré-requisitos

- Docker
- Docker Compose

### Instalação

1. Clone o repositório

2. No diretório raiz do projeto, execute:
   - docker-compose up -d

## 👤 Usuário para Testes

Email: admin@gmail.com
Senha: admin

## 🛠️ Stack Tecnológica

### Backend

- **.NET Core**: API principal e gerenciamento de produtos
- **Node.js**: Processamento de pagamentos
- **MongoDB**: Banco de dados NoSQL
- **RabbitMQ**: Sistema de mensageria

### Frontend

- **Vue.js**: Interface web para interação do usuário

### DevOps

- **Docker**: Containerização
- **Docker Compose**: Orquestração de containers

## 📝 Notas Importantes

- Base de dados é automaticamente populada com produtos de teste
- Tempo de processamento de pagamento: ~7 segundos
- Cancelamentos só são possíveis durante o processamento
- Atualização de status requer refresh da página (F5)

## 🔍 Monitoramento

- RabbitMQ Management UI: http://localhost:15672
  - Usuário: guest
  - Senha: guest


## 🕹️ ROTA DE ACESSO AO FRONTEND

- http://localhost:5234/

