import { NextPage } from "next";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";
import { Box } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import getBudget from "../../http/budgets/get";
import listTransactions from "../../http/accounts/transactions/list";

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
  console.log(transactionsList);
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
    </>
  );
};
export default AccountsId;

export const getServerSideProps = withPageAuthRequired();
