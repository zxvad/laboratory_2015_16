import React from 'react'

// answer types
import Text from './answerTypes/Text'
import MultiChoose from './answerTypes/MultiChoose'

export default class Answer extends React.Component {

  constructor(props) {
    super(props);
  }

  render() {
    let type = this.props.type;

    let answerTypes = [
      <Text name="Text" />,
      <MultiChoose name="Multiple Choose" />
    ];

    return <div className="answer">
      {answerType}
    </div>
  }
}
