import React from 'react'
import { Link } from 'react-router-dom'
const UserHomePage = () => {
  return (
    <body>
      <header>Welcome (user)!</header>
      <Link to="/SendRequest">Would you like to make a dine request?</Link>
      <section className="AcceptedRequest">
        <h2>(user) has accepted your request to dine!</h2>
        <Link to="/Home">Dine With Them!</Link>
      </section>
      <section className="DeclinedRequest">
        <h2>(user) has declined your request.</h2>
        <h3>Maybe Next Time!</h3>
      </section>
    </body>
  )
}

export default UserHomePage
