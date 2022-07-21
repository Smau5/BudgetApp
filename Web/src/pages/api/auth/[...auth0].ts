import {handleAuth, handleLogin} from '@auth0/nextjs-auth0';

export default handleAuth({
  async login(req, res) {
    try {
      await handleLogin(req, res, {
        authorizationParams: {
          audience: 'https://budgetapp/api', // or AUTH0_AUDIENCE
        }
      });
    } catch (error: any) {
      res.status(error.status || 400).end(error.message);
    }
  }
});