import React from "react";
import {GetAllMovies} from "../apiCalls/fetchAllMovies";
import MovieTable from "./MovieTable";
import MovieForm2 from "./MovieForm2";

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
        const {error, isLoaded, movies} = this.state;
        let content;

        if (error){
            content = <p>Error in fetching data</p>
        }
        else if (!isLoaded){
            content = <p> Loading data </p>
        }
        else{
            content = <MovieTable movies={movies} onStateChanged={this.fetchMovieList}/>
        }

        return(
            <div className={"main-content"}>
                <MovieForm2 onStateChanged={this.fetchMovieList}/>
                {content}
            </div>
        )
    }
}

export default MovieList;