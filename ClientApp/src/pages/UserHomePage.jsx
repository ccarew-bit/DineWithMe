import React, { useEffect, useState } from 'react'
import { Link, Redirect } from 'react-router-dom'
import axios from 'axios'

const UserHomePage = () => {
  const [profile, setProfile] = useState({})
  const [incomingRequests, setIncomingRequests] = useState([])
  const [outgoingRequests, setOutgoingRequests] = useState([])
  const [friendAcceptedRequests, setFriendAcceptedRequests] = useState([])
  const [friendDeniedRequest, setFriendDeniedRequest] = useState([])
  const [agreements, setAgreement] = useState([])
  const [requestIdToRedirectTo, setRequestIdToRedirectTo] = useState(0)
  const [deleteRequest, setDeleteRequest] = useState([])

  useEffect(() => {
    loadProfile()
    incomingRequest()
    outgoingRequest()
    friendHasAcceptedRequest()
    friendHasDeniedRequest()
    AgreedOnRequests()
  }, [])

  const loadProfile = async () => {
    const resp = await axios.get('/api/profile', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setProfile(resp.data)
  }

  ///////////Incoming
  const incomingRequest = async () => {
    const resp = await axios.get('/api/profile/IncomingRequests', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setIncomingRequests(resp.data)
    outgoingRequest()
  }

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

  console.log(agreements)
  //////////////////////////////////delete request
  const DeleteRequest = async id => {
    const resp = await axios.delete(`/api/Request/${id}`, {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      },
    })
    console.log(resp.data)
    setDeleteRequest(resp.data)
    friendHasDeniedRequest()
    // outgoingRequest()
    // incomingRequest()
  }

  ////////////////accept request

  const sendAcceptedRequestToApi = async id => {
    const resp = await axios.post(
      `/api/Request/${id}/Accepted`,
      {},
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

  const sendDeniedRequestToApi = async id => {
    const resp = await axios.post(
      `/api/Request/${id}/Denied`,
      {},
      {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
      }
    )
    incomingRequest()
  }

  //////////////////////////
  return (
    <div className="UserHomeBackground">
      <section className="UserHomePage">
        <header>Welcome {profile.name} !</header>
        <Link to="/SendRequest" className="LinktoRequestPage">
          Would you like to make a dine request?
        </Link>
        <section className="PandIRequest">
          <section className="AcceptedRequest">
            <h1>Accepted</h1>

            <ul>
              {friendAcceptedRequests
                .filter(
                  request =>
                    request.agreements.filter(
                      agreement => agreement.requestorApproved == true
                    ).length === 0
                )
                // .filter(f => f.friendApproved == false)
                .map(request => {
                  // if (request.requestorapproved == false)
                  return (
                    <li key={request.id}>
                      {request.friend.name} has accepted your dine request for{' '}
                      {request.description} at {request.time}!
                      {/* .moment().format('MMMM Do YYYY, h:mm:ss a') */}{' '}
                      <br></br>
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
                  <section key={request.id}>
                    <li>
                      {request.requestor.name} has requested to dine with you
                      for {request.description} at
                      {request.time}
                      <br></br>
                    </li>
                    <button
                      onClick={() => sendAcceptedRequestToApi(request.id)}
                    >
                      Accept
                    </button>
                    <button onClick={() => sendDeniedRequestToApi(request.id)}>
                      Deny
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
                <ul key={request.id}>
                  <li className="AgreedRequestList">
                    you and {request.friend.name} have agreed to these
                    restaurants for {request.description} at {request.time}:
                  </li>
                  {request.agreements
                    .filter(f => f.friendApproved && f.requestorApproved)
                    .map(agreement => {
                      return (
                        <li key={agreement.id}>{agreement.restaurant.name}</li>
                      )
                    })}
                  <br></br>
                </ul>
              )
            })}
          </ul>
          <br></br>
        </section>
        <section className="PendingAndDenied">
          <section className="PendingRequest">
            <h2>Pending request</h2>
            {outgoingRequests.map(request => {
              return (
                <ul key={request.id}>
                  <li>
                    You have asked {request.friend.name} to dine with you for{' '}
                    {request.description} at {request.time}!
                  </li>
                  <button onClick={() => DeleteRequest(request.id)}>
                    Delete Request
                  </button>
                </ul>
              )
            })}
          </section>

          <section className="Denied">
            <h1>Denied</h1>
            {friendDeniedRequest.map(request => {
              //if (request.IsRequestAccepted == true) {
              return (
                <ul key={request.id}>
                  <li>
                    {request.friend.name} has Denied your dine request for{' '}
                    {request.description} at {request.time}!
                    <button onClick={() => DeleteRequest(request.id)}>
                      Delete Request
                    </button>
                  </li>
                </ul>
              )
            })}
          </section>
        </section>
        <Link to="/">SignOut</Link>
      </section>
    </div>
  )
}

export default UserHomePage
