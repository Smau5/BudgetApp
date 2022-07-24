import type { NextPage } from "next";
import {useUser, withPageAuthRequired} from "@auth0/nextjs-auth0";
import { useQuery } from "@tanstack/react-query";
import getBudget from "../http/budgets/get";
import { Box } from "@chakra-ui/react";
import CategoriesContainer from "../components/categories-container";

const Budget: NextPage = () => {
  const { data } = useQuery(["budgets"], getBudget);
  const budget = data?.data ?? null;

  return (
    <>
      <Box bg="#f3fcff" h="80px">
        To budget:
        {budget?.availableToAssign}
      </Box>
      <Box h="100%">
        <CategoriesContainer />
      </Box>
    </>
  );
};

export default Budget;

export const getServerSideProps = withPageAuthRequired();