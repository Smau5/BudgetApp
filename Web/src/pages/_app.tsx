import '../../styles/globals.css'
import type {AppProps} from 'next/app'
import {Box, ChakraProvider} from '@chakra-ui/react'
import {UserProvider} from '@auth0/nextjs-auth0';

function MyApp({Component, pageProps}: AppProps) {
  return (
    <UserProvider>
      <ChakraProvider>
        <Box minH="100vh">
          <Component {...pageProps} />
        </Box>
      </ChakraProvider>
    </UserProvider>
  )
}

export default MyApp
