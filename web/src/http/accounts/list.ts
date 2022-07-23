import {AxiosResponse} from "axios";
import {Category} from "../dto/category";
import apiClient from "../../utils/api-client";
import {Account} from "../dto/account";

export default async function listAccounts(): Promise<
  AxiosResponse<Account[], any>
  > {
  return apiClient().get<Category[]>(`accounts`);
}
