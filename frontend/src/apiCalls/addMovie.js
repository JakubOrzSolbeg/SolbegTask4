import {apiurl} from "./config";

const addMovie = (movieDto) =>{
    let requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(movieDto)
    };
    return fetch(apiurl + "add", requestOptions);
}

export default addMovie