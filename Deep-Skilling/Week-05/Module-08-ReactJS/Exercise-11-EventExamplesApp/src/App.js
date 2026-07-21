import React, { useState } from "react";
import "./App.css";

function App() {

  const [count, setCount] = useState(0);

  const [amount, setAmount] = useState("");

  const [currency, setCurrency] = useState("");

  // Increment + Hello Message
  const increment = () => {
    setCount(count + 1);
    alert("Hello! Static Message");
  };

  // Decrement
  const decrement = () => {
    setCount(count - 1);
  };

  // Welcome
  const sayWelcome = (msg) => {
    alert(msg);
  };

  // Synthetic Event
  const handleClick = () => {
    alert("I was clicked");
  };

  // Currency Converter
  const handleSubmit = (e) => {

    e.preventDefault();

    const euro = (amount / 90).toFixed(2);

    alert(`${amount} INR = ${euro} Euro`);

  };

  return (

    <div className="App">

      <h2>Counter : {count}</h2>

      <button onClick={increment}>Increment</button>

      <br /><br />

      <button onClick={decrement}>Decrement</button>

      <br /><br />

      <button onClick={() => sayWelcome("Welcome")}>
        Say Welcome
      </button>

      <br /><br />

      <button onClick={handleClick}>
        Click on me
      </button>

      <hr />

      <h1>Currency Convertor!!!</h1>

      <form onSubmit={handleSubmit}>

        <label>Amount : </label>

        <input
          type="number"
          value={amount}
          onChange={(e)=>setAmount(e.target.value)}
        />

        <br /><br />

        <label>Currency : </label>

        <input
          type="text"
          value={currency}
          onChange={(e)=>setCurrency(e.target.value)}
        />

        <br /><br />

        <button type="submit">
          Submit
        </button>

      </form>

    </div>

  );

}

export default App;