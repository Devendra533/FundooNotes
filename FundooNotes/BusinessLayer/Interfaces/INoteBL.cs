using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface INoteBL
    {
        Task AddNote(NotesPostModel notesPostModel, int UserID);
    }
}
