import {AxiosResponse} from "axios";
import {Account} from "../dto/account";
import apiClient from "../../utils/api-client";
import {Category} from "../dto/category";

export default async function getAccount(): Promise<
  AxiosResponse<Account[], any>
  > {
  return apiClient().get<Category[]>(`accounts`);
}
