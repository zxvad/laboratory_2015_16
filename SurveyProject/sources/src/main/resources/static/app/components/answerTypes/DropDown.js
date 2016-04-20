import React from 'react'

import BaseMultiOptionType from './BaseMultiOptionType'

export default class DropDown extends React.Component {

  static getName() {
    return "DropDown";
  }

  constructor(props) {
    super(props);
  }

  render() {
    let mark = <input type="radio" disabled/>

    return <div className="answer-drop-down">
      <BaseMultiOptionType mark={mark}/>
    </div>
  }

}