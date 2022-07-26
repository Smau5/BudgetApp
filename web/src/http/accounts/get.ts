import apiClient from "../../utils/api-client";
import { Account } from "../dto/account";
import { AxiosResponse } from "axios";

export default async function getAccount(
  id: string
): Promise<AxiosResponse<Account, any>> {
  return apiClient().get<Account>(`accounts/${id}`);
}
