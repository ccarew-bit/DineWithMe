import React from 'react'
import { Link } from 'react-router-dom'

const SendRequestPage = () => {
  return (
    <body>
      <header>Who would you like to dine with?</header>
      <input placeholder="friend"></input>
      <input type="datetime-local" placeholder="when?"></input>
      <button>Send Request!</button>
      <Link to="/UserHome">Go Home</Link>
    </body>
  )
}

export default SendRequestPage
