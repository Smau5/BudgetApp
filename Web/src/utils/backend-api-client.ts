import axios from 'axios';

const baseURL = process.env.BACKEND_BASE_URL || 'https://localhost:7034';

interface Options {
  accessToken?: string
}

const BackendApiClient = (options?: Options) => {

  const defaultOptions = {
    baseURL,
  };

  const instance = axios.create(defaultOptions);

  instance.interceptors.request.use(async (request) => {
    if (options?.accessToken) {
      request.headers!.Authorization = `Bearer ${options.accessToken}`;
    }
    return request;
  });

  return instance;
};

export default BackendApiClient;