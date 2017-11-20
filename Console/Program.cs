namespace Console
{
    using DAL;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DevComDbContext())
            {
                WriteLine(db.Roles.Find("1"));
            }

            ReadKey();
        }
    }
}