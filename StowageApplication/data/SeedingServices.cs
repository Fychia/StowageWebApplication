using StowageApplication.Data;
using StowageApplication.Models;

namespace StowageApplication.data
{
    public class SeedingServices
    {
        private FileStowageContext _context;

        public SeedingServices(FileStowageContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.FileStowage.Any())
            {
                return; //O banco já foi populado
            }

            FileStowage fileStowage1 = new FileStowage(Guid.NewGuid(), "File1", 200, "Server1", DateTime.Now);
            FileStowage fileStowage2 = new FileStowage(Guid.NewGuid(), "File2", 200, "Server1", DateTime.Now);
            FileStowage fileStowage3 = new FileStowage(Guid.NewGuid(), "File3", 200, "Server1", DateTime.Now);
            FileStowage fileStowage4 = new FileStowage(Guid.NewGuid(), "File4", 200, "Server1", DateTime.Now);
            FileStowage fileStowage5 = new FileStowage(Guid.NewGuid(), "File5", 200, "Server1", DateTime.Now);

            _context.FileStowage.AddRange(fileStowage1, fileStowage2, fileStowage3, fileStowage4, fileStowage5);

            _context.SaveChanges();
        }

    }
}
