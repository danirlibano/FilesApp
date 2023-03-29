using FilesApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FilesApp.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly DbContextClass _dbContext;

        public FileRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public FileData Add(FileData file)
        {
             _dbContext.FileData.Add(file);
             _dbContext.SaveChanges();
            return file;
        }

        public IEnumerable<FileData> GetAll()
        {
            return _dbContext.FileData.ToList();
        }
    }
}
