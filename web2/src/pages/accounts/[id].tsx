import { NextPage } from "next";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";
import { Box } from "@chakra-ui/react";

const AccountsId: NextPage = () => {
  const router = useRouter();
  const { id } = router.query;
  const accountId = id as string;
  console.log(accountId);
  return (
    <>
      <Box bg="#f3fcff" h="120px" borderBottom="solid 1px" borderColor="#dedede">
        {`test id: ${accountId}`}
      </Box>
    </>
  );
};
export default AccountsId;

export const getServerSideProps = withPageAuthRequired();
