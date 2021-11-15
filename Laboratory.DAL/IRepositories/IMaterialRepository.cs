﻿using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface IMaterialRepository : IRepository<Material>
    {
        void Update(Material material);
    }
}
