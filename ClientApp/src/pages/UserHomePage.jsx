import React, { useEffect, useState } from 'react'
import { Link, Redirect } from 'react-router-dom'
import axios from 'axios'

const UserHomePage = () => {
  const [profile, setProfile] = useState({})
  const [incomingRequests, setIncomingRequests] = useState([])
  const [outgoingRequests, setOutgoingRequests] = useState([])
  const [acceptedRequest, setAcceptedRequest] = useState([])
  const [deniedRequest, setDeniedRequest] = useState([])
  const [friendAcceptedRequests, setFriendAcceptedRequests] = useState([])
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
    setFriendAcceptedRequests(resp.data)
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
            <ul>
              {friendAcceptedRequests.map(request => {
                // if (request.friendAcceptedRequests==false)
                return (
                  <li>
                    {request.friend.name} has accepted your dine request for{' '}
                    {request.description}! <br></br>
                    <Link
                      to={`/FoodYorN/${request.id}`}
                      className="AcceptedLink"
                    >
                      Lets Get started
                    </Link>
                  </li>
                )
              })}
            </ul>
          </section>

          <section className="IncomingRequest">
            <h1>Request</h1>
            <ul>
              {incomingRequests.map(request => {
                return (
                  <section>
                    <li>
                      {request.requestor.name} has requested to dine with you!
                      <br></br>
                      <button onClick={AcceptRequest}>Accept</button>
                      <button onClick={DenieRequest}>deny</button>{' '}
                    </li>
                    <button
                      onClick={() => sendAcceptedRequestToApi(request.id)}
                    >
                      Accept Request
                    </button>
                    <button onClick={() => sendDeniedRequestToApi(request.id)}>
                      Deny Request
                    </button>
                  </section>
                )
              })}
            </ul>
          </section>
        </section>
        <section className="Agreed">
          <h1>You have agreed to these restaurants</h1>
          <ul>
            {friendAcceptedRequests.map(request => {
              // if (request.friendAcceptedRequests==false)
              console.log({ request })
              return (
                <li>
                  you and {request.friend.name} have agreed to these restaurants
                  for {request.description}:
                  <ul>
                    {request.agreements
                      .filter(f => f.friendApproved && f.requestorApproved)
                      .map(agreement => {
                        return <li>{agreement.restaurant.name}</li>
                      })}
                  </ul>
                </li>
              )
            })}
          </ul>
        </section>
        <section className="PendingAndDenied">
          <section className="PendingRequest">
            <h2>Pending request</h2>
            {outgoingRequests.map(request => {
              return (
                <li>you have asked {request.friend.name} to dine with you!</li>
              )
            })}
          </section>

          <section className="Denied">
            <h1>Denied</h1>
            {friendDeniedRequest.map(request => {
              //if (request.IsRequestAccepted == true) {
              return (
                <li>{request.friend.name} has Denied your dine request!</li>
              )
              //}
            })}
          </section>
        </section>
        <Link to="/">SignOut</Link>
      </section>
    </body>
  )
}

export default UserHomePage
