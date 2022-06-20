using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

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

        //[HttpGet("{pYear}")]
        //[ActionName("GetNumberOfProperties")]
        //public int GetNumberOfProperties(int pYear)
        //{
        //    var context = new IndiaCrimeDBContext();
        //    // filter by year
        //    var numberPropertyStolen = (from eachItem in context.CrimeFactTables
        //                               where eachItem.Year == pYear
        //                               select eachItem).ToList();
        //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++numberPropertyStolen: {numberPropertyStolen}+++++++++++++++++++++++++++++");

        //    var propertyStolen = new List<PropertyStolenTable>();
        //    // join crime fact table to property stolen table
        //    foreach (var item in numberPropertyStolen)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++eachItemPStolenID: {item.PstoleId}+++++++++++++++++++++++++++++");

        //        propertyStolen.Add((from eachItem in context.PropertyStolenTables
        //                             where eachItem.PstoleId == item.PstoleId
        //                             select eachItem).SingleOrDefault());
        //    }
        //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++eachItemPStolenID count: {propertyStolen.Count}+++++++++++++++++++++++++++++");

        //    // add pstole col
        //    var numberStolen = propertyStolen.Sum(x => x.Pstole);
        //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++totalStolenSum: {numberStolen}+++++++++++++++++++++++++++++");





        //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetNumberOfProperties: {pYear}+++++++++++++++++++++++++++++");
        //    // TODO: main queries
        //    return pYear;
        //}

        [HttpGet("{pYear}")]
        [ActionName("GetNumberOfProperties")]
        public int GetNumberOfProperties(int pYear)
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

            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++joined Table count distinct: {joinedFactTables.Count}+++++++++++++++++++++++++++++");

            //foreach (var row in joinedFactTables)
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
            //    System.Diagnostics.Debug.WriteLine($"AfithabovId: {row.AfithabovId}");
            //}

            var numberStolen = joinedFactTables.Where(x => x.Year == pYear).Distinct().ToList();
            foreach (var row in numberStolen)
            {
                System.Diagnostics.Debug.Write($"crimeID: {row.CrimeId} | ");
                System.Diagnostics.Debug.Write($"location: {row.Location} | ");
                System.Diagnostics.Debug.Write($"year: {row.Year} | ");
                System.Diagnostics.Debug.Write($"precovId: {row.PrecovId} | ");
                System.Diagnostics.Debug.Write($"pstolenId: {row.PstoleId} | ");
                System.Diagnostics.Debug.Write($"criminalId: {row.CriminalId} | ");
                System.Diagnostics.Debug.Write($"genderId: {row.GenderId} | ");
                System.Diagnostics.Debug.Write($"AsixtnUid: {row.AsixtnUid} | ");
                System.Diagnostics.Debug.Write($"AeightntothirtId: {row.AeightntothirtId} | ");
                System.Diagnostics.Debug.Write($"AthirttofithId: {row.AthirttofithId} | ");
                System.Diagnostics.Debug.WriteLine($"AfithabovId: {row.AfithabovId}");
            }
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberStolen.Count}+++++++++++++++++++++++++++++");

            // filter by year
            //var numberPropertyStolen = (from eachItem in context.CrimeFactTables
            //                            where eachItem.Year == pYear
            //                            select eachItem).ToList();
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++numberPropertyStolen: {numberPropertyStolen}+++++++++++++++++++++++++++++");

            //var propertyStolen = new List<PropertyStolenTable>();
            //// join crime fact table to property stolen table
            //foreach (var item in numberPropertyStolen)
            //{
            //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++eachItemPStolenID: {item.PstoleId}+++++++++++++++++++++++++++++");

            //    propertyStolen.Add((from eachItem in context.PropertyStolenTables
            //                        where eachItem.PstoleId == item.PstoleId
            //                        select eachItem).SingleOrDefault());
            //}
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++eachItemPStolenID count: {propertyStolen.Count}+++++++++++++++++++++++++++++");

            //// add pstole col
            //var numberStolen = propertyStolen.Sum(x => x.Pstole);
            //System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++totalStolenSum: {numberStolen}+++++++++++++++++++++++++++++");





            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetNumberOfProperties: {pYear}+++++++++++++++++++++++++++++");
            // TODO: main queries
            return pYear;
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
        public int GetGenderData(int pGenderId)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetGenderData: {pGenderId}+++++++++++++++++++++++++++++");

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
            return pGenderId;
        }

        // POST api/<IndiaCrimeDBController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<IndiaCrimeDBController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<IndiaCrimeDBController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
