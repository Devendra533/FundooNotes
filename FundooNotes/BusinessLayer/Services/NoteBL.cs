using BusinessLayer.Interfaces;
using DataBaseLayer;
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
    }
}
