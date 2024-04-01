import axios from 'axios';
import { configurations } from '../config';

const baseURL = configurations.services.url;

const api = axios.create({
  baseURL,
  withCredentials: true,
  headers: {
    'Content-Type': configurations.services.headers.content_type,
    'Access-Control-Allow-Origin': 'http://localhost:7089',
 },
});

export default api;