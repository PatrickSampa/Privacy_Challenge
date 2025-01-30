import express from "express";
import { routerEcommerce } from "./Ecommerce.route";

const routes = express();

routes.use("/ecommerce", routerEcommerce);

export { routes };
