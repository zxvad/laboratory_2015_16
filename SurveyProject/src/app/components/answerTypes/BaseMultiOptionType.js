import React from 'react'

import AnswerOption from './AnswerOption'

export default class BaseMultiOptionType extends React.Component {

  constructor(props) {
    super(props);
    this.state = {options: [], value: ""};
  }

  handleAddNewOption = (e) => {
    let options = this.state.options;
    let value = e.target.value;
    let mark = this.props.mark;
    let key = options.length;


    if (e.key == "Enter") {
      let answerOption = <AnswerOption value={value} mark={mark} key={key}/>
      options.push(answerOption);
      this.setState({options: options});

      // clear input value
      this.state.value = "";
      this.forceUpdate();
    }
  }

  handleOnChangeValue = (e) => {
    this.setState({value: e.target.value});
  }

  handleRemoveOption = (e) => {
    let key = parseInt(e.target.value);
    let options = this.state.options;
    options = options.filter((element, index) => index !== key);
    this.setState({options: options});
  }

  render() {
    let options = this.state.options.map((option, index) => {
      return <div>
        {option}
        <div>
          <button type="submit" name="removeOption" value={index} onClick={this.handleRemoveOption}>Remove option
          </button>
        </div>
      </div>
    });
    let value = this.state.value;

    return <div>
      <div className="answer-options">
        <ul>
          <div className="answer-options-wrapper">
            {options}
          </div>
        </ul>
      </div>
      <div>
        <input type="text" placeholder="New answer option" value={value} onKeyDown={this.handleAddNewOption}
               onChange={this.handleOnChangeValue}/>
      </div>
    </div>
  }
}