using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300045.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        public static readonly List<Movie> movie = new()
        {
           new Movie("The Shawshank Redemption", "Frank Drabont", new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton" },"A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion" ),
           new Movie("The Godfather", "Francis Ford Coppola", new List<string>{"Marlon Brando", "Al Pacino", "James Caan" },"The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
           new Movie("The Dark Knight", "Christopher Nolan", new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"},"When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie()
        {
            return Ok(movie);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie>GetMovieByIndex(int id)
        {
            if (id < 0 || id >= movie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            return Ok(movie[id]);
        }

        [HttpPost]
        public void AddMovie([FromBody] Movie newMovie)
        {
            movie.Add(newMovie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            movie.RemoveAt(id);
            return Ok(new { message = "Movie telah dihapus"});
        }
    }
}
