using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRL
    {
        Task AddNote(NotesPostModel notesPostModel, int UserID);
    }
}
