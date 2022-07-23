import { Box, Flex, Text, VStack } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import Link from "next/link";
import listAccounts from "../http/accounts/list";

const AccountsContainer = () => {
  const { data } = useQuery(["accounts"], listAccounts);
  const accounts = data?.data ?? null;

  const displayAccounts = accounts?.map((account) => (
    <Link href={`/accounts/${account.id}`} key={account.id}>
      <Flex
        align="center"
        p="5px"
        cursor="pointer"
        _hover={{
          bg: "#5b808d",
        }}
        borderLeftColor="white"
        px="15px"
        justifyContent={"space-between"}
      >
        <Text color={"white"} fontSize={"15px"}>
          {account.name}
        </Text>
        <Text color={"white"}>{account.availableToSpend}</Text>
      </Flex>
    </Link>
  )) ?? <></>;

  return (
    <>
      <Flex
        align="center"
        p="5px"
        cursor="pointer"
        _hover={{
          bg: "#5b808d",
        }}
        borderLeftColor="white"
        px="15px"
      >
        <Text color={"white"} fontSize={"15px"}>
          Accounts
        </Text>
      </Flex>
      {displayAccounts}
    </>
  );
};
export default AccountsContainer;
