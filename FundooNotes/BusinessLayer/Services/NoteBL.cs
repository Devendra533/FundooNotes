using BusinessLayer.Interfaces;
using DataBaseLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public async Task AddNote(NotesPostModel notesPostModel, int UserID)
        {
            try
            {
                await this.noteRL.AddNote(notesPostModel, UserID);
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
                await this.noteRL.ArchiveNote(userId, noteId);
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
                await this.noteRL.ChangeColour(userId, noteId, color);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task DeleteNote(int userId, int noteId)
        {

            try
            {
                return this.noteRL.DeleteNote(userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                return await this.noteRL.UpdateNote(userId, noteId, noteUpdateModel);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task Remainder(int userId, int noteId, DateTime remainder)
        {
            try
            {
                await this.noteRL.Remainder(userId, noteId, remainder);
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
                await this.noteRL.Trash(userId, noteId);
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
                await this.noteRL.Pin(userId, noteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<List<Note>> GetAllNotes(int userId)
        {
            try
            {
                return this.noteRL.GetAllNotes(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
