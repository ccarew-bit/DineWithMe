import React from 'react'
import { Link } from 'react-router-dom'
const TypeFood = () => {
  return (
    <body className="TypeFoodBackground">
      <section className="TypeFood">
        <header>Wonderful!</header>
        <h1>What type of cuisine are you in the mood for?</h1>
        <h2>Please pick 3!</h2>
        <ul className="TypeUl">
          <li>
            <button>Italian</button>
          </li>
          <li>
            <button>Asian</button>
          </li>
          <li>
            <button>American</button>
          </li>
          <li>
            <button>Spanish</button>
          </li>
          <li>
            <button>meditteranian</button>
          </li>
        </ul>
        <Link to="/FoodYorN" className="TypeLink">
          Lets see what's out there!
        </Link>
      </section>
    </body>
  )
}

export default TypeFood
