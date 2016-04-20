import React from 'react'

import AnswerTypeList from './AnswerTypeList'
import AnswerTypes from './AnswerTypes'

export default class Question extends React.Component {

  constructor(props) {
    super(props);
    this.state = {type: '', isSelected: false};
  }

  addAnswerHandler = (type) => {
    this.setState({isSelected: true});
    this.setState({type: type});
  }

  render() {
    let isSelected = this.state.isSelected;
    let component = '';
    if (isSelected) {
      let type = this.state.type;
      component = React.createElement(AnswerTypes.getByIndex(type));
    }


    return <div className="question">
      <div className="question-title">
        <input type="text" name="question[][title]" placeholder="Question title.."/>
      </div>
      <div className="answer-option-list">
        <AnswerTypeList onAnswerAdd={this.addAnswerHandler} />
      </div>
      <div>
        {component}
      </div>
    </div>
  }
}
