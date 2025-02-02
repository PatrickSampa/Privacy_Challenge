import { config } from "dotenv";
import { Channel, connect } from "amqplib";
import { UpdatePayment } from "../../Requests/UpdatePayment";
import { SimulationPayment } from "../../Help/SimulationPayment";

config();

export class rabbitmqClient {
  private _channel: Channel | undefined;

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
          const paymentObj: any = JSON.parse(
            message?.content.toString() as string
          );

          this._channel?.ack(message as any);
          let payTransaction: any;
          try {
            payTransaction = (await SimulationPayment()) ? "Success" : "Failed";
          } catch (err) { 
            payTransaction = "Failed";
          }
          paymentObj.StatusProcess = "Success";
          console.log(paymentObj);
          await UpdatePayment(paymentObj);
          console.log("Payment saved successfully");
        }
      );
    }
  }
}
