import {apiurl} from "./config";

export function GetAllMovies(){
    return fetch(apiurl+"getall");
}
