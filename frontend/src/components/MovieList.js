import React from "react";
import {GetAllMovies} from "../apiCalls/fetchAllMovies";

class MovieList extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movies: []
        }
    }
    fetchMovieList = () => {
        GetAllMovies()
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                this.setState({
                    isLoaded: true,
                    movies: data
                })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                });
    }
    componentDidMount() {
        this.fetchMovieList();
    }

    render() {
        return (
            <h2> Here will be dragons </h2>
        )
    }
}

export default MovieList;