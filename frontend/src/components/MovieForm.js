import React from "react";

function MovieForm(){
    return(
        <form className={"movie-form"}>
            <input type={"text"} placeholder={"Movie name"}/>
            <input type={"text"} placeholder={"Director"}/>
            <input type={"button"} value={"+"} onClick={() => console.log("Click was made")}/>
        </form>
    )
}

export default MovieForm