import { AxiosResponse } from "axios";
import { Transaction } from "../../dto/transaction";
import apiClient from "../../../utils/api-client";

export interface CreateTransaction {
  accountId: string;
  amount: number;
  categoryId: string;
  date: Date;
}
export default async function createTransaction({
  accountId,
  amount,
  categoryId,
  date,
}: CreateTransaction): Promise<AxiosResponse<Transaction, any>> {
  return apiClient().post<Transaction>(`accounts/${accountId}/transactions`, {
    amount: amount,
    categoryId: categoryId,
    date: date,
  });
}
