import React from 'react'
import { Link } from 'react-router-dom'
import PlaceHolder from '../components/Images/placeholder.jpg'

const FoodYorN = () => {
  return (
    <body className="FoodYorNBackground">
      <section className="FoodYorN">
        <h1>Please choose yes or no</h1>
        <h2>(restaurant name)</h2>
        <img src={PlaceHolder} />
        <ul className="YorNUl">
          <li>
            <button>Yes</button>
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
}

export default FoodYorN
