using System.Diagnostics;

namespace Millionaire
{
    public struct Students
    {
        public string firstname;
        public string lastname;
        public string interest;
    }
    public struct Question
    {
        public string question;
        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;
        public string answer;
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


            Question[] questions = new Question[20];
            int qcount = 0;
            StreamReader qr = new StreamReader(@"Questions.txt");
            while (!qr.EndOfStream)
            {
                questions[qcount].question = qr.ReadLine();
                questions[qcount].optionA = qr.ReadLine();
                questions[qcount].optionB = qr.ReadLine();
                questions[qcount].optionC = qr.ReadLine();
                questions[qcount].optionD = qr.ReadLine();
                questions[qcount].answer = qr.ReadLine();
                qcount++;
            }
            qr.Close();

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
                        Finalists(student,questions); break;
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

        public static void Finalists(Students[] students, Question[] questions)
        {
            Random rand = new Random();
            Students[] shuffled = students.OrderBy(s => rand.Next()).ToArray();// shuffles students and sorts them in alphabeical order
            Console.WriteLine("We are getting your finalists...");
            Thread.Sleep(2000);
            Console.WriteLine("These are your finalists");
            Console.WriteLine("First Name:\t\tLast Name:\t\tInterests:");
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine($"{shuffled[i].firstname.PadRight(8)}\t\t{shuffled[i].lastname.PadRight(8)}\t\t{shuffled[i].interest.PadRight(8)}");//selsects 10 out of random of the students

            }
            Thread.Sleep(2000);
            Console.WriteLine("This is your finalists");
            Console.WriteLine("First Name:\t\tLast Name:\t\tInterests:");
            Students newfinal = shuffled[rand.Next(10)];//picks one out of random of the shuffled students we set earlier
            Console.WriteLine($"{newfinal.firstname}\t\t\t{newfinal.lastname}\t\t\t{newfinal.interest}");
            Console.ReadLine();

            string[] ladder =
            {
                "$100", "$200", "$300", "$500", "$1,000",
                "$2,000", "$4,000", "$8,000", "$16,000", "$32,000",
                "$64,000", "$125,000", "$250,000", "$500,000", "$1,000,000"
            };//money system for game

            //safe havens for money like in the game useing indexes, 4 and 9 or $1,000 and $32,000
            int[] safeHavens = { 4, 9 };
            Question[] shuffledQ = questions.OrderBy(q => rand.Next()).ToArray();

            int currentLevel = 0;
            string bankAmount = "$0";
            bool walked = false;
            bool gameOver = false;
            while (currentLevel < 15 && !gameOver && !walked)
            {
                Console.Clear();

                // Draw money ladder on the right
                Console.SetCursorPosition(50, 0);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   MONEY LADDER");
                for (int m = 14; m >= 0; m--)
                {
                    Console.SetCursorPosition(50, 15 - m);
                    if (m == currentLevel)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($">> ");
                    }
                    else if (safeHavens.Contains(m))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"   ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"   ");
                    }

                    if (safeHavens.Contains(m))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (m == currentLevel)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine($"{m + 1,2}. {ladder[m],12}");
                }
                Console.ResetColor();
                Console.ReadLine();














            }
        }
    }

}
