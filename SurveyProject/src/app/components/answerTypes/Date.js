import React from 'react'

export default class Date extends React.Component {

  static getName() {
    return "Date";
  }

  constructor(props) {
    super(props);
  }

  render() {
    return <div className="answer-date">
      <input type="date" readOnly="true" />
    </div>
  }

}