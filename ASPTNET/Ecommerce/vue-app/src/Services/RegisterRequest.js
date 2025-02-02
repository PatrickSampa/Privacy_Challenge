import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const RegisterRequest = async (name, email, password) => {
  try {
    const response = await ApiDotNet.post('/users', { name, email, password });
    return response.data;
  } catch (error) {
    return ErrosAxios(error);
  }
}