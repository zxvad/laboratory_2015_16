import React from 'react'

import AnswerOption from './AnswerOption'

export default class LinearScale extends React.Component {

  static getName() {
    return "Linear scale";
  }

  constructor(props) {
    super(props);
    this.state = {min: 1, max: 10, minLabel: "", maxLabel: ""};
  }

  handleChangeMinSelector = (e) => {
    this.setState({min: e.target.value});
  }

  handleChangeMaxSelector = (e) => {
    this.setState({max: e.target.value});
  }

  render() {
    var min = this.state.min;
    var max = this.state.max;

    var minLabel = this.state.minLabel;
    var maxLabel = this.state.maxLabel;

    let mark = <input type="radio" disabled/>

    var minValueOptions = [];
    for (let i = 0; i <= 1; i++) {
      minValueOptions.push(<option key={i} selected={(i === min)}>{i}</option>);
    }

    var maxValueOptions = [];
    for (let i = 2; i <= 10; i++) {
      maxValueOptions.push(<option key={i} selected={(i === max)}>{i}</option>);
    }

    var optionsList = [];
    for (let i = min; i <= max; i++) {
      optionsList.push(<AnswerOption mark={mark} value={i} key={i} />);
    }

    return <div className="answer-linear-scale">
      {optionsList}

      <div className="answer-linear-scale-min-value-list">
        <select onChange={this.handleChangeMinSelector}>
          {minValueOptions}
        </select>
      </div>
      <div className="answer-linear-scale-max-value-list">
        <select onChange={this.handleChangeMaxSelector}>
          {maxValueOptions}
        </select>
      </div>
    </div>
  }

}