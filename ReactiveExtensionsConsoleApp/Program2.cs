using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class Program2
	{
		static void Main()
		{
			Random r = new Random();
			int targetNumber = r.Next();

			while (true)
			{
				Console.WriteLine("Take a guess at the number");
				int guess = int.Parse(Console.ReadLine());

				if (guess > targetNumber)
					Console.WriteLine("Too high!");
				else if (guess < targetNumber)
					Console.WriteLine("Too low!");
				else
					Console.WriteLine("You got it!");
			}
		}

	}
}
