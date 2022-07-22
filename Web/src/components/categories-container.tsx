import { useQuery } from "@tanstack/react-query";
import listCategories from "../http/categories/list";
import Category from "./category";
import { Box, Flex, HStack, VStack, Text } from "@chakra-ui/react";

const CategoriesContainer = () => {
  const { data } = useQuery(["categories"], listCategories);
  const categories = data?.data ?? null;

  const displayCategories = categories?.map((category) => (
    <Category key={category.id} category={category} />
  )) ?? <></>;

  return (
    <Flex flexDir="column">
      <Flex
        h="50px"
        alignItems="center"
        borderBottom="solid 1px"
        borderTop="solid 1px"
        borderColor="#dedede"
      >
        <Box flex="2">
          <Text>Category</Text>
        </Box>
        <Box flex="1">
          <Text>Assigned</Text>
        </Box>
        <Box flex="1">
          <Text>Activity</Text>
        </Box>
        <Box flex="1">
          <Text>Available</Text>
        </Box>
      </Flex>
      {displayCategories}
    </Flex>
  );
};

export default CategoriesContainer;
