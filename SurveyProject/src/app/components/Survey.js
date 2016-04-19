import React from 'react'

import Question from './Question'

export default class Survey extends React.Component {

  constructor(props) {
    super(props);
    this.state = {title: "", description: "", questions: []};
  }

  handleOnChangeTitle = (e) => {
    this.setState({title: e.target.value});
  }

  handleOnChangeDescription = (e) => {
    this.setState({description: e.target.value});
  }

  handleSubmit = (e) => {
    this.handleAddNewQuestion(e);
  }

  handleAddNewQuestion = (e) => {
    let questions = this.state.questions;
    questions.push(<Question />);
    this.setState({questions: questions});
  }

  render() {
    var questions = this.state.questions;

    return (
      <div className="survey">
        <p>
          <label>Title</label>
          <input className="uui-form-element" name="title" type="text" value={this.state.title} onChange={this.handleOnChangeTitle}/>
        </p>

        <p>
          <label>Description</label>
          <textarea className="uui-form-element" name="description" value={this.state.description}
                    onChange={this.handleOnChangeDescription}/>
        </p>

        <p>
          <button className="uui-button dark-green" type="button" onClick={this.handleSubmit}>Add Question</button>
        </p>

        <div>
          <ul>
            {questions.map((item) => {
              return <div>
                <li>{item}</li>
              </div>;
            })}
          </ul>
        </div>
      </div>
    );
  }

}
