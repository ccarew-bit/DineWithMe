import React, { useEffect, useState } from 'react'
import { Link, Redirect } from 'react-router-dom'
import axios from 'axios'

const UserHomePage = () => {
  const [profile, setProfile] = useState({})
  const [incomingRequests, setIncomingRequests] = useState([])
  const [outgoingRequests, setOutgoingRequests] = useState([])
  const [acceptedRequest, setAcceptedRequest] = useState([])
  const [shouldRedirect, setshouldRedirect] = useState(false)
  const loadProfile = async () => {
    const resp = await axios.get('/api/profile', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setProfile(resp.data)
  }
  useEffect(() => {
    loadProfile()
  }, [])

  ///////////Incoming
  const incomingRequest = async () => {
    const resp = await axios.get('/api/profile/IncomingRequests', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setIncomingRequests(resp.data)
  }
  useEffect(() => {
    incomingRequest()
  }, [])

  //////outgoing
  const outgoingRequest = async () => {
    const resp = await axios.get('/api/profile/OutgoingRequests', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setOutgoingRequests(resp.data)
  }
  useEffect(() => {
    outgoingRequest()
  }, [])
  console.log(incomingRequests)

  ////////////////accept request

  const AcceptRequest = e => {
    const key = e.target.name
    const value = e.target.value
    setAcceptedRequest(prevRequest => {
      prevRequest[key] = value
      return { ...prevRequest }
    })
  }

  const sendAcceptedRequestToApi = async id => {
    console.log('adding', acceptedRequest)
    const resp = await axios.post(
      `/api/Request/${id}/Accepted`,
      { ...acceptedRequest, requestor: { name: acceptedRequest.requestor } },
      {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
      }
    )
    if (resp.status == 200) {
      localStorage.setItem('token', resp.data.token)
      setshouldRedirect(true)
    }
  }
  if (shouldRedirect) {
    return <Redirect to="/FoodYorN" />
  }

  //////////////////////////
  return (
    <body>
      <header>Welcome {profile.name} !</header>
      <Link to="/SendRequest">Would you like to make a dine request?</Link>
      <section className="AcceptedRequest">
        <h2>Outgoing request</h2>
        {outgoingRequests.map(request => {
          return <li>you have asked {request.friend.name} to dine with you!</li>
        })}
      </section>
      <section className="DeclinedRequest">
        <h2>Incoming Request</h2>
        <ul>
          {incomingRequests.map(request => {
            return (
              <li>
                {request.requestor.name} has requested to dine with you!
                <button onClick={AcceptRequest}>Accept</button>
                <button>deny</button>{' '}
                <button onClick={() => sendAcceptedRequestToApi(request.id)}>
                  Continue
                </button>
              </li>
            )
          })}
        </ul>
      </section>
    </body>
  )
}

export default UserHomePage
