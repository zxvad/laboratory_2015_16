import React from 'react'

import Answer from './Answer'
import AnswerTypes from './AnswerTypes'

export default class AnswerTypeList extends React.Component {

  static defaultProps = {
    onAnswerAdd: () => {
    }
  };

  static propTypes = {
    onAnswerAdd: React.PropTypes.func
  };

  constructor(props) {
    super(props);
  }

  selectAnswerType = (e) => {
    let index = parseInt(e.target.value);

    if (index < 0) return;

    this.props.onAnswerAdd(index);
  }

  render() {

    let typeOptions = AnswerTypes.getListNames().map((name, i) => {
      return <option value={i} key={i}>{name}</option>;
    });

    return <div className="answer-list">
      <div>
        <select onChange={this.selectAnswerType} name="question[][type]">
          <option value="-1">Select answer type ...</option>
          {typeOptions}
        </select>
      </div>
    </div>
  }
}
