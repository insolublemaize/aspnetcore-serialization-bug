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

        public class CarWrapper
        {
            public ICar Car { get; set; }
        }

        /* Returns
        {
            "numberOfWheels": 0,
            "speed": 0
        }
         */
        [HttpGet(nameof(GetCar))]
        public ICar GetCar()
        {
            return new Car();
        }

        /* Returns (notice that "speed" is missing)
        {
	        "car": 
            {
		        "numberOfWheels": 0
	        }
        }
         */
        [HttpGet(nameof(GetCarWrapper))]
        public CarWrapper GetCarWrapper()
        {
            return new CarWrapper
            {
                Car = new Car()
            };
        }
    }
}
