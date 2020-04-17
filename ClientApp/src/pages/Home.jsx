import React from 'react'
import { Link } from 'react-router-dom'
import NextTime from './NextTime'
import TypeFood from './TypeFood'
import FoodYorN from './FoodYorN'
import HomeImage from '../components/Images/Home.jpg'
// import './styles/Home-Page'

export function Home() {
  return (
    <body className="HomePageBackground">
      {/* <img
        src="./components/Images/Home.jpg"
        className="HomePageBackground"
      ></img> */}
      {/* <section className="HomePageBackground"></section> */}
      <main class="HomePage">
        {/* eventually a logo */}
        <header>Dine With Me</header>
        <h1>Would you like to dine with (user) at (time)?</h1>
        <ul>
          <li>
            <Link to="/TypeFood" className="link">
              Let's Eat!
            </Link>
          </li>
          <li>
            <Link to="/NextTime" className="link">
              Maybe next time.
            </Link>
          </li>
        </ul>
      </main>
    </body>
  )
}
