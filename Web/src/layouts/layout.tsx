import { ReactNode } from "react";
import { Box, Text } from "@chakra-ui/react";
import SidebarItem from "./sidebar-item";
interface Props {
  children: ReactNode;
}
const Layout = ({ children }: Props) => {
  return (
    <Box minHeight="100vh">
      <Box
        w="230px"
        bg={"#405F6A"}
        borderRight="1px"
        borderRightColor="#c3c3c3"
        position="fixed"
        h="full"
      >
        <SidebarItem url="/budget" name="Budget" />
        <SidebarItem url="/transactions" name="Transactions" />
      </Box>
      <Box bg="white" ml="230px" minHeight="100vh">
        {children}
      </Box>
    </Box>
  );
};

export default Layout;
