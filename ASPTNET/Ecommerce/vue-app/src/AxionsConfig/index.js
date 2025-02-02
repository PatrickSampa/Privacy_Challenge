import axios from 'axios';

export const ApiDotNet = axios.create({
  baseURL: 'http://localhost:5234/api'
});

