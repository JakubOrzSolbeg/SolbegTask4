import {apiurl} from "./config";

const editMovie = (movieDto, movieId) =>{
    let requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(movieDto)
    };
    return fetch(apiurl + "edit?movieId=" + movieId, requestOptions);
}

export default editMovie