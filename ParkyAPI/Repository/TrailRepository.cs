﻿using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace ParkyAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;

        public TrailRepository(ApplicationDbContext db)
        { 
            _db = db;
        }
        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrailsInNationalParK(int trailId)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
           return _db.Trails.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();
        }

        
        public bool TrailExists(string name)
        {
            bool value = _db.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            bool value = _db.Trails.Any(a => a.Id == id);
            return value;
        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ? true: false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trails.Update(trail); 
            return Save();  
        }

        public ICollection<Trail> GetAllTrailsInNationalPark(int npId)
        {
            return _db.Trails.Include(c=>c.NationalPark).Where(c=>c.NationalParkId == npId).ToList();
        }
    }
}
