import { connection } from "mongoose";
import { app } from "./app";
import dotenv from "dotenv";
import { ProcessPaymentChannel } from "./messages/ProcessPaymentChannel";

const createServer = async () => {
  dotenv.config();
  const PORT = process.env.API_PORT;
  const server = app.listen(PORT, () =>
    console.log(`API is running on PORT ${PORT}`)
  );

  const processPaymentChannel = new ProcessPaymentChannel(server);
  await processPaymentChannel.consumeMessages();
  await processPaymentChannel.emitAllPayments();

  process.on("SIGINT", async () => {
    await connection.close();
    server.close();
    console.log("Closing server...");
  });
};

createServer();

export { createServer };
