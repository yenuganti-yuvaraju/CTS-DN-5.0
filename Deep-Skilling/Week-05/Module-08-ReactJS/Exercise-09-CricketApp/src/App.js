import React from "react";
import { ListofPlayers, Scorebelow70 } from "./components/ListofPlayers";
import {
  OddPlayers,
  EvenPlayers,
  ListofIndianPlayers
} from "./components/IndianPlayers";

function App() {

  const flag = false;

  if (flag === true) {
    return (
      <div>
        <ListofPlayers />
        <hr />
        <Scorebelow70 />
      </div>
    );
  }

  return (
    <div>
      <OddPlayers />
      <hr />
      <EvenPlayers />
      <hr />
      <ListofIndianPlayers />
    </div>
  );
}

export default App;