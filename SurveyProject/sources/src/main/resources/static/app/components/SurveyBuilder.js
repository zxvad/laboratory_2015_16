import React from 'react'

import Survey from './Survey'

import $ from 'jquery'
import jquerySerilizeJSON from 'jquery-serializejson'

export default class SurveyBuilder extends React.Component {

  constructor(props) {
    super(props);
  }

  handleSaveSurvey = (e) => {

    e.preventDefault();
    var data = $(e.target).serializeJSON();
    var jsonData = JSON.stringify(data);
    console.log("date: ", data);
    console.log("jqJSON: " + jsonData);
    //$.ajax({
    //  type: "POST",
    //  dataType: 'json',
    //  contentType: 'application/json',
    //  mimeType: 'application/json',
    //  url: "http://localhost:8080/survey",
    //  data: jsonData,
    //  success: (msg) => console.log(msg)
    //});
  }

  handleKeyPress = (e) => {
    // disable enter for submit form
    if (e.key == "Enter") {
      e.preventDefault();
      return false;
    }
  }

  render() {
    return <div className="builder">
      <form onSubmit={this.handleSaveSurvey} onKeyPress={this.handleKeyPress}>
        <Survey />
        <button className="uui-button dark-green" type="submit">Save Survey</button>
      </form>
     </div>
  }
}
