import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const GetPurchasingByIdProduct = async (id) => {
  try {
    const response = await ApiDotNet.get(`/purchasing/getByIdBuy?id=${id}`);
    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}