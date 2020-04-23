import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
import PlaceHolder from '../components/Images/placeholder.jpg'
// import Restaurant from './Restaurant'

const FoodYorN = props => {
  console.log(props)
  const restaurantId = props.match.params.restaurantId

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
  if (restaurants) {
    const restaurant = restaurants[currentRestaurantIndex]
    return (
      <body className="FoodYorNBackground">
        <section className="FoodYorN">
          <h1>Please choose yes or no</h1>
          <h2>{restaurant.name}</h2>
          <img src={PlaceHolder} />
          <ul className="YorNUl">
            <li>
              <button onClick={YesButton}>Yes</button>
            </li>
            <li>
              <button>No</button>
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
