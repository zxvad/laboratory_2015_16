import React from 'react'
import Header from './theme/Header'

export default class Index extends React.Component {

  render() {
    return <div className="index">
      <div className="index__header">
        <Header />
      </div>
      <div className="index__content">
        {this.props.children}
      </div>
    </div>
  }

}
