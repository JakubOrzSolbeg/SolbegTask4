const apiurl = "http://localhost:5213/movies/getall";

export function GetAllMovies(){
    return fetch(apiurl);
}
