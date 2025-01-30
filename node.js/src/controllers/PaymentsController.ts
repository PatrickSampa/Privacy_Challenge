import { Request, Response } from "express";
import { IPayment, paymentsModel } from "../models/paymentsModel";

export class PaymentsController {
  async savePayment(payment: IPayment) {
    const Newpayment = await paymentsModel.create(payment);
    return Newpayment;
  }

  async getPayments() {
    const payments = await paymentsModel.find();
    return payments;
  }
}
