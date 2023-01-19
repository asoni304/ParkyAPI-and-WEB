using ParkyAPI.Models;
using System.Collections.Generic;

namespace ParkyAPI.Repository.IRepository
{
    public interface INationalParkRepository
    {
        //all methods we want to perform ,crud operations

        ICollection<NationalPark> GetNationalParks(); //get all national parks

        NationalPark GetNationalPark(int nationalParkId); //get one national park

        bool NationalParkExists(string name); //if national park exists based on name

        bool NationalParkExists(int id);  //if national park exists based on id

        bool CreateNationalPark(NationalPark nationalPark);

        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);

        bool Save();

    }
}
