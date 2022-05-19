using DataBaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.DBcontext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooContext fundoo; // used field here
        public IConfiguration Configuration { get; }
        public NoteRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.Configuration = configuration;
        }
        public async Task AddNote(NotesPostModel notesPostModel, int UserID)
        {
            try
            {
                Note note = new Note();
                note.UserId = UserID;
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
    }
}