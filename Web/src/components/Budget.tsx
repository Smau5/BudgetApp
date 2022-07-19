import { Box, Flex } from "@chakra-ui/react";
import { useState } from "react";

export default function Budget() {
  const [budget, setBudget] = useState();

  return (
    <Flex flexDir={"column"} h={"100%"}>
      <Box h={"70px"}>header</Box>
      <Box flex={1}></Box>
    </Flex>
  );
}