import {NextApiRequest, NextApiResponse} from "next";
import {getAccessToken, withApiAuthRequired} from '@auth0/nextjs-auth0';
import httpProxyMiddleware from "next-http-proxy-middleware";

const baseURL = process.env.BACKEND_BASE_URL || 'https://localhost:7034';

export default withApiAuthRequired(async function handler(
  _req: NextApiRequest,
  res: NextApiResponse
) {
  const {accessToken} = await getAccessToken(_req, res);
  return httpProxyMiddleware(_req, res, {
    target: `${baseURL}`,
    pathRewrite: [{
      patternStr: '^/api',
      replaceStr: '/'
    }],
    secure: false,
    headers: {
      ["Authorization"]: `Bearer ${accessToken}`,
    },
  })
})