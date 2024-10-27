﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagmentSystem.Application.Contracts.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
        public void SaveChanges();
    }
}
