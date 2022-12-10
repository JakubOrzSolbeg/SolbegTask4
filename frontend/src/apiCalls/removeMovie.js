import {apiurl} from "./config";

function removeMovie(movieId){
    let requestOptions = {
        method: 'DELETE'
    };
    return fetch(apiurl + "delete?movieId=" + movieId, requestOptions);
}

export default removeMovie