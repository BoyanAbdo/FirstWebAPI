using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace FIrstWebAPI.Controllers
{
    [Route("[controller]")]
    public class PrimeNumbersController : ControllerBase
    {

        private List<int> primeNumbers;

        public PrimeNumbersController()
        {
            this.primeNumbers = PopulateNumbers(10000);


        }

        private List<int> PopulateNumbers(int upperValue)
        {
            List<int> primeNumbers = new List<int>();

            bool isPrime = true;


            for (int num = 1; num < upperValue; num++)
            {
                for (int div = 2; div < num; div++)
                {
                    if (num % div == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primeNumbers.Add(num);
                }
                isPrime = true;
            }


            return primeNumbers;
        }


        [HttpGet]
        public IEnumerable<int> Get()
        {
            return this.primeNumbers;
        }


        /// <summary>
        /// Get Operation
        /// </summary>
        /// <remarks>
        /// Behold, the message is...:
        /// 
        ///     Hi, there. Count is hardcoded to 1230
        ///     
        /// </remarks>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count:int}")]
        //[Route("/get/{message}")]
        //[SwaggerOperation("GetOperation")]
        //[SwaggerResponse(200, Type = typeof(string), Description = "Get operation")]
        //[SwaggerResponse(500, Type = typeof(string), Description = "Internal Server Error")]
        //[SwaggerResponse(404, Type = typeof(string), Description = "Method Not Found")]
        public IEnumerable<int> Get(int count)
        {
            return this.primeNumbers.Take(count);
        }



        /// <summary>
        /// Get Operation
        /// </summary>
        /// <remarks>
        /// Behold, the message is...:
        /// 
        ///     Hi, there. Upper limit is hardcoded to 10000
        ///     
        /// </remarks>
        [HttpGet("{fromNum:int}&{toNum:int}")]
        public IEnumerable<int> Get(int fromNum, int toNum)
        {
            return this.primeNumbers.Where(x => x >= fromNum && x <= toNum);
        }
    }
}
