namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
        private Random random = new Random();
        public RandomService()
		{
			seed = Guid.NewGuid().GetHashCode();
		}
		public int GetRandom()
		{
            return random.Next(100);
        }

	}
}
