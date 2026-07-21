import React, { useState } from "react";
import "./App.css";

function LoginButton({ onClick }) {
  return <button onClick={onClick}>Login</button>;
}

function LogoutButton({ onClick }) {
  return <button onClick={onClick}>Logout</button>;
}

function GuestGreeting() {
  return (
    <div>
      <h1>Please sign up.</h1>

      <h3>Flight Details</h3>

      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>Flight</th>
            <th>From</th>
            <th>To</th>
            <th>Time</th>
          </tr>
        </thead>

        <tbody>
          <tr>
            <td>AI101</td>
            <td>Hyderabad</td>
            <td>Delhi</td>
            <td>10:00 AM</td>
          </tr>

          <tr>
            <td>6E202</td>
            <td>Chennai</td>
            <td>Bangalore</td>
            <td>2:30 PM</td>
          </tr>
        </tbody>
      </table>

      <p>Login to book tickets.</p>
    </div>
  );
}

function UserGreeting() {
  return (
    <div>
      <h1>Welcome back!</h1>

      <h3>Flight Booking</h3>

      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>Flight</th>
            <th>Route</th>
            <th>Status</th>
          </tr>
        </thead>

        <tbody>
          <tr>
            <td>AI101</td>
            <td>Hyderabad → Delhi</td>
            <td>Available</td>
          </tr>

          <tr>
            <td>6E202</td>
            <td>Chennai → Bangalore</td>
            <td>Available</td>
          </tr>
        </tbody>
      </table>

      <br />

      <button onClick={() => alert("Ticket booked successfully!")}>
  Book Ticket
</button>
    </div>
  );
}

function Greeting({ isLoggedIn }) {
  if (isLoggedIn) {
    return <UserGreeting />;
  }

  return <GuestGreeting />;
}

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div className="App">
      <Greeting isLoggedIn={isLoggedIn} />

      <br />

      {isLoggedIn ? (
        <LogoutButton onClick={() => setIsLoggedIn(false)} />
      ) : (
        <LoginButton onClick={() => setIsLoggedIn(true)} />
      )}
    </div>
  );
}

export default App;