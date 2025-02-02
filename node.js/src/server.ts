import mongoose from "mongoose";
import { app } from "./app";
import dotenv from "dotenv";
import { rabbitmqClient } from "./Infraestructure/Message-broker/rabbitmqClient";

const createServer = async () => {
  dotenv.config();
  const PORT = process.env.API_PORT;

  try {
    const server = app.listen(PORT, () =>
      console.log(`🚀 API está rodando na porta ${PORT}`)
    );

    const processPaymentChannel = new rabbitmqClient();
    await processPaymentChannel.consumeMessages();
  } catch (error) {
    console.error("❌ Erro :", error);
  }
};

createServer();

export { createServer };
