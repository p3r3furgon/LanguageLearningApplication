﻿namespace CommonFiles.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken);
    }
}
