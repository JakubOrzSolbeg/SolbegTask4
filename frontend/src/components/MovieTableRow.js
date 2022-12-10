import React, {useState} from "react";
import ElementMaker from "../lib/ElementMaker";
import editMovie from "../apiCalls/editMovie";
import removeMovie from "../apiCalls/removeMovie";
import {IconButton} from "@mui/material";
import DeleteIcon from '@mui/icons-material/Delete';
import CheckBoxIcon from '@mui/icons-material/CheckBox';
import markAsRead from "../apiCalls/markAsRead";

function MovieTableRow(props){
    const movie = props.movie

    const [movieName, setmovieName] = useState(movie.name);
    const [showInputMovieName, setShowInputMovieName] = useState(false);

    const [movieAuthor, setmovieAuthor] = useState(movie.author);
    const [showInputMovieAuthor, setShowInputMovieAuthor] = useState(false);

    let defaultMovieName = movie.name;
    let defaultMovieAuthor = movie.author;

    const mark = () => {
        markAsRead(movie.movieId).then(r => {
            if (r.status === 200) {
                props.onStateChanged();
            }
        })
    }

    const remove = () => {
        removeMovie(movie.movieId).then(r => {
            if (r.status === 200) {
                props.onStateChanged();
            }
        });
    }

    const onEdit = () => {
        let movieDto = {
            name: movieName,
            author: movieAuthor
        }
        editMovie(movieDto, movie.movieId).then();
    }

    let watchedButton;
    if (movie.isWatched === false){
        watchedButton =
            <IconButton aria-label="delete" size="small" onClick={mark}>
                <CheckBoxIcon style={{ color: 'green' }}></CheckBoxIcon>
            </IconButton>
    }



    return(
        <tr className={"movie " + (movie.isWatched === true? "movie-watched" : "movie-unwatched")}>
            <td>
                <ElementMaker
                    value={movieName}
                    handleChange={(e) => {
                        setmovieName(e.target.value);
                    }}
                    handleDoubleClick={() => setShowInputMovieName(true)}
                    handleBlur={() => {
                        // Preventing setting value to empty
                        if(movieName === ""){
                            setmovieName(defaultMovieName);
                        }
                        else{
                            defaultMovieName = movieName;
                            onEdit();
                        }
                        setShowInputMovieName(false);

                    }
                    }
                    showInputEle={showInputMovieName}
                />
            </td>
            <td>
                <ElementMaker
                    value={movieAuthor}
                    handleChange={(e) => {
                        setmovieAuthor(e.target.value);
                    }}
                    handleDoubleClick={() => setShowInputMovieAuthor(true)}
                    handleBlur={() => {
                        // Preventing setting value to empty
                        if (movieAuthor === "") {
                            setmovieAuthor(defaultMovieAuthor);
                        } else {
                            defaultMovieAuthor = movieAuthor;
                            onEdit();
                        }
                        setShowInputMovieAuthor(false);
                    }
                    }
                    showInputEle={showInputMovieAuthor}
                />
            </td>
            <td>
                {watchedButton}
                <IconButton aria-label="delete" size="small" onClick={remove}>
                    <DeleteIcon style={{ color: 'red' }}></DeleteIcon>
                </IconButton>
            </td>
        </tr>
    )
}

export default MovieTableRow