using Backend.Services.Interfaces;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MoviesController : ControllerBase
{

    private readonly IMovieService _movieService;
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetAll()
    {
        var movieList = await _movieService.GetAllMovies();
        return movieList;
    }

    [HttpGet]
    public async Task<ActionResult<MovieDto>> Get(int movieId)
    {
        var movie = await _movieService.GetMovieById(movieId);
        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpPost]
    public async Task<IActionResult> Add(NewMovieDto newMovie)
    {
        var addResult = await _movieService.AddMovie(newMovie);
        return (addResult) ? Ok() : BadRequest("Error in new movie credentials");
    }

    [HttpPut]
    public async Task<IActionResult> Edit(NewMovieDto editedMovieDto, int movieId)
    {
        var editResult = await _movieService.EditMovie(movieId, editedMovieDto);
        return (editResult) ? Ok() : BadRequest("Bad movie credential or edited movie does not exist");
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int movieId)
    {
        var deleteResult = await _movieService.RemoveMovie(movieId);
        return (deleteResult) ? Ok() : BadRequest("Movie does not exist");
    }

    [HttpPut]
    public async Task<IActionResult> SwapMovies(int movieAid, int movieBid)
    {
        var swapResult = await _movieService.SwapMovies(movieAid, movieBid);
        return (swapResult) ? Ok() : BadRequest("One of the movies does not exists");
    }

    [HttpPut]
    public async Task<IActionResult> MarkAsRead(int movieId)
    {
        var result =await _movieService.MarkAsRead(movieId);
        return (result) ? Ok() : BadRequest("Movie does not exist");
    }
}