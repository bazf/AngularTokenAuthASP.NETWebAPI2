namespace Console
{
    using DAL;

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DevComDbContext())
            {
            }

            System.Console.ReadKey();
        }
    }
}