import './App.css';
import { Component } from 'react';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      notes:[]
    }
  }

  API_URL = "http://localhost:5297/";

  componentDidMount() {
    this.refreshNotes();
  }

  async refreshNotes() {
    fetch(this.API_URL + "api/TodoApp/GetNotes")
    .then(response => response.json())
    .then(data => {
      this.setState({ notes: data })
    })
    .catch(error => {
      console.error("Error :", error);
    });
  }

  async addClick() {
    const newNotes = document.getElementById("newNotes").value;
    const data = new FormData();
    data.append("newNotes", newNotes);

    fetch(this.API_URL + "api/TodoApp/AddNotes", {
      method: "POST",
      body: data
    }).then( response => response.json())
    .then((result) => {
      alert(result);
      this.refreshNotes();
    })
    .catch(error => {
      console.error("Error :", error);
    });
  }

  async deleteClick(id) {    
    fetch(this.API_URL + "api/TodoApp/DeleteNotes?id="+id, {
      method: "DELETE",      
    }).then( response => response.json())
    .then((result) => {
      alert(result);
      this.refreshNotes();
    })
    .catch(error => {
      console.error("Error :", error);
    });
  }

  render() {
    const { notes } = this.state;
    return (
      <div className="App">
        <h2>Todo App</h2>
          <input id="newNotes" />&nbsp;
          <button onClick={() => this.addClick()}>Add Notes</button>
        {notes.map(note =>
          <p key={note.id}>
            <b>* {note.description}</b>&nbsp;
            <button onClick={() => this.deleteClick(note.id)}>Delete Notes</button>
          </p>
        )}
      </div>
    );
  }
}

export default App;
