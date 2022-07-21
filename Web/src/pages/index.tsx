import type {NextPage} from 'next'
import Budget from "../components/budget";
import {useUser} from "@auth0/nextjs-auth0";
import {useEffect} from "react";
import ApiClient from "../utils/api-client";

const Home: NextPage = () => {
  const {user, error, isLoading} = useUser();

  useEffect(() => {
    request();
  }, [])

  const request = async () => {
    try {

      const res = await ApiClient().get("/budgets");
    } catch (e) {
      // console.log(e)

    }
  }
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
