import { NextPage } from "next";
import {withPageAuthRequired} from "@auth0/nextjs-auth0";

const Transactions: NextPage = () => {
  return <>transactions</>;
};
export default Transactions;

export const getServerSideProps = withPageAuthRequired();