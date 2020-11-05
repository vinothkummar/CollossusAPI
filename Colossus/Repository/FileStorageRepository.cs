using Colossus.Data;
using Colossus.DomainModel;
using Colossus.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colossus.Repository
{
    public class FileStorageRepository : GenericRepository<FileStoreage>, IFileStorageRepository
    {
        public FileStorageRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<IEnumerable<FileStoreage>> GetFileStorageAsync()
        {
            return await Get().ToListAsync().ConfigureAwait(false);
        }
    }
}
