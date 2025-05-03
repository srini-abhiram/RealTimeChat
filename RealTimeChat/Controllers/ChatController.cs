using Microsoft.AspNetCore.Mvc;
using ChatDbContext.Models;
using Serilog;
using Microsoft.AspNetCore.Authorization;

namespace RealTimeChat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private ChatDbContext.Models.ChatContext _context;

        public ChatController(ChatDbContext.Models.ChatContext context)
        {
            _context = context;
        }

        // GET: api/Chats
        [HttpGet]
        public List<Chats> Get()
        {
            try
            {
                return _context.Chats.ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching Chats");
                return new List<Chats>();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // GET api/Chats/5
        [HttpGet("{id}")]
        public Chats Get(int id)
        {
            try
            {
                return _context.Chats.FirstOrDefault(chat => chat.ChatId == id) ?? new Chats { Message = "" };
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while fetching Chat for id : {id}");
                return new Chats { Message = "" };
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // POST api/Chats
        [HttpPost]
        public IActionResult Post([FromBody] Chats chat)
        {
            try
            {
                if (chat == null || string.IsNullOrWhiteSpace(chat.Message))
                    return BadRequest("Chat message is required.");

                _context.Chats.Add(chat);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = chat.ChatId }, chat);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating Chat");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // PUT api/Chats/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Chats updatedChat)
        {
            try
            {
                var existingChat = _context.Chats.FirstOrDefault(c => c.ChatId == id);
                if (existingChat == null)
                    return NotFound();

                existingChat.Message = updatedChat.Message;
                existingChat.Edited = true;
                existingChat.SentAt = DateTime.UtcNow;

                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while replacing Chat with id:{id}");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // PATCH api/Chats/5
        [HttpPatch("{id}")]
        public IActionResult PatchMessage(int id, [FromBody] string updatedMessage)
        {
            try
            {
                var existingChat = _context.Chats.FirstOrDefault(c => c.ChatId == id);
                if (existingChat == null)
                    return NotFound();

                existingChat.Message = updatedMessage;
                existingChat.Edited = true;
                existingChat.SentAt = DateTime.UtcNow;

                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while modifying Chat with id:{id}");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // PATCH api/Chats/5/Delivered
        [HttpPatch("{id}/Delivered")]
        public IActionResult PatchDeliveryStatus(int id)
        {
            try
            {
                var existingChat = _context.Chats.FirstOrDefault(c => c.ChatId == id);
                if (existingChat == null)
                    return NotFound();

                existingChat.Delivered = true;

                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while modifying delivery status of Chat with id:{id}");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // PATCH api/Chats/5/Read
        [HttpPatch("{id}/Read")]
        public IActionResult PatchReadStatus(int id)
        {
            try
            {
                var existingChat = _context.Chats.FirstOrDefault(c => c.ChatId == id);
                if (existingChat == null)
                    return NotFound();

                existingChat.Read = true;

                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while modifying read status of Chat with id:{id}");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

        // DELETE api/Chats/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var chat = _context.Chats.FirstOrDefault(c => c.ChatId == id);
                if (chat == null)
                    return NotFound();

                _context.Chats.Remove(chat);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while deleting Chat with id:{id}");
                return BadRequest();
            }
            finally
            {
                Log.CloseAndFlushAsync();
            }
        }

    }
}
