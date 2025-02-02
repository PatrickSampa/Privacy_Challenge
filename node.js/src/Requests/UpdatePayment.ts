import axios from "axios";

export const UpdatePayment = async (value: any) => {
  await axios.put(`http://api:5234/api/purchasing/sucess`, value);
};
