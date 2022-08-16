import "../../styles/globals.css";
import type { AppProps } from "next/app";
import { Box, ChakraProvider } from "@chakra-ui/react";
import { UserProvider } from "@auth0/nextjs-auth0";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import Layout from "../layouts/layout";
import es from "date-fns/locale/es";
import { registerLocale, setDefaultLocale } from "react-datepicker";
const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: 1000 * 20,
    },
  },
});
registerLocale("es", es);
function MyApp({ Component, pageProps }: AppProps) {
  setDefaultLocale("es");
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <UserProvider>
          <ChakraProvider>
            <Layout>
              <Component {...pageProps} />
            </Layout>
          </ChakraProvider>
        </UserProvider>
      </QueryClientProvider>
    </>
  );
}

export default MyApp;
