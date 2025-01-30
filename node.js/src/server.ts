import { app } from "./app";
import dotenv from "dotenv";

dotenv.config();
const PORT = process.env.API_PORT;

app.listen(PORT, () => console.log(`API is running on PORT ${PORT}`));
