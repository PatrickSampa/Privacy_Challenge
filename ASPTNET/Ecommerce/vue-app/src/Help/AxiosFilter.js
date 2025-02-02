export const FilterStatusAxiosError = (err) => {
  return {
    status: err.response?.status,
    message: err.response?.data,
  };
};