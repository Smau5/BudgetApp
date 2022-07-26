import { NextPage } from "next";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";
import { Box, Button, Flex, Heading, Text } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import listTransactions from "../../http/accounts/transactions/list";
import TransactionRow from "../../components/transaction-row";
import getAccount from "../../http/accounts/get";
import { IoAddOutline } from "react-icons/io5";

const AccountsId: NextPage = () => {
  const router = useRouter();
  const { id } = router.query;
  const getAccountQuery = useQuery(
    ["account", id],
    async () => {
      return getAccount(id as string);
    },
    {
      enabled: !!id,
    }
  );
  const listTransactionsQuery = useQuery(
    ["transactions", id],
    async () => {
      return listTransactions(id as string);
    },
    {
      enabled: !!id,
    }
  );
  const transactionsList = listTransactionsQuery.data?.data ?? null;
  const account = getAccountQuery.data?.data ?? null;

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
        borderBottom="solid 1px"
        borderColor="#dedede"
        padding="15px"
      >
        <Box p={"10px"}>
          <Text fontSize={"30px"}>{account?.name}</Text>
          <Text fontSize={"20px"}>{account?.availableToSpend}</Text>
        </Box>
        <Box>
          <Button
            leftIcon={<IoAddOutline size={"20px"} />}
            variant="ghost"
            size={"sm"}
          >
            Agregar
          </Button>
        </Box>
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
          <Text>Categoría</Text>
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
