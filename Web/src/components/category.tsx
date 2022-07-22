import { Box, Flex, Text } from "@chakra-ui/react";
import { Category } from "../http/dto/category";
interface Props {
  category: Category;
}
const Category = ({ category }: Props) => {
  return (
    <Flex
      borderBottom="solid 1px"
      borderColor="#dedede"
      h="30px"
      alignItems="center"
      p="5px"
    >
      <Box flex="2">
        <Text>{category.name}</Text>
      </Box>
      <Box flex="1">
        <Text>{category.assigned}</Text>
      </Box>
      <Box flex="1">
        <Text>{category.activity}</Text>
      </Box>
      <Box flex="1">
        <Text>{category.availableToSpend}</Text>
      </Box>
    </Flex>
  );
};
export default Category;
