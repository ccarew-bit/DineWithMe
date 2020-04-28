import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
import { Redirect } from 'react-router-dom'
import PlaceHolder from '../components/Images/placeholder.jpg'
import { request } from 'http'
// import Restaurant from './Restaurant'

const FoodYorN = props => {
  // const [newAgreement, setNewAgreement] = useState({})
  const requestId = parseInt(props.match.params.requestId)

  // const updateAgreementData = e => {
  //   const key = e.target.name
  //   const value = e.target.value
  //   setNewAgreement(prevRequest => {
  //     prevRequest[key] = value
  //     return { ...prevRequest }
  //   })
  // }

  const sendAgreementToApi = async () => {
    const resp = await axios.post(
      `/api/Agreement`,
      {
        requestId: requestId,
        restaurantId: restaurants[currentRestaurantIndex].id,
      },
      {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
      }
    )
    if (resp.status == 200 || resp.status == 201) {
      setCurrentRestaurantIndex(currentRestaurantIndex + 1)
    } else {
    }
  }

  //////////////// being able to click through retaurants
  console.log(props)

  const [restaurants, setRestaurants] = useState()
  const [currentRestaurantIndex, setCurrentRestaurantIndex] = useState(0)

  const getRestaurantData = async () => {
    const resp = await axios.get('/api/Restaurant/')
    console.log(resp.data)
    setRestaurants(resp.data)
  }

  useEffect(() => {
    // make our API call on page load
    getRestaurantData()
  }, [])
  const YesButton = event => {
    setCurrentRestaurantIndex(currentRestaurantIndex + 1)
  }
  const NoButton = event => {
    setCurrentRestaurantIndex(currentRestaurantIndex + 1)
  }
  if (restaurants) {
    const restaurant = restaurants[currentRestaurantIndex]
    if (restaurant == null) {
      return (
        <section>
          <Redirect to="/UserHome" />
        </section>
      )
    }
    return (
      <body className="FoodYorNBackground">
        <section className="FoodYorN">
          <h1>Please choose yes or no</h1>
          <h2>{restaurant.name}</h2>
          <img src={restaurant.imageUrl} />
          <h3>
            {restaurant.expenses} ~ {restaurant.type} ~ {restaurant.location}
          </h3>
          <ul className="YorNUl">
            <li>
              <button onClick={sendAgreementToApi}>Yes</button>
            </li>
            <li>
              <button onClick={NoButton}>No</button>
            </li>
          </ul>

          <Link to="/Agreement" className="YorNLink">
            We have an agreement!
          </Link>
        </section>
      </body>
    )
  } else {
    return <h1>loading</h1>
  }
}

export default FoodYorN
