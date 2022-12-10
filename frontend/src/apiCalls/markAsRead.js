import {apiurl} from "./config";

function markAsRead(movieId){
    let requestOptions = {
        method: 'PUT'
    };
    return fetch(apiurl + "markasread?movieId=" + movieId, requestOptions);
}

export default markAsRead