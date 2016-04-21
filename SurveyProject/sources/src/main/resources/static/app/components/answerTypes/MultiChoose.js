import React from 'react'

import BaseMultiOptionType from './BaseMultiOptionType'

export default class MultiChoose extends React.Component {

  static getName() {
    return 'Multiple Choose';
  }

  constructor(props) {
    super(props);
  }

  render() {
    let mark = <input type="radio" disabled />

    return <div className="answer-multi-choose">
      <BaseMultiOptionType mark={mark} />
    </div>
  }

}
