import {NextApiRequest, NextApiResponse} from "next";
import {getAccessToken, withApiAuthRequired} from '@auth0/nextjs-auth0';
import BackendApiClient from "../../../utils/backend-api-client";

export default withApiAuthRequired(async function handler(
  _req: NextApiRequest,
  res: NextApiResponse
) {
  const accessToken = await getAccessToken(_req, res);
  await BackendApiClient({accessToken: accessToken.accessToken})
    .get("/budgets")
    .then(response => {
      return res.status(response.status || 200).json(response.data)
    })
    .catch(error => {
      console.log(error);
      return res.status(error.response.status || 500).json(error.response.data)
    })

})