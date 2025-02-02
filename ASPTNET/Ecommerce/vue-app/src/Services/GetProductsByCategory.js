import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const GetProductsByCategory = async (category) => {
  try {

    const response = await ApiDotNet.get(`/produto/getByCategory?category=${category}`);
    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}