import React from "react";
import {GetAllMovies} from "../apiCalls/fetchAllMovies";
import MovieTable from "./MovieTable";
import MovieForm2 from "./MovieForm2";
import swapMovies from "../apiCalls/swapMovies";

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

    handleOrderChange = (source, destination) => {
        console.log("source: "+ source+" destination: "+ destination)
        let items = Array.from(this.state.movies);
        let sourceMovieId = items[source].movieId;
        let destinationMovieId = items[destination].movieId;

        let [reordered] = items.splice(source, 1)
        items.splice(destination, 0, reordered)
        let orderList = items.map((movie) => movie.movieId);
        console.log(orderList);

        this.setState({movies: items});


        swapMovies(sourceMovieId, destinationMovieId).then(r => console.log(r.status))
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
            content = <MovieTable movies={movies} onStateChanged={this.fetchMovieList} onReorder={this.handleOrderChange}/>
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