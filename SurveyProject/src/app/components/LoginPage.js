import React from 'react'
import LoginForm from './forms/LoginForm'

export default class LoginPage extends React.Component {

  render() {
    return <div className="login-page">
      <div className="login-page__header">

      </div>
      <div className="login-page__body">
        <LoginForm />
      </div>
    </div>
  }

}
