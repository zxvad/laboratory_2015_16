import React from 'react'

import BaseMultiOptionType from './BaseMultiOptionType'

export default class Checkboxes extends React.Component {

  static getName() {
    return "Checkboxes";
  }

  constructor(props) {
    super(props);
  }

  render() {
    let mark = <input type="checkbox" disabled/>

    return <div className="answer-checkboxes">
      <BaseMultiOptionType mark={mark}/>
    </div>
  }

}