import React from "react";
import MovieTableRow from "./MovieTableRow";
import {DragDropContext, Droppable} from "react-beautiful-dnd";


function MovieTable(props){

    const movies = props.movies;

    const handleOnDragEnd = (result) =>{
        console.log(result)
        if (!result.destination){
            return;
        }
        props.onReorder(result.source.index, result.destination.index)
    }

    return (
        <div className={"movie-list"}>
            <DragDropContext onDragEnd={handleOnDragEnd}>
                <Droppable droppableId={"movies-droppable"}>
                    {(provided) => (
                        <table className={"movie-table"} {...provided.droppableProps} ref={provided.innerRef}>
                            <thead>
                            <tr>
                                <th>
                                    Title
                                </th>
                                <th>
                                    Director
                                </th>
                                <th>
                                    Actions
                                </th>
                            </tr>
                            </thead>
                            <tbody>
                            {
                                movies.map((m, index) => {
                                        return <MovieTableRow
                                            movie={m}
                                            key={m.movieId}
                                            index={index}
                                            onStateChanged={props.onStateChanged}
                                        />
                                    }
                                )}
                                {provided.placeholder}
                            </tbody>
                        </table>

                    )
                    }

                </Droppable>
            </DragDropContext>
        </div>
    )
}

export default MovieTable