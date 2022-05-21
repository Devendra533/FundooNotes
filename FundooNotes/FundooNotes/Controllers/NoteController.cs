using BusinessLayer.Interfaces;
using DataBaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DBcontext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {



        FundooContext fundoo;
        INoteBL noteBL;

        public NoteController(FundooContext fundoo, INoteBL noteBL)
        {
            this.fundoo = fundoo;
            this.noteBL = noteBL;
        }
        [Authorize]
        [HttpPost("AddNote")]

        public async Task<ActionResult> AddUser(NotesPostModel notesPostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.noteBL.AddNote(notesPostModel, userId);

                return this.Ok(new { success = true, message = $"User Added Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("Update/{noteId}")]
        public async Task<ActionResult> UpdateNote(int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == UserId && u.NoteID == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Failed to Update note" });
                }
                await this.noteBL.UpdateNote(UserId, noteId, noteUpdateModel);
                return this.Ok(new { success = true, message = "Note Updated successfully!!!" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
        [Authorize]
        [HttpDelete("Delete/{noteId}")]
        public async Task<ActionResult> DeleteNote(int noteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == UserId && u.NoteID == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Oops! This note is not available " });

                }
                await this.noteBL.DeleteNote(noteId, UserId);
                return this.Ok(new { success = true, message = "Note Deleted Successfully" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
        [Authorize]
        [HttpPut("ChangeColour/{noteId}/{colour}")]
        public async Task<ActionResult> ChangeColour(int noteId, string colour)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == UserId && u.NoteID == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Sorry! Note does not exist" });
                }

                await this.noteBL.ChangeColour(UserId, noteId, colour);
                return this.Ok(new { success = true, message = "Note Colour Changed Successfully " });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        [Authorize]
        [HttpPut("ArchiveNote/{noteId}")]
        public async Task<ActionResult> IsArchieveNote(int noteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);

                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Failed to archieve notes or Id does not exists" });
                }
                await this.noteBL.ArchiveNote(userId, noteId);
                return this.Ok(new { success = true, message = "Note Archieved successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
