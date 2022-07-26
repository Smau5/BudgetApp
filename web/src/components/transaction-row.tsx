import { Box, Flex, Text } from "@chakra-ui/react";
import dayjs from "dayjs";
import { useQuery } from "@tanstack/react-query";
import listCategories from "../http/categories/list";
import CategoryCombobox from "./category-combobox";

interface Props {
  id: string;
  dateTime: Date;
  categoryId: number;
  amount: number;
}

const TransactionRow = ({ id, dateTime, categoryId, amount }: Props) => {
  return (
    <Flex
      borderBottom="solid 1px"
      borderColor="#dedede"
      h="30px"
      alignItems="center"
      p="5px"
      key={id}
    >
      <Box flex="2">
        <Text>{dayjs(dateTime).format("DD/MM/YYYY")}</Text>
      </Box>
      <Box flex="1">
        <CategoryCombobox initialSelectedId={categoryId.toString()} />
      </Box>
      <Box flex="1">
        <Text>{amount}</Text>
      </Box>
    </Flex>
  );
};

export default TransactionRow;
