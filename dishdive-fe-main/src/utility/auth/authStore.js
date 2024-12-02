import {create} from 'zustand';
import axiosInstance from '../axios/axiosInstance';
import { jwtDecode } from 'jwt-decode';

const useAuthStore = create((set) => ({
  token: null,
  user: null,
  iat: null,
  exp: null,

  setToken: (newToken) => {
    try{
      if (newToken) {
        const decodedToken = jwtDecode(newToken);
        const isExpired = (Date.now() / 1000) > decodedToken.exp; 

        if(isExpired) {
          console.error('Token expired');
          delete axiosInstance.defaults.headers.common['Authorization'];
          localStorage.removeItem('dishdiveToken');
          set({token: null, user: null, iat: null, exp: null});
        } else {
          console.log('Token found');
          const newUser = {
            username: decodedToken.sub,
            role: decodedToken.role,
            userId: decodedToken.userId
          }
          set({token: newToken, user: newUser, iat: decodedToken.iat, exp: decodedToken.exp });
          axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${newToken}`;
          localStorage.setItem('dishdiveToken', newToken);
        }
      } else {
        console.error('No token');
        delete axiosInstance.defaults.headers.common['Authorization'];
        localStorage.removeItem('dishdiveToken');
        set({token: null, user: null, iat: null, exp: null});
      }
    } catch(error) {
      console.error('Zustand error processing token: ', error);
      delete axiosInstance.defaults.headers.common['Authorization'];
      localStorage.removeItem('dishdiveToken');
      set({token: null, user: null, iat: null, exp: null});
    }
  },

  clearToken: () => {
    delete axiosInstance.defaults.headers.common['Authorization'];
    localStorage.removeItem('dishdiveToken');
    set({token: null, user: null, iat: null, exp: null});
  },
}));

export default useAuthStore;
