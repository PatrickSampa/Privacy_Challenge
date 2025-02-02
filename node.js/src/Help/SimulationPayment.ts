export const SimulationPayment = async () => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const isSuccessful = Math.random() < 0.5;
      if (isSuccessful) {
        resolve("Payment simulated successfully");
      } else {
        reject("Payment simulation failed");
      }
    }, 10000);
  });
};
