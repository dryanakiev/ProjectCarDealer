namespace ProjectCarDealer.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do?");
            Console.Write("1.View People\n" +
                "2.View Dealers\n" +
                "3.View Vehicles\n");

            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        PersonViews.Show();
                        break;
                    }
                case 2:
                    {
                        DealersViews.Show();
                        break;
                    }
                case 3:
                    {
                        VehiclesViews.Show();
                        break;
                    }

                default:
                    break;
            }
        }
    }
}