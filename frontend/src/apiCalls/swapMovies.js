import {apiurl} from "./config";

function swapMovies(movieAid, movieBid){

    let requestOptions = {
        method: 'PUT'
    };
    return fetch(apiurl + "swapmovies?movieAId=" + movieAid+"&movieBId="+movieBid, requestOptions);
}

export default swapMovies;