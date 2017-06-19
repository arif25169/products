import {configureHttp} from './HttpConfig';

const HTTP_CONFIG = {
  baseURL: 'http://localhost:53986',
}

export default (store) =>
  configureHttp(() => {
    return {
      ...HTTP_CONFIG
    };
  });