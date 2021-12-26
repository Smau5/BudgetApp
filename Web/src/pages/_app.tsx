import "../../styles/globals.css";
import type {AppProps} from "next/app";
import {ChakraProvider, ColorModeProvider} from "@chakra-ui/react";
import Layout from "../components/Layout";

function MyApp({Component, pageProps}: AppProps) {
  return (
    <ChakraProvider>
      <ColorModeProvider
        options={{
          useSystemColorMode: true,
        }}
      >
        <Layout>
          <Component {...pageProps} />
        </Layout>
      </ColorModeProvider>
    </ChakraProvider>
  );
}

export default MyApp
