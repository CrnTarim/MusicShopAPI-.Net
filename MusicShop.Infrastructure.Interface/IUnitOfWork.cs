﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();
        public void Commit();
    }
}
