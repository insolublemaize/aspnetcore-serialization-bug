using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerializationTest3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        public interface IVehicle
        {
            public int Speed { get; set; }
        }

        public interface ICar : IVehicle
        {
            public int NumberOfWheels { get; set; }
        }

        public class Car : ICar
        {
            public int NumberOfWheels { get; set; }
            public int Speed { get; set; }
        }

        public class Catalog
        {
            public List<ICar> Cars { get; set; } = new List<ICar>();
        }

        /* Returns
        {
            "numberOfWheels": 0,
            "speed": 0
        }
         */
        [HttpGet(nameof(GetSingleCar))]
        public ICar GetSingleCar()
        {
            return new Car();
        }

        /* Returns (notice that "speed" is missing)
        {
	        "cars": 
	        [
		        {
			        "numberOfWheels": 0
		        }
	        ]
        }
         */
        [HttpGet(nameof(GetAllCars))]
        public Catalog GetAllCars()
        {
            var ret = new Catalog();
            ret.Cars.Add(new Car());
            return ret;
        }
    }
}
