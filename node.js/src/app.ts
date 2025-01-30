import express from "express";
import cors from "cors";
import logger from "morgan";
import { routes } from "./routes";

const app = express();

app.use(cors());

app.use(express.json({ limit: "50mb" }));

app.use(logger("dev"));

app.use(routes);

export { app };
