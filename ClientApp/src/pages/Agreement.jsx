import React from 'react'
import { Link } from 'react-router-dom'
import PlaceHolder from '../components/Images/placeholder.jpg'

const Agreement = () => {
  return (
    <body className="AgreementBackground">
      <section className="AgreementPage">
        <header>Bon Apetit!</header>
        <h1>You have both chosen</h1>
        <h2>(restaurant)</h2>
        <ul>
          <img src={PlaceHolder} className="AgreementPic" />
        </ul>
        <Link to="/Confirmation" className="AgreementLink">
          Are you Hungry
        </Link>
      </section>
    </body>
  )
}

export default Agreement
