namespace ConsoleApp1
{
    public static class Calculator
    {
        static public void Start()
        {
            while (true)
            {
                string valuesAsString = GetValues();
                if (valuesAsString == "")
                {
                    Console.WriteLine("Incorrect parametres");
                    continue;
                }
                if (valuesAsString == "Exit")
                {
                    break;
                }
                Console.WriteLine(GetResult(CheckAndReturnParametresAsArray(valuesAsString)));
            }

        }

        static public string[] CheckAndReturnParametresAsArray(string valuesFromClient)
        {
            string[] array = valuesFromClient.Split(' ');
            if (array.Length != 3 || !Double.TryParse(array[0], out _) || !Double.TryParse(array[2], out _))
            {
                return Array.Empty<string>();
            }
            return array;
        }

        public static string GetResult(string[] array)
        {
            if (array.Length == 0)
            {
                return "Incorrect parametres";
            }
            double num1 = Double.Parse(array[0]);
            double num2 = Double.Parse(array[2]);
            switch (array[1])
            {
                case "*":
                    return ($"Result = {num1 * num2}");
                case "/":
                    return ($"Result = {num1 / num2}");
                case "+":
                    return ($"Result = {num1 + num2}");
                case "-":
                    return ($"Result = {num1 - num2}");
                default:
                    return "Incorrect parametres";
            }
        }
        static public string GetValues()
        {
            Console.WriteLine("Write in format a + b or `Exit` for exit");
            return Console.ReadLine() ?? "";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator.Start();
        }
    }
}