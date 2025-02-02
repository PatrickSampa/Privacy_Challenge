import { AxiosError } from "axios";
import { FilterStatusAxiosError } from "../Help/AxiosFilter";
export const ErrosAxios = (err) => {
  if (err instanceof AxiosError) {
    const { status, message } = FilterStatusAxiosError(err);
    if (status === 400 && message.trim() === "User Incorrect") {
      return Promise.reject(new Error("Usuário ou senha incorretos"));
    }
    if (status === 400 && message.trim() === "user already exists") {
      return Promise.reject(new Error("Usuário já existe"));
    }
    return Promise.reject(new Error("erro desconhecido"));
  }
}