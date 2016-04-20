import React from 'react'

export default class AnswerOption extends React.Component {

  constructor(props) {
    super(props);
    this.state = {value: this.props.value, mark: this.props.mark};
  }

  handleOnChangeValue = (e) => {
    this.setState({value: e.target.value});
  }

  render() {
    let mark = this.state.mark;
    let value = this.state.value;
    let key = this.props.key;

    return <div className="answer-option-block" key={key}>
      <div className="answer-option-mark">
        {mark}
      </div>
      <div className="answer-option">
        <input type="text" name="question[][answerOptions][][title]" value={value} onChange={this.handleOnChangeValue} />
      </div>
    </div>
  }

}