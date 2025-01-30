import { model, Document, Schema } from "mongoose";
import { Status } from "./EnumStatus";

export interface IPayment extends Document {
  idPurchasingProcess: string;
  idSessionSocket: string;
  status: Status;
  payment_date: Date;
}

const paymentSchema = new Schema({
  idPurchasingProcess: { type: String, required: true },
  idSessionSocket: { type: String, required: true },
  status: { type: String, required: true },
  payment_date: { type: Date, required: true },
});

export const paymentsModel = model<IPayment>("payments", paymentSchema);
