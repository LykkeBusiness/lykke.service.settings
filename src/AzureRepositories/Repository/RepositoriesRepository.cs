﻿using AzureStorage;
using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureRepositories.Repository
{
    public class RepositoriesRepository : IRepositoriesRepository
    {
        private readonly INoSQLTableStorage<RepositoryEntity> _tableStorage;

        public RepositoriesRepository(INoSQLTableStorage<RepositoryEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public async Task<IRepository> GetAsync(string repositoryId)
        {
            var pk = RepositoryEntity.GeneratePartitionKey();
            var rk = RepositoryEntity.GenerateRowKey(repositoryId);

            return await _tableStorage.GetDataAsync(pk, rk);
        }

        public async Task<IEnumerable<IRepository>> GetAsync(Func<IRepository, bool> filter)
        {
            var pk = RepositoryEntity.GeneratePartitionKey();
            var list = await _tableStorage.GetDataAsync(pk, filter:filter);
            return list;
        }

        public async Task<IEnumerable<IRepository>> GetAllAsync()
        {
            var pk = RepositoryEntity.GeneratePartitionKey();
            return await _tableStorage.GetDataAsync(pk);
        }

        public async Task RemoveRepositoryAsync(string repositoryId)
        {
            var pk = RepositoryEntity.GeneratePartitionKey();
            await _tableStorage.DeleteAsync(pk, repositoryId);
        }

        public async Task SaveRepositoryAsync(IRepository repository)
        {
            if (repository is RepositoryEntity rs)
            {
                rs.PartitionKey = RepositoryEntity.GeneratePartitionKey();
                rs.RowKey = repository.RepositoryId;
            }
            else
            {
                var pk = RepositoryEntity.GeneratePartitionKey();
                var rk = RepositoryEntity.GenerateRowKey(repository.RepositoryId);

                rs = await _tableStorage.GetDataAsync(pk, rk)
                    ?? new RepositoryEntity { PartitionKey = pk, RowKey = rk };

                rs.Name = repository.Name;
                rs.GitUrl = repository.GitUrl;
                rs.Branch = repository.Branch;
                rs.FileName = repository.FileName;
                rs.UserName = repository.UserName;
                rs.ConnectionUrl = repository.ConnectionUrl;
                rs.UseManualSettings = repository.UseManualSettings;
                rs.Tag = repository.Tag;
            }

            await _tableStorage.InsertOrMergeAsync(rs);
        }
    }
}
