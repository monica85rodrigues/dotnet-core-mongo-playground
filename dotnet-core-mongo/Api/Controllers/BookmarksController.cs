using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookmarksController : ControllerBase
    {
        private static readonly ConcurrentDictionary<Guid, Bookmark> _bookmarks = new();
        
        private readonly ILogger<BookmarksController> _logger;

        public BookmarksController(ILogger<BookmarksController> logger)
        {
            _logger = logger;

            var id = Guid.NewGuid();
            _bookmarks.TryAdd(id, new Bookmark {Id = id, Name = "bookmark 1"});
            id = Guid.NewGuid();
            _bookmarks.TryAdd(id, new Bookmark {Id = id, Name = "bookmark 2"});
            id = Guid.NewGuid();
            _bookmarks.TryAdd(id, new Bookmark {Id = id, Name = "bookmark 3"});
        }

        [HttpGet]
        public async Task<IActionResult> GetALlBookmarks()
        {
            return Ok(await Task.FromResult(_bookmarks.Values));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookmarkById(Guid id)
        {
            if (_bookmarks.TryGetValue(id, out Bookmark bookmark))
            {
                return Ok(await Task.FromResult(bookmark));
            }
            return NotFound();
        }
    }
}