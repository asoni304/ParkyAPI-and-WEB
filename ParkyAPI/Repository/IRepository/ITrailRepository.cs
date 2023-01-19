using ParkyAPI.Models;
using System.Collections.Generic;

namespace ParkyAPI.Repository.IRepository
{
    public interface ITrailRepository
    {
        //all methods we want to perform ,crud operations

        ICollection<Trail> GetTrails(); //get all trails

        ICollection<Trail> GetAllTrailsInNationalPark(int npId); //get all trails in a national park
        Trail GetTrailsInNationalParK(int trailId); //get one trail

        bool TrailExists(string name); //if trail exists based on name

        bool TrailExists(int id);  //if trail exists based on id

        bool CreateTrail(Trail trail);

        bool UpdateTrail(Trail trail);
        bool DeleteTrail(Trail trail);

        bool Save();

    }
}
