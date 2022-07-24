import { NextPage } from "next";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";
import { Box, Flex, Text } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import getBudget from "../../http/budgets/get";
import listTransactions from "../../http/accounts/transactions/list";
import dayjs from "dayjs";

const AccountsId: NextPage = () => {
  const router = useRouter();
  const { id } = router.query;
  const { data } = useQuery(
    ["transactions", id],
    async () => {
      return listTransactions(id as string);
    },
    {
      enabled: !!id,
    }
  );
  const transactionsList = data?.data ?? null;

  const displayTransactionsList = transactionsList?.map((transaction) => {
    return (
      <Flex
        borderBottom="solid 1px"
        borderColor="#dedede"
        h="30px"
        alignItems="center"
        p="5px"
        key={transaction.id}
      >
        <Box flex="2">
          <Text>{dayjs(transaction.dateTime).format("DD/MM/YYYY")}</Text>
        </Box>
        <Box flex="1">
          <Text>{transaction.categoryId}</Text>
        </Box>
        <Box flex="1">
          <Text>{transaction.amount}</Text>
        </Box>
      </Flex>
    );
  }) ?? <></>;
  return (
    <>
      <Box
        bg="#f3fcff"
        h="120px"
        borderBottom="solid 1px"
        borderColor="#dedede"
      >
        {`test id: ${id}`}
      </Box>
      {displayTransactionsList}
    </>
  );
};
export default AccountsId;

export const getServerSideProps = withPageAuthRequired();
