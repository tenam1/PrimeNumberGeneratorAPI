using Microsoft.AspNetCore.Mvc;

namespace webAPItest2.Controllers

{
    [Route("api")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            // Check from 2 to n-1
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private List<int> GeneratePrimeNumbers(int num)
        {
            List<int> primeNumbers = new List<int>();

            for (int i = 0; i < num; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }

        [HttpGet]
        public List<int> Get(int num)
        {
            return GeneratePrimeNumbers(Math.Clamp(num, 1, 100));
        }
    }
}