using System;

namespace A2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of cards to pick: ");
			string line = Console.ReadLine();
			if (int.TryParse(line, out int numCards))
			{
				foreach (var card in CardPicker.PickSomeCards(numCards))
				{
					Console.WriteLine(card);

				}
			}
			else
			{
				Console.WriteLine("Please enter a valid number.");
			}

			Random random = new Random(1);
			ParticleMovement particleMover = new ParticleMovement();
			while (true)
			{
				Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
					          "2 if a gravitational field is present\n3 for both fields\n");
				char key = Console.ReadKey().KeyChar;
				if (key != '0' && key != '1' && key != '2' && key != '3') return;
				int movementRange = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
				particleMover.MovementRange = movementRange;
				//particleMover.SetMagneticField(key == '1' || key == '3');
				//particleMover.SetGravitationalField(key == '2' || key == '3');
				Console.WriteLine($"\nParticle with a movement range of {movementRange} units" +
								  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
			}
		}
	}

	public class ParticleMovement
	{
		public const int BASE_MOVEMENT= 3;
		public const int GRAVITY_MOVEMENT = 2;

		
		private bool gravitationalField;
		private bool magneticField;
		private decimal movementRange;
		public int GravityMovement = 0;
		public int DistanceMoved;
		public double Distance { get; private set; }
		public decimal MovementRange
		{
			get { return movementRange; }
			set
			{
				movementRange = value;
				CalculateDistance();
			}
		}

		public void CalculateDistance()
		{
			DistanceMoved = (int)(movementRange * Convert.ToInt32(magneticField)) + BASE_MOVEMENT + Convert.ToInt32(gravitationalField);
		}

		public bool GravitationalField
		{
			get { return gravitationalField; }
			set
			{
				gravitationalField = value;
				
			}
		}
		public bool MagneticField
		{
			get { return magneticField; }
			set
			{
				magneticField = value;
				
			}
		}
	}

	class CardPicker
	{

		static Random random = new Random(1);
		
		public static string[] PickSomeCards(int numCards)
		{
			string[] pickedCards = new string[numCards];
			for (int i = 0; i < numCards; ++i)
			{
				pickedCards[i] = RandomValue() + " of " + RandomSuit();
			}
			return pickedCards;
		}
		
		private static string RandomValue()
		{
			Random random = new Random();
			int Value = random.Next(0, 13);
			string Values = ((values)Value).ToString();
			return Values;

		}





		private static string RandomSuit()
		{
			Random random = new Random();
			int value = random.Next(0, 3);
			string suits = ((Suits)value).ToString();
			return suits;

		}
		public enum values
		{
			Ace,
			Two, 
			Three, 
			Four,
			Five, 
			Six,
			Seven,
			Eight,
			Nine,
			Ten, 
			Jack,
			Queen,
			King

		};




		
		public enum Suits { Hearts, Diamonds, Spades, Clubs };
	}
}
