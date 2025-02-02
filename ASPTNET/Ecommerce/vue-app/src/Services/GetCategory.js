import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const GetCategory = async () => {
  try {
    const response = await ApiDotNet.get(`/produto/`);
    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}