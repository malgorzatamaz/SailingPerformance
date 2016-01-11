﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Dal.Repositories.Contracts;

namespace Dal.Repositories
{
    public class GpsDataRepository:IGpsDataRepository
    {
        private SailingDbContext _sailingDbContext;

        public GpsDataRepository(SailingDbContext sailingDbContext = null)
        {
            _sailingDbContext = sailingDbContext;
        }
        public void Add(GPSData entity)
        {
            _sailingDbContext.GPSData.Add(entity);
        }

        public void Update(GPSData entity)
        {
            _sailingDbContext.GPSData.AddOrUpdate(entity);
        }

        public void Delete(GPSData entity)
        {
            _sailingDbContext.Entry(entity).State = EntityState.Deleted;
        }
        public List<GPSData> GetGpsData(Guid idSession)
        {
            List<GPSData> data;
            using (_sailingDbContext = new SailingDbContext())
            {
                data = _sailingDbContext.GPSData.Where(x=>x.IdSession==idSession).ToList();
            }
            return data;
        }
    }
}
