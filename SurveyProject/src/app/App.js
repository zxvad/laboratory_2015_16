import React from 'react'
import ReactDOM from 'react-dom'
import {Router, Route, browserHistory} from 'react-router'

// Components
import Index from './components/Index'
import LoginPage from './components/LoginPage'
import SurveyBuilder from './components/SurveyBuilder'
import Survey from './components/Survey'

export default class App extends React.Component {

  render() {
    return <Router history={browserHistory}>
      <Route path="/login" component={LoginPage}/>
      <Route path="/" component={Index}>
        <Route path="builder" component={SurveyBuilder}/>
      </Route>
    </Router>
  }

}

window.addEventListener('DOMContentLoaded', function () {
  ReactDOM.render(
    React.createElement(App),
    document.getElementById('main')
  );
});
