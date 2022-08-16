import { useState } from "react";
import { Box, Button, Flex, Input, Text } from "@chakra-ui/react";
import DatePicker from "react-datepicker";
import CategoryCombobox from "./category-combobox";
import createTransaction, {
  CreateTransaction,
} from "../http/accounts/transactions/create";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useMutation, useQueryClient } from "@tanstack/react-query";
type FormData = {
  date: Date;
  amount: number;
  categoryId: string;
};
const schema = yup
  .object({
    amount: yup.number().required(),
    categoryId: yup.number().required(),
    date: yup.date().required(),
  })
  .required();
interface Props {
  onCancel?: () => void;
  accountId: string;
}

const AddTransaction = ({ onCancel, accountId }: Props) => {
  const queryClient = useQueryClient();
  const addTransactionMutation = useMutation(
    (data: CreateTransaction) => {
      return createTransaction(data);
    },
    {
      onSuccess: (_, variables) => {
        queryClient.invalidateQueries(["transactions", variables.accountId]);
        queryClient.invalidateQueries(["accounts"]);
      },
    }
  );
  const { control, handleSubmit, register } = useForm<FormData>({
    resolver: yupResolver(schema),
    defaultValues: {
      date: new Date(),
      amount: 0,
    },
  });
  const onSubmit = async (data: FormData) => {
    addTransactionMutation.mutate({
      accountId: accountId,
      amount: data.amount,
      categoryId: data.categoryId,
      date: data.date,
    });
  };
  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Flex
          borderBottom="solid 1px"
          borderColor="#dedede"
          h="30px"
          alignItems="center"
          p="4px"
        >
          <Box flex="2">
            <Controller
              control={control}
              render={({ field }) => (
                <DatePicker
                  selected={field.value}
                  onChange={(date: Date) => field.onChange(date)}
                  dateFormat="dd/MM/yyyy"
                />
              )}
              name={"date"}
            />
          </Box>
          <Box flex="1">
            <Controller
              control={control}
              render={({ field }) => (
                <CategoryCombobox onChange={field.onChange} />
              )}
              name="categoryId"
            />
          </Box>
          <Box flex="1">
            <Input
              size="sm"
              height="30px"
              border="0px"
              placeholder="0.00"
              {...register("amount")}
            />
          </Box>
        </Flex>
        <Flex borderColor="#dedede" alignItems="center" p="4px" shadow="md">
          <Box flex="1" />
          <Button size="sm" mr="5px" onClick={onCancel}>
            Cancelar
          </Button>
          <Button size="sm" mr="5px" colorScheme="blue" type="submit">
            Guardar
          </Button>
        </Flex>
      </form>
    </>
  );
};

export default AddTransaction;
