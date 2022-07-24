import { AxiosResponse } from "axios";
import apiClient from "../../../utils/api-client";
import { Transaction } from "../../dto/transaction";

export default async function listTransactions(
  accountId: string
): Promise<AxiosResponse<Transaction[], any>> {
  return apiClient().get<Transaction[]>(`accounts/${accountId}/transactions`);
}
