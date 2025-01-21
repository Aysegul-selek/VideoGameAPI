using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameAPI.Data;
using VideoGameAPI.Entity;

namespace VideoGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<VideoGame>>GetVideoGameById(int id)
        {
            var game =await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();;
            _context.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame newGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return BadRequest();

            game.Title = newGame.Title;
            game.Platform = newGame.Platform;
            game.Developer = newGame.Developer;
            game.Publisher = newGame.Publisher;
            await  _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync( id);
            if (game is null)
                return BadRequest();

           _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();

            }
        }
}
