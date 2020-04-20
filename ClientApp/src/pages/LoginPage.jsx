import React, { useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'

export function LoginPage() {
  const [LoginPhoneNumber, setLoginPhoneNumber] = useState('')
  const [LoginPassword, setLoginPassword] = useState('')

  const logUserIntoApi = async () => {
    const resp = await axios.post('/auth/login', {
      PhoneNumber: LoginPhoneNumber,
      Password: LoginPassword,
    })
    console.log(resp.data)
  }

  return (
    <body className="LoginPageBackground">
      <section className="LoginPage">
        <header>Dine With Me</header>
        <section className="LoginInput">
          <input
            placeholder="Phone Number"
            type="text"
            value={LoginPhoneNumber}
            on
            onChange={e => setLoginPhoneNumber(e.target.value)}
          ></input>
          <input
            placeholder="Password"
            type="text"
            value={LoginPassword}
            on
            onChange={e => setLoginPassword(e.target.value)}
          ></input>

          <button className="LoginLink" to="/UserHome" onClick={logUserIntoApi}>
            Login
          </button>
          <Link className="LoginLink" to="/SignUp">
            SignUp
          </Link>
        </section>
      </section>
    </body>
  )
}

export default LoginPage
