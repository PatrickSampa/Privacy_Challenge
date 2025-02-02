import { ApiDotNet } from '../AxionsConfig';
import { ErrosAxios } from '../AxionsConfig/ErrosAxios';

export const GetPayAll = async () => {
  try {
    const id = localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).id : null;
    const response = await ApiDotNet.get(`/buy/all?id=${id}`);
    return response.data;

  } catch (error) {
    return ErrosAxios(error);
  }
}