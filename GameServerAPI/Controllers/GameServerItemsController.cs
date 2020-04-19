using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameServerAPI.Models;

namespace GameServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameServerItemsController : ControllerBase
    {

        private List<GameServerItem> gameServerItem = new List<GameServerItem>()
        {
             new GameServerItem { GameName = "AnimalCrossing", Playstation4 = "NA", XboxOne = "NA", Switch = "Available", PC="NA",Rating=5 },
             new GameServerItem { GameName = "GTA", Playstation4 = "Available", XboxOne = "Available", Switch = "NA", PC="Available",Rating=4.8 },
             new GameServerItem { GameName = "Overwatch", Playstation4 = "Available", XboxOne = "Available", Switch = "Available", PC="Available",Rating=4 }
        };


        private readonly GameServerContext _context;

        public GameServerItemsController(GameServerContext context)
        {
            _context = context;
        }

        //Get all games
        //GET: api/GameServerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameServerItem>>> GetGameServerItems()
        {
            return await _context.GameServerItems.ToListAsync();
        }


        //GET game by id
        // GET: api/GameServerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameServerItem>> GetGameServerItem(long id)
        {
            var gameServerItem = await _context.GameServerItems.FindAsync(id);

            if (gameServerItem == null)
            {
                return NotFound();
            }

            return gameServerItem;
        }

        [HttpGet("all")]
        public IEnumerable<GameServerItem> GetAll()
        {
            return gameServerItem.OrderBy(w => w.GameName);       // 200 OK, weather serialized in response body
        }

        //Get game by name
        //GET api/GameServerItems/gamename/GameNameHere
        [HttpGet("gameName/{gameName:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GameServerItem> GetgameGames(string gamename)
        {
            GameServerItem gameGame = gameServerItem.SingleOrDefault(w => w.GameName.ToUpper() == gamename.ToUpper());
            if (gameGame == null)
            {
                return NotFound();              // 404
            }
            return Ok(gameGame);             // 200
        }

        // PUT: api/GameServerItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameServerItem(long id, GameServerItem gameServerItem)
        {
            if (id != gameServerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameServerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameServerItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameServerItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameServerItem>> PostGameServerItem(GameServerItem gameServerItem)
        {
            _context.GameServerItems.Add(gameServerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGameServerItem), new { id = gameServerItem.Id }, gameServerItem);
        }

        // DELETE: api/GameServerItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameServerItem>> DeleteGameServerItem(long id)
        {
            var gameServerItem = await _context.GameServerItems.FindAsync(id);
            if (gameServerItem == null)
            {
                return NotFound();
            }

            _context.GameServerItems.Remove(gameServerItem);
            await _context.SaveChangesAsync();

            return gameServerItem;
        }

        private bool GameServerItemExists(long id)
        {
            return _context.GameServerItems.Any(e => e.Id == id);
        }
    }
}
