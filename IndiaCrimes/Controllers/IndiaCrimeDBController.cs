using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;
using System.Reflection;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndiaCrimeDBController : ControllerBase
    {

        //gloabal vallue
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
        public int GetNumberOfProperties(int pYear)
        {
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





            //part of the 1st querey, maing sure all the values are more than 
            //
            var numberStolen = joinedFactTables.Where(x => x.Year == pYear && x.AsixtnUid!=1).Distinct().ToList();
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
        public int GetValueProperties(string pLocation) //tak
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");
            
            //only look for this location and then in the querey you use select new for this location
                
            //set as global value
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
            //In Punjab(location) what was the top 5 largest value of property that was stolen(and recovered in relation to number crimnals 18 to 30\
            //join the joined fact tables with the property stolen and property recovered tables
            //two different buttons in the html

            //var valueStolen = from x in joinedFactTables
            //                  where x.Location == "Punjab" && x.AeightntothirtId >= 1   
            //                  select x;
            //var valueStolenn = valueStolen.Distinct().ToList();


            var numberStolen = joinedFactTables.Where(x => x.Location == pLocation && x.AsixtnUid != 1).   Distinct().Cast<dynamic>()
    .ToList<dynamic>();
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


            return 1000;
        }
        [HttpGet("{pLocation}")]
        [ActionName("GetValueRecov")]
        public  List<Object> GetValueRecov(string pLocation) //tak
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");

            //only look for this location and then in the querey you use select new for this location

           
            var context = new IndiaCrimeDBContext();
            // ref: https://stackoverflow.com/questions/5307731/linq-to-sql-multiple-joins-on-multiple-columns-is-this-possible
            var joinedFactAndRecov =  (from  crime in context.CrimeFactTables
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
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberRecov.Count}+++++++++++++++++++++++++++++");

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
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {numberStole.Count}+++++++++++++++++++++++++++++");
            List<Object> returnV = new List<Object>() { numberStole };
            return returnV;

            //    //        var numberStolen = joinedFactAndStole.Where(x => x.Location == pLocation && x.PstoleVal >= 1390000000).Distinct().Cast<dynamic>()
            //    //.ToList<dynamic>();
            //    //List<int> result = numberStolen.OfType<int>().OrderBy(num => num).ToList();
            //    var refine = joinedFactAndStole.Where(x => x.Location == pLocation && x.PstoleVal >= 1390000000).Distinct().ToArray<dynamic>();
            //    //define system Type representing List of objects of T type:
            //    var refined = (from ra in refine
            //                   select new
            //                   {
            //                       ra.AeightntothirtId,
            //                       ra.PstoleVal
            //                   }).Distinct().Cast<int>().ToList();



            //    // Array[] value = new Array[0];
            //    // int x; 
            //    //for(x = 0; x < refine.Length; x++)
            //    // {
            //    //     value.Append(refine);
            //    // }
            //    //foreach ( var row in refine)
            //    //{
            //    //    value[row];
            //    //}

            //    ////create an object instance of defined type:
            //    //var l = Activator.CreateInstance(numberStolen);

            //    ////get method Add from from the list:
            //    //MethodInfo addMethod = l.GetType().GetMethod("Add");

            //    ////loop through the calling list:
            //    //foreach (T item in list)
            //    //{

            //    //    //convert each object of the list into T object 
            //    //    //by calling extension ToType<T>()
            //    //    //Add this object to newly created list:
            //    //    addMethod.Invoke(l, new object[] { item.ToType(numberStolen) });
            //    //}

            //    ////return List of T objects:
            //    //return l;

            //    foreach (var v in refined)

            //    {
            //        System.Diagnostics.Debug.Write($"pstolenId: {v.PstoleVal} | ");
            //        System.Diagnostics.Debug.Write($"AeightntothirtId: {v.AeightntothirtId} | ");

            //    }
            //    System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++number of stolen count in a year: {refine.Count}+++++++++++++++++++++++++++++");
            //    List<object> r = refine.Cast<object>().ToList();

            //    return refined;
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
