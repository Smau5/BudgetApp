import { NextPage } from "next";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";
import { Box, Flex, Text } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import listTransactions from "../../http/accounts/transactions/list";
import TransactionRow from "../../components/TransactionRow";

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
      <TransactionRow
        id={transaction.id}
        dateTime={transaction.dateTime}
        categoryId={transaction.categoryId}
        amount={transaction.amount}
        key={transaction.id}
      />
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
      <Flex
        borderBottom="solid 1px"
        borderColor="#dedede"
        h="30px"
        alignItems="center"
        p="5px"
      >
        <Box flex="2">
          <Text>Fecha</Text>
        </Box>
        <Box flex="1">
          <Text>Categoria</Text>
        </Box>
        <Box flex="1">
          <Text>Monto</Text>
        </Box>
      </Flex>
      {displayTransactionsList}
    </>
  );
};
export default AccountsId;

export const getServerSideProps = withPageAuthRequired();
