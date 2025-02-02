import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const PurchaseRequest = async (productId, quantity, PricelTotal, PaymentCompleted, DateCreatedBuy, DateUpdatedBuy) => {
  try {
    const UserId = localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).id : null;
    const response = await ApiDotNet.post('/buy', { UserId, productId, quantity, PricelTotal, PaymentCompleted, DateCreatedBuy, DateUpdatedBuy });
    return response.data;
  } catch (error) {
    return ErrosAxios(error);
  }
}