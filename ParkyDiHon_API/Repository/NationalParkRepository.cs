using ParkyDiHon_API.Data;
using ParkyDiHon_API.Models;
using ParkyDiHon_API.Repository.IRepository;

namespace ParkyDiHon_API.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly AppDbContext _db;

        public NationalParkRepository(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.nationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.nationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
           NationalPark park = _db.nationalParks.FirstOrDefault( park => park.Id == nationalParkId );
            return park;
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.nationalParks.OrderBy(park => park.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool exsit =  _db.nationalParks.Any(park => park.Name.ToLower().Trim() == name.ToLower().Trim());
            return exsit;
        }

        public bool NationalParkExists(int id)
        {
            bool existency = _db.nationalParks.Any(park => park.Id == id);
            return existency;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.nationalParks.Update(nationalPark);
            return Save();
        }
    }
}
