import React from 'react'

import Text from './answerTypes/Text'
import MultiChoose from './answerTypes/MultiChoose'
import Checkboxes from './answerTypes/Checkboxes'
import DropDown from './answerTypes/DropDown'
import Date from './answerTypes/Date'
import Time from './answerTypes/Time'
import LinearScale from './answerTypes/LinearScale'

export default class AnswerTypes {

  static types = [
    Text,
    MultiChoose,
    Checkboxes,
    DropDown,
    Date,
    Time,
    LinearScale
  ];

  static getByIndex(index) {
    return AnswerTypes.types[index];
  }

  static getList() {
    return AnswerTypes.types;
  }

  static getListNames() {
    return AnswerTypes.types.map((type) => {
      return type.getName();
    })
  }

}
