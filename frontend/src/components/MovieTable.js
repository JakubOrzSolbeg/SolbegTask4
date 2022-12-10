import React from "react";
import MovieTableRow from "./MovieTableRow";

function MovieTable(props){
    const movies = props.movies;
    return (
        <div className={"movie-list"}>
            <table className={"movie-table"}>
                <thead>
                <tr>
                    <th>
                        Title
                    </th>
                    <th>
                        Director
                    </th>
                    <th>
                        Actions
                    </th>
                </tr>
                </thead>
                <tbody>
                    {
                        movies.map(m => <MovieTableRow movie={m} key={m.movieId} onStateChanged={props.onStateChanged} />)
                    }
                </tbody>
            </table>
        </div>
    )
}

export default MovieTable