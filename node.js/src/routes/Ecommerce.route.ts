import { Router } from "express";

export const routerEcommerce = Router();

routerEcommerce.get("/", (req, res) => {
  res.send("Hello World 100!");
});
