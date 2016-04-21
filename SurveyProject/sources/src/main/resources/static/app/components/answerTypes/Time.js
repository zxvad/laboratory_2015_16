import React from 'react'

export default class Time extends React.Component {

  static getName() {
    return "Time";
  }

  constructor(props) {
    super(props);
  }

  render() {
    return <div className="answer-time">
      <input type="time" readOnly="true" />
    </div>
  }

}