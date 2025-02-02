import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const CancelPay = async (data) => {
  try {

    const response = await ApiDotNet.put(`/purchasing/canceled`, data);

    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}