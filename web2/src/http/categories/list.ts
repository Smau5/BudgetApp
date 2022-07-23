import { AxiosResponse } from "axios";
import apiClient from "../../utils/api-client";
import { Category } from "../dto/category";

export default async function listCategories(): Promise<
  AxiosResponse<Category[], any>
> {
  return apiClient().get<Category[]>(`categories`);
}
