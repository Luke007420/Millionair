using System.Diagnostics;

namespace Millionaire
{
    public struct Students
    {
        public string firstname;
        public string lastname;
        public string interest;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Students[] student = new Students[35];

            int count = 0;


            StreamReader sr = new StreamReader(@"Millionaire.txt");


            while (!sr.EndOfStream)//while there is data to be stored
            {
                student[count].firstname = sr.ReadLine();
                student[count].lastname = sr.ReadLine();
                student[count].interest = sr.ReadLine();
                count++;
            }
            sr.Close();

            int choice;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                PrintcenterArt(@"
                     __          ___           __          __       _       _       
                     \ \        / / |          \ \        / /      | |     | |      
                      \ \  /\  / /| |__   ___   \ \  /\  / /_ _ __ | |_ ___| |      
                       \ \/  \/ / | '_ \ / _ \   \ \/  \/ / _` | '_ \| __/ __| |     
                        \  /\  /  | | | | (_) |   \  /\  / (_| | | | | |_\__ \_|     
                         \/  \/   |_| |_|\___/     \/  \/ \__,_|_| |_|\__|___(_)     
                    ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintcenterArt(@"
                      ████████╗ ██████╗     ██████╗ ███████╗     █████╗     
                      ╚══██╔══╝██╔═══██╗    ██╔══██╗██╔════╝    ██╔══██╗    
                         ██║   ██║   ██║    ██████╔╝█████╗      ███████║    
                         ██║   ██║   ██║    ██╔══██╗██╔══╝      ██╔══██║    
                         ██║   ╚██████╔╝    ██████╔╝███████╗    ██║  ██║    
                         ╚═╝    ╚═════╝     ╚═════╝ ╚══════╝    ╚═╝  ╚═╝    
                    ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                PrintcenterArt(@"
                      ███╗   ███╗██╗██╗     ██╗     ██╗ ██████╗ ███╗  ██╗ █████╗ ██╗██████╗ ███████╗
                      ████╗ ████║██║██║     ██║     ██║██╔═══██╗████╗ ██║██╔══██╗██║██╔══██╗██╔════╝
                      ██╔████╔██║██║██║     ██║     ██║██║   ██║██╔██╗██║███████║██║██████╔╝█████╗  
                      ██║╚██╔╝██║██║██║     ██║     ██║██║   ██║██║╚████║██╔══██║██║██╔══██╗██╔══╝  
                      ██║ ╚═╝ ██║██║███████╗███████╗██║╚██████╔╝██║ ╚███║██║  ██║██║██║  ██║███████╗
                      ╚═╝     ╚═╝╚═╝╚══════╝╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚══╝╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚══════╝
                    ");

                Console.ResetColor();
                Console.ResetColor();

                Printcenter("=====Menu=====");
                Printcenter("1 : Display Students");
                Printcenter("2 : Edit player interest");//need to do
                Printcenter("3 : Start game");
                Printcenter("0 : to exit program");
                Printcenter("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (choice)
                {
                    case 1:
                        Displaystudent(student);// make it sort by last name
                        break;
                    case 2:
                        Edit(student); break;
                    case 3:
                        Finalists(student); break;
                    //case 4:
                    //    task4(); break;
                    case 0:
                        Console.WriteLine("Exiting the program!!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command");
                        break;

                }
                if (choice != 0)
                {
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }





            } while (choice != 0);




        }
        public static void Printcenter(string text)
        {
            int screenWidth = Console.WindowWidth;
            int padding = (screenWidth + text.Length) / 2;
            Console.WriteLine(text.PadLeft(padding));
        }
        public static void PrintcenterArt(string art)
        {
            foreach (string line in art.Split('\n'))
            {
                int screenWidth = Console.WindowWidth;
                int padding = (screenWidth + line.Length) / 2;
                Console.WriteLine(line.PadLeft(padding));
            }
        }



        public static void Displaystudent(Students[] student)
        {
            //have to sort by last name
            var sortpeople = student.OrderBy(s => s.lastname);

            Console.WriteLine("First Name:\t\tLast Name:\t\tInterests:");
            foreach (var s in sortpeople)
            {

                Console.WriteLine($"{s.firstname.PadRight(8)}\t\t{s.lastname.PadRight(8)}\t\t{s.interest.PadRight(8)}");
            }
            Console.ReadLine();
        }
        public static void Chosen()
        {

        }
        public static void Edit(Students[] student)
        {
            bool found = false;
            Console.WriteLine("Enter the Last name of the person you would like to edit");
            string wanted = Console.ReadLine();
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].lastname == wanted)
                {

                    found = true;
                    Console.WriteLine("Please enter their new interest");
                    string newinterest = Console.ReadLine();
                    student[i].interest = newinterest;

                }

            }
            if (!found)
            {
                Console.WriteLine("The name does not exist in the list");
                Console.ReadLine();
            }
            Writefile(student);
        }
        public static void Writefile(Students[] students)
        {
            StreamWriter sw = new StreamWriter(@"Millionaire.txt");
            for (int i = 0; i < students.Length; i++)
            {
                sw.WriteLine(students[i].firstname);
                sw.WriteLine(students[i].lastname);
                sw.WriteLine(students[i].interest);

            }
            sw.Close();
        }

        public static void Finalists(Students[] students)
        {
            Random rand = new Random();
            int[] chosen = new int[10];
            int count = 0;

            while (count < 10)
            {
                bool dublicate = false;
                int final = rand.Next(0, students.Length);
                for (int i = 0; i <count; i++)
                {
                    if (chosen[i] == final)
                    {
                        dublicate = true;
                    }
    
                }
                if (!dublicate)
                {
                    chosen[count] = final;
                    count++;
                }
            }
            Console.WriteLine("We are getting your finalists...");
            Thread.Sleep(2000);
            Console.WriteLine("These are your finalists");
            Console.WriteLine("First Name:\t\tLast Name:\t\tInterests:");
            for (int i = 0; i < 10; i++)
            {
                
                Console.WriteLine($"{students[chosen[i]].firstname.PadRight(8)}\t\t{students[chosen[i]].lastname.PadRight(8)}\t\t{students[chosen[i]].interest.PadRight(8)}");
                
            }
            Console.ReadLine();
            Thread.Sleep(2000);


            

            





        }
    }
}
