import React, { useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
import { Redirect } from 'react-router-dom'
const SignUpPage = () => {
  const [Name, setName] = useState('')
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [Password, setPassword] = useState('')
  const [shouldRedirect, setshouldRedirect] = useState(false)
  const sendNewUserToAPI = async () => {
    const resp = await axios.post('/auth/signup', {
      Name: Name,
      PhoneNumber: PhoneNumber,
      Password: Password,
    })
    console.log(resp.data)
    if (resp.status == 200) {
      localStorage.setItem('token', resp.data.token)
      setshouldRedirect(true)
    }
  }
  if (shouldRedirect) {
    return <Redirect to="/UserHome" />
  }

  return (
    <body>
      <header>Dine With Me</header>
      <input
        type="text"
        placeholder="Name"
        value={Name}
        onChange={e => setName(e.target.value)}
      ></input>
      <input
        type="text"
        placeholder="Phone Number"
        value={PhoneNumber}
        onChange={e => setPhoneNumber(e.target.value)}
      ></input>
      <input
        type="text"
        placeholder="Password"
        value={Password}
        onChange={e => setPassword(e.target.value)}
      ></input>
      <button onClick={sendNewUserToAPI}>Sign Me Up!</button>
      <Link to="/">Let's Login!</Link>
    </body>
  )
}

export default SignUpPage
