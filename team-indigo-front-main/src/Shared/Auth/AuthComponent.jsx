import React, { useEffect } from 'react';
import { useMsal, useAccount } from '@azure/msal-react';
import axios from 'axios';
import { InteractionRequiredAuthError } from '@azure/msal-browser';

const AuthComponent = ({ children }) => {
    const { instance, accounts } = useMsal();
    const account = useAccount(accounts[0] || {});
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          if (account) {
              const response = await instance.acquireTokenSilent({
              scopes: ['User.Read'],
              account: account,
            });

            localStorage.setItem('token', token);
            const token = response.accessToken;
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
          }
        } catch (error) {
          if (error instanceof InteractionRequiredAuthError) {
            return instance.acquireTokenRedirect();
        }
        }
      };
  
      fetchData();
    }, [account, instance]);
  
    return <>{children}</>;
  };

export default AuthComponent;