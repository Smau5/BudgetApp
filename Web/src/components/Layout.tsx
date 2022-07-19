import { Box } from "@chakra-ui/react";
import { ReactNode } from "react";

interface Props {
  children: ReactNode;
}

export default function Layout({ children }: Props) {
  return (
    <Box h={"100vh"} w={"100vw"}>
      {children}
    </Box>
  );
}
