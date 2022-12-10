import React from "react";
import addMovie from "../apiCalls/addMovie";

class MovieForm2 extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            author: ''
        }

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        addMovie(this.state).then((result) => {
            this.setState({name: ""})
            this.setState({author: ""})
            if (result.status === 200) {
                this.props.onStateChanged();
            }
        })
        event.preventDefault();
    }

    handleChange(event) {

        this.setState({
            [event.target.name]: event.target.value
        });
    }

    render() {
        return (
            <form className={"movie-form"} onSubmit={this.handleSubmit}>
                <input type={"text"} name={"name"} placeholder={"Movie name"} onChange={this.handleChange} value={this.state.name}/>
                <input type={"text"} name={"author"} placeholder={"Director"} onChange={this.handleChange} value={this.state.author}/>
                <input type={"submit"} value={"Add to list"}/>
            </form>
        );
    }
}

export default MovieForm2