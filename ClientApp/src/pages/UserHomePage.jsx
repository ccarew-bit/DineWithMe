import React, { useEffect, useState } from 'react'
import { Link, Redirect } from 'react-router-dom'
import axios from 'axios'

const UserHomePage = () => {
  const [profile, setProfile] = useState({})
  const [incomingRequests, setIncomingRequests] = useState([])
  const [outgoingRequests, setOutgoingRequests] = useState([])
  const [acceptedRequest, setAcceptedRequest] = useState([])
  const [deniedRequest, setDeniedRequest] = useState([])
  const [friendAcceptedRequest, setFriendAcceptedRequest] = useState([])
  const [friendDeniedRequest, setFriendDeniedRequest] = useState([])
  const [agreements, setAgreement] = useState([])
  const [requestIdToRedirectTo, setRequestIdToRedirectTo] = useState(0)
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

  //////////////Accepted request
  const friendHasAcceptedRequest = async () => {
    const resp = await axios.get('/api/profile/AcceptedRequests', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setFriendAcceptedRequest(resp.data)
  }
  useEffect(() => {
    friendHasAcceptedRequest()
  }, [])

  /////////////// denied request
  const friendHasDeniedRequest = async () => {
    const resp = await axios.get('/api/profile/DeniedRequests', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setFriendDeniedRequest(resp.data)
  }
  useEffect(() => {
    friendHasDeniedRequest()
  }, [])

  ///////////////////////////////////////////////////// agreement reached
  const AgreedOnRequests = async () => {
    const resp = await axios.get(`/api/Agreement/MutuallyAgreed`, {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setAgreement(resp.data)
  }
  useEffect(() => {
    AgreedOnRequests()
  }, [])
  console.log(agreements)

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
      setRequestIdToRedirectTo(id)
    }
  }
  if (requestIdToRedirectTo) {
    return <Redirect to={`/FoodYorN/${requestIdToRedirectTo}`} />
  }
  /////////////////// send deny
  const DenieRequest = e => {
    const key = e.target.name
    const value = e.target.value
    setDeniedRequest(prevRequest => {
      prevRequest[key] = value
      return { ...prevRequest }
    })
  }

  const sendDeniedRequestToApi = async id => {
    console.log('adding', deniedRequest)
    const resp = await axios.post(
      `/api/Request/${id}/Denied`,
      { ...deniedRequest, requestor: { name: deniedRequest.requestor } },
      {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
      }
    )
  }
  //////////////////////////
  return (
    <body className="UserHomeBackground">
      <section className="UserHomePage">
        <header>Welcome {profile.name} !</header>
        <Link to="/SendRequest" className="LinktoRequestPage">
          Would you like to make a dine request?
        </Link>
        <section className="PandIRequest">
          <section className="AcceptedRequest">
            <h1>Accepted</h1>
            {friendAcceptedRequest.map(request => {
              //if (request.IsRequestAccepted == true) {
              return (
                <li>
                  {request.friend.name} has accepted your dine request!
                  <Link to={`/FoodYorN/${request.id}`}>Lets Get started</Link>
                </li>
              )
              //}
            })}
          </section>

          <section className="IncomingRequest">
            <h1>Request</h1>
            <ul>
              {incomingRequests.map(request => {
                return (
                  <li>
                    {request.requestor.name} has requested to dine with you!
                    <button onClick={AcceptRequest}>Accept</button>
                    <button onClick={DenieRequest}>deny</button>{' '}
                    <button
                      onClick={
                        (() => sendAcceptedRequestToApi(request.id),
                        () => sendDeniedRequestToApi(request.id))
                      }
                      //////changed
                    >
                      Continue
                    </button>
                  </li>
                )
              })}
            </ul>
          </section>
        </section>
        <section className="PendingRequest">
          <h2>Pending request</h2>
          {outgoingRequests.map(request => {
            return (
              <li>you have asked {request.friend.name} to dine with you!</li>
            )
          })}
        </section>
        <section>
          <h1>You have agreed to these restaurants</h1>
          {agreements.map(agreement => {
            if (agreement.friend.id == agreement.userId) {
              return (
                <li>
                  you have agreed with{agreement.friend.name} to dine at these
                  restaurants: <li>{agreement.restaurant.name}</li>
                </li>
              )
            }
            if (agreement.requestor.id == agreement.userId) {
              return (
                <li>
                  you have agreed with{agreement.requestor.name} to dine at
                  these restaurants: <li>{agreement.restaurant.name}</li>
                </li>
              )
            }
          })}
        </section>
        <section>
          <h1>Denied</h1>
          {friendDeniedRequest.map(request => {
            //if (request.IsRequestAccepted == true) {
            return <li>{request.friend.name} has Denied your dine request!</li>
            //}
          })}
        </section>
      </section>
    </body>
  )
}

export default UserHomePage
