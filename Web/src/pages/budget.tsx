import type {NextPage} from 'next'
import Budget from "../components/budget";
import {useUser} from "@auth0/nextjs-auth0";

const Home: NextPage = () => {
  const {user, error, isLoading} = useUser();

  if (!user) {
    return <a href="/api/auth/login">Login</a>;
  }


  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>{error.message}</div>;
  return (
    <Budget></Budget>
  )
}

export default Home
