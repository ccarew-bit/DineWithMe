import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { Redirect } from 'react-router-dom'
import axios from 'axios'

const SendRequestPage = () => {
  const [NewRequest, setNewRequest] = useState({})
  const [shouldRedirect, setshouldRedirect] = useState(false)
  const updateRequestData = e => {
    const key = e.target.name
    const value = e.target.value
    setNewRequest(prevRequest => {
      prevRequest[key] = value
      return { ...prevRequest }
    })
  }

  const sendRequestToApi = async () => {
    console.log('adding', NewRequest)
    const resp = await axios.post(
      `/api/Request`,
      { ...NewRequest, friend: { name: NewRequest.friend } },
      {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
      }
    )
    if (resp.status == 200) {
      setshouldRedirect(true)
    }
  }
  if (shouldRedirect) {
    return <Redirect to="/UserHome" />
  }

  return (
    <body className="SendRequestBackgound">
      <section className="SendRequestPage">
        <header>Who would you like to dine with?</header>
        <section className="SendRequestInput">
          <input
            name="friend"
            placeholder="friend"
            onChange={updateRequestData}
          ></input>
          <input
            name="Time"
            type="datetime-local"
            placeholder="when?"
            onChange={updateRequestData}
          ></input>
          <input
            name="Description"
            type="text"
            placeholder="description"
            onChange={updateRequestData}
          ></input>
        </section>
        <section className="SendRequestClick">
          <button onClick={sendRequestToApi}>Send Request!</button>
          <Link to="/UserHome" className="SendRequestLink">
            Go Home
          </Link>
        </section>
      </section>
    </body>
  )
}

export default SendRequestPage
