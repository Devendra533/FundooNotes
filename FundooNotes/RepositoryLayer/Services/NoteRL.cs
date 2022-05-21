using DataBaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.DBcontext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooContext fundoo; 
       

        public IConfiguration Configuration { get; }
        public NoteRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.Configuration = configuration;
        }
        public async Task AddNote(NotesPostModel notesPostModel, int UserId)
        {
            try
            {
                Note note = new Note();
                note.UserId = UserId;
                note.Title = notesPostModel.Title;
                note.Description = notesPostModel.Description;
                note.Color = notesPostModel.Color;
                note.IsArchive = false;
                note.IsRemainder = false;
                note.IsPin = false;
                note.IsTrash = false;
                note.CreatedDate = DateTime.Now;
                note.ModifedDate = DateTime.Now;
                fundoo.Add(note);
                await fundoo.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    note.Title = noteUpdateModel.Title;
                    note.Description = noteUpdateModel.Description;
                    note.IsArchive = noteUpdateModel.IsArchive;
                    note.Color = noteUpdateModel.Color;
                    note.IsPin = noteUpdateModel.IsPin;
                    note.IsRemainder = noteUpdateModel.IsRemainder;
                    note.IsTrash = noteUpdateModel.IsTrash;
                    await fundoo.SaveChangesAsync();

                }
                return await fundoo.Notes.Where(u => u.UserId == u.UserId && u.NoteID == noteId).Include(u => u.user).FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public async Task DeleteNote(int noteId, int userId)
        {

            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.NoteID == noteId && u.UserId == userId);
                if (note != null)
                {
                    fundoo.Notes.Remove(note);
                    await fundoo.SaveChangesAsync();

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public async Task ChangeColour(int userId, int noteId, string color)
        {

            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    note.Color = color;
                    await fundoo.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task ArchiveNote(int userId, int noteId)
        {

            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    if (note.IsArchive == true)
                    {
                        note.IsArchive = false;
                    }

                    if (note.IsArchive == false)
                    {
                        note.IsArchive = true;
                    }
                }

                await fundoo.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task Remainder(int userId, int noteId, DateTime remainder)
        {

            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    note.IsRemainder = true;
                    note.Remainder = remainder;
                }
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Trash(int userId, int noteId)
        {
            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    if (note.IsTrash == true)
                    {
                        note.IsTrash = false;
                    }
                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                    }
                }
                await fundoo.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Pin(int userId, int noteId)
        {
            try
            {
                var note = fundoo.Notes.FirstOrDefault(u => u.UserId == userId && u.NoteID == noteId);
                if (note != null)
                {
                    if (note.IsPin == true)
                    {
                        note.IsPin = false;
                    }
                    if (note.IsPin == false)
                    {
                        note.IsPin = true;
                    }
                }
                await fundoo.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}





