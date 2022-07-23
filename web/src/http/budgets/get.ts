import { Category } from "../dto/category";
import { AxiosResponse } from "axios";
import apiClient from "../../utils/api-client";

export interface GetBudgetResponse {
  availableToAssign: string;
  availableToSpend: string;
  categories: Category[];
}
export default async function getBudget(): Promise<
  AxiosResponse<GetBudgetResponse, any>
> {
  return apiClient().get<GetBudgetResponse>(`budgets`);
}
