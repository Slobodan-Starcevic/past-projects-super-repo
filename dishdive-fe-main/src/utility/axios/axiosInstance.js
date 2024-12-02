import axios from 'axios';
import useAuthStore from '../auth/authStore';

const axiosInstance = axios.create({
    baseURL: "http://localhost:8080",
});

axiosInstance.interceptors.request.use((config) => {
  const token = useAuthStore.getState().token;
  if (token) {
    const tokenExp = useAuthStore.getState().exp;
    const isExpired = (Date.now() / 1000) > tokenExp; 

    if(isExpired){
      useAuthStore.getState().clearToken();
    }
    else {
      config.headers.Authorization = `Bearer ${token}`;
    }
  }
  return config;
});

export default axiosInstance;