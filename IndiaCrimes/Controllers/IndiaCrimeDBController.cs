using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndiaCrimeDBController : ControllerBase
    {
        // GET: api/<IndiaCrimeDBController>
        [HttpGet]
        [ActionName("Get")]
        public List<string> Get()
        {
            // TODO: main queries
            return new List<string> { "india", "Cimes", "table" };
        }

        [HttpGet("{pYear}")]
        [ActionName("GetNumberOfProperties")]
        public List<Object> GetNumberOfProperties(int pYear)
        {
            var context = new IndiaCrimeDBContext();

            //var joinedFactTables = (from crimeFactTable in context.CrimeFactTables
            //                       join criminalFactTable in context.CriminalFactTables
            //                       on crimeFactTable.Year equals criminalFactTable.Year
            //                       join criminalFactTableLocation in context.CriminalFactTables
            //                       on crimeFactTable.Location equals criminalFactTableLocation.Location
            //                       select new
            //                       {
            //                           crimeFactTable.CrimeId,
            //                           crimeFactTable.Location,
            //                           crimeFactTable.Year,
            //                           crimeFactTable.PrecovId,
            //                           crimeFactTable.PstoleId,
            //                           criminalFactTable.CriminalId,
            //                           criminalFactTable.GenderId,
            //                           criminalFactTable.AsixtnUid,
            //                           criminalFactTable.AeightntothirtId,
            //                           criminalFactTable.AthirttofithId,
            //                           criminalFactTable.AfithabovId
            //                       }).ToList();

            // ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joinedFactTables = (from crimeFactTable in context.CrimeFactTables
                                    join criminalFactTable in context.CriminalFactTables
                                    on crimeFactTable.Year equals criminalFactTable.Year
                                    join criminalFactTableLocation in context.CriminalFactTables
                                    on crimeFactTable.Location equals criminalFactTableLocation.Location
                                    join stolenValueTable in context.PropertyStolenTables
                                    on crimeFactTable.PstoleId equals stolenValueTable.PstoleId
                                    join recoveredPropertyTable in context.PropertyRecoveredTables
                                    on crimeFactTable.PrecovId equals recoveredPropertyTable.PrecovId
                                    select new
                                    {
                                        crimeFactTable.CrimeId,
                                        crimeFactTable.Location,
                                        crimeFactTable.Year,
                                        crimeFactTable.PrecovId,
                                        crimeFactTable.PstoleId,
                                        criminalFactTable.CriminalId,
                                        criminalFactTable.GenderId,
                                        criminalFactTable.AsixtnUid,
                                        criminalFactTable.AeightntothirtId,
                                        criminalFactTable.AthirttofithId,
                                        criminalFactTable.AfithabovId,
                                        stolenValueTable.Pstole,
                                        stolenValueTable.PstoleVal,
                                        recoveredPropertyTable.Precov,
                                        recoveredPropertyTable.PrecoVal
                                    }).Distinct().ToList();

           // System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++joined Table count distinct: {joinedFactTables.Count}+++++++++++++++++++++++++++++");

            //--1.In the year 2007 what was the number of property that was stolen(and recovered) in realtion to criminals 16 and under
            var numberStolen = joinedFactTables.OrderByDescending(x => x.PstoleVal).Where(x => x.Year == pYear && x.AsixtnUid != 1).Distinct().ToList();
            //foreach (var row in numberStolen)
            //{
            //    System.Diagnostics.Debug.Write($"crimeID: {row.CrimeId} | ");
            //    System.Diagnostics.Debug.Write($"location: {row.Location} | ");
            //    System.Diagnostics.Debug.Write($"year: {row.Year} | ");
            //    System.Diagnostics.Debug.Write($"precovId: {row.PrecovId} | ");
            //    System.Diagnostics.Debug.Write($"pstolenId: {row.PstoleId} | ");
            //    System.Diagnostics.Debug.Write($"criminalId: {row.CriminalId} | ");
            //    System.Diagnostics.Debug.Write($"genderId: {row.GenderId} | ");
            //    System.Diagnostics.Debug.Write($"AsixtnUid: {row.AsixtnUid} | ");
            //    System.Diagnostics.Debug.Write($"AeightntothirtId: {row.AeightntothirtId} | ");
            //    System.Diagnostics.Debug.Write($"AthirttofithId: {row.AthirttofithId} | ");
            //    System.Diagnostics.Debug.Write($"AfithabovId: {row.AfithabovId} | ");
            //    System.Diagnostics.Debug.Write($"PstoleId: {row.PstoleId} | ");
            //    System.Diagnostics.Debug.Write($"Pstole: {row.Pstole} | ");
            //    System.Diagnostics.Debug.Write($"PstoleVal: {row.PstoleVal} |");
            //    System.Diagnostics.Debug.Write($"PrecovId: {row.PrecovId} | ");
            //    System.Diagnostics.Debug.Write($"Precov: {row.Precov} | ");
            //    System.Diagnostics.Debug.WriteLine($"PrecoVal: {row.PrecoVal}");
            //}
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberStolen.Count}+++++++++++++++++++++++++++++");

            Int64 totalNumberStolen = 0;
            try
            {
                totalNumberStolen = numberStolen.AsEnumerable().Sum(x => x.Pstole);
            } catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++ERROR: {err.Message}+++++++++++++++++++++++++++++");
            }

            var top5Stolen = numberStolen.OrderByDescending(x => x.PstoleVal).Distinct().Select(x => new { x.PstoleVal, x.Location }).Distinct().Take(5);

            foreach (var item in top5Stolen)
            {
                System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++top 5 stolen val: {item.PstoleVal}, {item.Location}+++++++++++++++++++++++++++++");
            }

            Int64 totalNumberRecovered = 0;
            try
            {
                totalNumberRecovered = numberStolen.Sum(x => x.Precov);
            } catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++ERROR: {err.Message}+++++++++++++++++++++++++++++");
            }

            var top5Recovered = numberStolen.OrderByDescending(x => x.PrecoVal).Distinct().Select(x => new { x.PrecoVal, x.Location }).Distinct().Take(5);

            List<Object> totalValue = new List<Object>()
            {
                totalNumberStolen,
                top5Stolen,
                totalNumberRecovered,
                top5Recovered
            };

            return totalValue;
        }

        [HttpGet("{pLocation}")]
        [ActionName("GetValueRecov")]
        public List<Object> GetValueRecov(string pLocation) //tak
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");

            //only look for this location and then in the querey you use select new for this location


            var context = new IndiaCrimeDBContext();
            // ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joinedFactAndRecov = (from crime in context.CrimeFactTables
                                      where crime.Location == pLocation
                                      join recov in context.PropertyRecoveredTables on crime.PrecovId equals recov.PrecovId
                                      join criminal in context.CriminalFactTables on crime.Location equals criminal.Location
                                      where criminal.Year >= 2001
                                      join age in context.EighteenThirtyTables on criminal.AeightntothirtId equals age.AeightntothirtId
                                      select new
                                      {
                                          crime.Year,
                                          crime.Location,
                                          recov.PrecoVal,
                                          age.Aeightntothirt
                                      }).Distinct().ToList();


            //In Punjab(location) what was the value of property that was stolen(and recovered in relation to number crimnals 18 to 30\
            //join the joined fact tables with the property stolen and property recovered tables
            //two different buttons in the html

            //var valueStolen = from x in joinedFactTables
            //                  where x.Location == "Punjab" && x.AeightntothirtId >= 1   
            //                  select x;
            //var valueStolenn = valueStolen.Distinct().ToList();


            var numberRecov = joinedFactAndRecov.Where(x => x.Location == pLocation && x.Year >= 2001).Distinct().Take(5).ToList();
            //var numberRecov = Recov.Distinct().ToList();

            foreach (var row in numberRecov)

            {
                System.Diagnostics.Debug.Write($"PrecoVal: {row.PrecoVal} |");
                System.Diagnostics.Debug.Write($"AeightntothirtId: {row.Aeightntothirt} | ");

            }
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberRecov.Count}+++++++++++++++++++++++++++++");

            // TODO: main queries
            //var context = new IndiaCrimeDBContext();
            //var totalQuery = (from eachOrder in context.CrimeFactTables
            //                  where eachOrder.Location == pLocation
            //                  select eachOrder.PrecovId).Sum();

            //return totalQuery;
            //int x = numberStolen.Length;
            //Array[] list = new Array[numberStolen.Length](numberStolen.ToArray());

            //return list;
            List<Object> returnV = new List<Object>() { numberRecov };
            return returnV;
        }
        [HttpGet("{pLocation}")]
        [ActionName("GetValueStole")]

        public List<Object> GetValueStole(string pLocation) //tak
        {

            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");

            //only look for this location and then in the querey you use select new for this location

            //    //set as global value


            var context = new IndiaCrimeDBContext();

            //// ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joined = (from crime in context.CrimeFactTables
                          where crime.Location == pLocation
                          join stole in context.PropertyStolenTables on crime.PstoleId equals stole.PstoleId
                          join criminal in context.CriminalFactTables on crime.Location equals criminal.Location
                          where criminal.Year >= 2001
                          join age in context.EighteenThirtyTables on criminal.AeightntothirtId equals age.AeightntothirtId
                          select new
                          {
                              crime.Year,
                              crime.Location,
                              stole.PstoleVal,
                              age.Aeightntothirt
                          }).Distinct().ToList();


            var numberStole = joined.Where(x => x.Location == pLocation && x.Year >= 2001).Distinct().Take(5).ToList();
            //var numberStole = Stole.Distinct().ToList();
            foreach (var row in numberStole)

            {
                System.Diagnostics.Debug.Write($"PstoleVal: {row.PstoleVal} |");
                System.Diagnostics.Debug.Write($"AeightntothirtId: {row.Aeightntothirt} | ");

            }
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberStole.Count}+++++++++++++++++++++++++++++");
            List<Object> returnV = new List<Object>() { numberStole };
            return returnV;
        }
        [HttpGet("{pLocation}")]
        [ActionName("GetValueProperties")]
        public int GetValueProperties(string pLocation)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");

            var context = new IndiaCrimeDBContext();
            // ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joinedFactTables = (from crimeFactTable in context.CrimeFactTables
                                    join criminalFactTable in context.CriminalFactTables
                                    on crimeFactTable.Year equals criminalFactTable.Year
                                    join criminalFactTableLocation in context.CriminalFactTables
                                    on crimeFactTable.Location equals criminalFactTableLocation.Location
                                    select new
                                    {
                                        crimeFactTable.CrimeId,
                                        crimeFactTable.Location,
                                        crimeFactTable.Year,
                                        crimeFactTable.PrecovId,
                                        crimeFactTable.PstoleId,
                                        criminalFactTable.CriminalId,
                                        criminalFactTable.GenderId,
                                        criminalFactTable.AsixtnUid,
                                        criminalFactTable.AeightntothirtId,
                                        criminalFactTable.AthirttofithId,
                                        criminalFactTable.AfithabovId
                                    }).Distinct().ToList();

            // TODO: main queries
            //var context = new IndiaCrimeDBContext();
            //var totalQuery = (from eachOrder in context.CrimeFactTables
            //                  where eachOrder.Location == pLocation
            //                  select eachOrder.PrecovId).Sum();

            //return totalQuery;

            return 1000;
        }

        [HttpGet("{pGenderId}")]
        [ActionName("GetGenderData")]
        public List<Object> GetGenderData(int pGenderId)
        {
            //---3.Which location had the least number of property stolen in realtion to how many female criminals were in the area.
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetGenderData: {pGenderId}+++++++++++++++++++++++++++++");

            var context = new IndiaCrimeDBContext();
            // ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joinedFactTables = (from criminalFactTable in context.CriminalFactTables
                                    where criminalFactTable.GenderId == pGenderId
                                    join crimeFactTable in context.CrimeFactTables
                                    on new { criminalFactTable.Location, criminalFactTable.Year } equals new { crimeFactTable.Location, crimeFactTable.Year }
                                    join genderTable in context.GenderTables
                                    on criminalFactTable.GenderId equals genderTable.GenderId
                                    join pStolenTable in context.PropertyStolenTables
                                    on crimeFactTable.PstoleId equals pStolenTable.PstoleId
                                    select new
                                    {
                                        criminalFactTable.Location,
                                        criminalFactTable.Year,
                                        genderTable.Gender,
                                        genderTable.GenderId,
                                        pStolenTable.Pstole,
                                        pStolenTable.PstoleVal
                                    }).Distinct().ToList();


            //var leastPropertyStolenGender = joinedFactTables.Where(x => x.GenderId == pGenderId).Distinct().OrderBy(x => x.Pstole).Distinct().Take(5);
            var leastPropertyStolenGender = joinedFactTables.Distinct().OrderBy(x => x.Pstole).Where(x => x.GenderId == pGenderId).Distinct().Take(5);
            //var leastPropertyStolenGender = joinedFactTables.OrderBy(x => x.Precov).Distinct().Take(5);

            foreach (var item in leastPropertyStolenGender)
            {
                System.Diagnostics.Debug.WriteLine($"number of stolen prop: {item.Pstole} | location: {item.Location} | value: {item.PstoleVal} | gender: {item.Gender} | year: {item.Year} ");
            }

            List<Object> returnVal = new List<object>() { leastPropertyStolenGender };
            return returnVal; ;
        }
    }
}
