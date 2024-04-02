import axios from 'axios';
import { configurations } from '../config';

const baseURL = configurations.services.url;

const api = axios.create({
  baseURL,
  headers: {
    'Content-Type': configurations.services.headers.content_type,
 },
});

export default api;