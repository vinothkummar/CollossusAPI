using Colossus.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colossus.Repository.Interfaces
{
    public interface IFileStorageRepository : IGenericRepository<FileStoreage>
    {
        Task<IEnumerable<FileStoreage>> GetFileStorageAsync();
    }
}
