import {apiurl} from "./config";

function swapMovies(movieOrder){

    let requestOptions = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(movieOrder)
    };
    console.log(JSON.stringify(movieOrder));
    return fetch(apiurl + "RearangeMovies", requestOptions);
}

export default swapMovies;