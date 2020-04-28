import React, { useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
import { Redirect } from 'react-router-dom'
// import '../Styles/User-Login.scss'
export function LoginPage() {
  const [LoginPhoneNumber, setLoginPhoneNumber] = useState('')
  const [LoginPassword, setLoginPassword] = useState('')
  const [shouldRedirect, setshouldRedirect] = useState(false)
  const logUserIntoApi = async () => {
    const resp = await axios.post('/auth/login', {
      PhoneNumber: LoginPhoneNumber,
      Password: LoginPassword,
    })
    if (resp.status == 200) {
      const token = resp.data.token
      console.log({ token })
      localStorage.setItem('token', token)
      setshouldRedirect(true)
    }
  }
  if (shouldRedirect) {
    return <Redirect to="/UserHome" />
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
            onChange={e => setLoginPhoneNumber(e.target.value)}
          ></input>
          <input
            placeholder="Password"
            type="password"
            value={LoginPassword}
            onChange={e => setLoginPassword(e.target.value)}
          ></input>
        </section>
        <section className="LoginClick">
          <button onClick={logUserIntoApi}>Login</button>
          <Link className="LoginLink" to="/SignUp">
            SignUp
          </Link>
        </section>
      </section>
    </body>
  )
}

export default LoginPage
