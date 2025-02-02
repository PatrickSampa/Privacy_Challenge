import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const LoginRequest = async (email, password) => {
  try {
    const response = await ApiDotNet.post('/users/login', { email, password });

    return response.data;
  } catch (error) {
    return ErrosAxios(error);
  }
}