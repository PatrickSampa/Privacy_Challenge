import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const GetProductId = async (id) => {
  try {
    const response = await ApiDotNet.get(`/produto/id?id=${id}`);
    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}