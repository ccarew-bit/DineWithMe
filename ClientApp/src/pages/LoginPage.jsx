import React, { useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
const LoginPage = () => {
  const [Name, setName] = useState('')
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [Password, setPassword] = useState('')
  return (
    <body className="LoginPageBackground">
      <section className="LoginPage">
        <header>Dine With Me</header>
        <section className="LoginInput">
          <input placeholder="Phone Number"></input>
          <input placeholder="Password"></input>

          <Link className="LoginLink" to="/UserHome">
            Login
          </Link>
          <Link className="LoginLink" to="/SignUp">
            SignUp
          </Link>
        </section>
      </section>
    </body>
  )
}

export default LoginPage
