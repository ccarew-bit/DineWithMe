import React, { Component } from 'react'
import { Route, Switch } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './pages/Home'
import TypeFood from './pages/TypeFood'
import NextTime from './pages/NextTime'
import FoodYorN from './pages/FoodYorN'
import Agreement from './pages/Agreement'
import Login from './pages/LoginPage'
import SignUp from './pages/SignUpPage'
import UserHome from './pages/UserHomePage'
import SendRequest from './pages/SendRequestPage'
import Confirmation from './pages/Confirmation.jsx'
import NotFound from './pages/NotFound'
import './custom.scss'
export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <Layout>
        <Switch>
          <Route exact path="/Home" component={Home} />
          <Route exact path="/TypeFood" component={TypeFood} />
          <Route exact path="/NextTime" component={NextTime} />
          <Route exact path="/FoodYorN" component={FoodYorN} />
          <Route exact path="/Agreement" component={Agreement} />
          <Route exact path="/Confirmation" component={Confirmation} />\
          <Route exact path="/" component={Login} />
          <Route exact path="/SignUp" component={SignUp} />
          <Route exact path="/UserHome" component={UserHome} />
          <Route exact path="/SendRequest" component={SendRequest} />
          <Route exact path="*" component={NotFound} />
        </Switch>
      </Layout>
    )
  }
}
