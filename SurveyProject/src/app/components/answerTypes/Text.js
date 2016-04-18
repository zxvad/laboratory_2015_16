import React from 'react'

export default class Text extends React.Component {

  static getName() {
    return 'Text';
  }

  constructor(props) {
    super(props);
    this.state = { value: "" };
  }

  handleOnChange = (e) => {
    this.setState({ value: e.target.value });
  }

  render() {
    return <div className="answer-text">
      <input type="text" onChange={this.handleOnChange} value={this.state.value} readOnly="true" />
    </div>
  }

}
