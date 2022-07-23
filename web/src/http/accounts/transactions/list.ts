import { AxiosResponse } from "axios";
import { Category } from "../../dto/category";
import apiClient from "../../../utils/api-client";
import { Account } from "../../dto/account";

export default async function listTransactions(
  accountId: string
): Promise<AxiosResponse<Account[], any>> {
  return apiClient().get<Account[]>(`accounts/${accountId}/transactions`);
}
