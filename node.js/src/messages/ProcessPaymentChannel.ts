import { config } from "dotenv";
import { Channel, connect } from "amqplib";
import { Server, Socket } from "socket.io";
import * as http from "http";
import { PaymentsController } from "../controllers/PaymentsController";

config();

export class ProcessPaymentChannel {
  private _channel: Channel | undefined;
  private _paymentsController: PaymentsController;
  private _io: Server;

  constructor(server: http.Server) {
    this._paymentsController = new PaymentsController();
    this._io = new Server(server, {
      cors: {
        origin: process.env.SOCKET_CLIENT_SERVER,
        methods: ["GET", "POST"],
      },
    });
    this._io.on("connection", () => console.log("Client connected"));

    this._io.on("connection", (socket: Socket) => {
      console.log("Client connected", socket.id);
    });
  }

  public async _createMessageChannel() {
    try {
      const connection = await connect(process.env.AMQP_SERVER as string);
      this._channel = await connection.createChannel();
      this._channel.assertQueue(process.env.QUEUE_NAME as string);
    } catch (error) {
      console.log("Error creating message channel", error);
    }
  }

  public async consumeMessages() {
    await this._createMessageChannel();
    if (this._channel) {
      this._channel?.consume(
        process.env.QUEUE_NAME as string,
        async (message) => {
          const paymentObj = JSON.parse(message?.content.toString() as string);
          console.log(paymentObj);
          console.log("Payment processed successfully");
          this._channel?.ack(message as any);
          await this._paymentsController.savePayment(paymentObj);
          this._io.emit(process.env.SOCKET_EVENT_NAME as string, paymentObj);
        }
      );
    }
  }

  public async emitAllPayments() {
    await this._createMessageChannel();
    try {
      try {
        const payments = await this._paymentsController.getPayments();
        this._io.emit("allPayments", payments);
      } catch (error) {
        console.error("Failed to retrieve payments:", error);
      }
    } catch (error) {
      console.error("Failed to retrieve payments:", error);
    }
  }
}
