import { Box } from "@chakra-ui/react";
import { useQuery } from "@tanstack/react-query";
import getBudget from "../http/budgets/get";
import CategoriesContainer from "./categories-container";

const Budget = () => {
  const { data } = useQuery(["budgets"], getBudget);
  const budget = data?.data ?? null;

  return (
    <>
      <Box bg="#e3e3e3" h="80px">
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
