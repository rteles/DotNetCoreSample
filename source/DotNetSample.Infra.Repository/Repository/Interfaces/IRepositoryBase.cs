﻿namespace DotNetSample.Infra.Repository.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> : Domain.Interfaces.Repository.IRepositoryBase<TEntity> where TEntity : class
    {
    }
}