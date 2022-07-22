import axios from 'axios';

const baseURL = process.env.AUTH0_BASE_URL || 'http://localhost:3000';


const ApiClient = () => {

  const defaultOptions = {
    baseURL: `${baseURL}/api`
  };

  const instance = axios.create(defaultOptions);
  return instance;
};

export default ApiClient;