import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'

const SendRequestPage = () => {
  const [NewRequest, setNewRequest] = useState({})
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
    if (resp.status == 201) {
    } else {
    }
  }
  return (
    <body>
      <header>Who would you like to dine with?</header>
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
        placeholder="Description"
        onChange={updateRequestData}
      ></input>
      <button onClick={sendRequestToApi}>Send Request!</button>
      <Link to="/UserHome">Go Home</Link>
    </body>
    //    <ul className="request-list">
    //    {request.map(NewRequest => {
    //      return (
    //        <li>
    //          <p className="review">{request.Friend}</p>
    //          <p className="review-rating">{request.Time}/5</p>
    //        </li>
    //      )
    //    })}
    //  </ul>
  )
}

export default SendRequestPage
