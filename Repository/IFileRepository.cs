using FilesApp.Data;

namespace FilesApp.Repository
{
    public interface IFileRepository
    {
        FileData Add(FileData file);
       IEnumerable<FileData> GetAll();
    }
}
