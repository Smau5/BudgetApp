import { useRouter } from "next/router";
import { Flex, Text } from "@chakra-ui/react";
import Link from "next/link";
interface Props {
  url: string;
  name: string;
}
const SidebarItem = ({ url, name }: Props) => {
  const router = useRouter();

  const isSelectedRoute = () => {
    if (router.pathname.includes(url)) {
      return true;
    }
    return false;
  };
  return (
    <Link href={url}>
      <Flex
        align="center"
        p="15px"
        cursor="pointer"
        _hover={{
          bg: "#5b808d",
        }}
        borderLeft={isSelectedRoute() ? "5px solid" : "0px"}
        borderLeftColor="white"
      >
        <Text color={"white"} fontSize={"20px"}>
          {name}
        </Text>
      </Flex>
    </Link>
  );
};

export default SidebarItem;
