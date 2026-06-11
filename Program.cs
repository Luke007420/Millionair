using System.Diagnostics;
using System.Reflection;

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
                Console.SetCursorPosition(70, 29);
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
                        Finalists(student, questions); break;
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
            Startgame(questions, newfinal);

        }
        public static void Startgame(Question[] questions, Students newfinal)
        {
            Random rand = new Random();
            string[] ladder =
            {
                "$100", "$200", "$300", "$500", "$1,000",
                "$2,000", "$4,000", "$8,000", "$16,000", "$32,000",
                "$64,000", "$125,000", "$250,000", "$500,000", "$1,000,000"
            };//money system for game

            //safe havens for money like in the game using indexes, 4 and 9 or $1,000 and $32,000
            int[] safeHavens = { 4, 9 };
            Question[] shuffledQ = questions.OrderBy(q => rand.Next()).ToArray();

            int currentLevel = 0;//current money
            string bankAmount = "$0";//money gaurnteed form safe havens
            bool walked = false;//if the decide to walk away with money or not
            bool gameOver = false;//if game is over
            bool fiftyfifty = false, phone = false, audience = false;
            while (currentLevel < 15 && !gameOver && !walked)//keep playing untill all 15 done, game over or wrong asnwer
            {
                Console.Clear();

                // Draw money ladder on the right
                Console.SetCursorPosition(50, 0);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   MONEY LADDER");//i found this money ladder section online
                for (int m = 14; m >= 0; m--)//loop from 1million to 100 dollars
                {
                    Console.SetCursorPosition(50, 15 - m);
                    if (m == currentLevel)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($">> ");//arrow moves when the level changes
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

                //display the question and answers on the left side of the screen
                Console.SetCursorPosition(0, 0);
                Question q = shuffledQ[currentLevel];// get current question
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Question {currentLevel + 1} - Playing for {ladder[currentLevel]}");
                Console.WriteLine($"Banked amount: {bankAmount}");
                Console.ResetColor();
                Console.WriteLine($"{q.question}");
                Console.WriteLine($"A: {q.optionA}");
                Console.WriteLine($"B: {q.optionB}");
                Console.WriteLine($"C: {q.optionC}");
                Console.WriteLine($"D: {q.optionD}");
                Console.WriteLine("Life Lines");
                if (!fiftyfifty)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[1][50/50]");
                    Console.ResetColor();
                    
                }
                if (!phone)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[2][Phone a Friend]");
                    Console.ResetColor();
                }
                if (!audience)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[3][Ask the Audience]");
                    Console.ResetColor();
                }
                string answer = Console.ReadLine().ToUpper();//read the input and change it to upper case

                if (answer == "W")
                {
                    walked = true;
                }
                else if (answer == "1")
                {
                    if (!fiftyfifty)
                    {
                        string[] wrongOptions = new string[3];
                        int wrongCount = 0;
                        Console.WriteLine("50/50 lifeline activated!");
                        fiftyfifty = true;

                        if (q.answer != "A")
                        {
                            wrongOptions[wrongCount] = "A";
                            wrongCount++;
                        }
                        if (q.answer != "B")
                        {
                            wrongOptions[wrongCount] = "B";
                            wrongCount++;
                        }
                        if (q.answer != "C")
                        {
                            wrongOptions[wrongCount] = "C";
                            wrongCount++;
                        }
                        if (q.answer != "D")
                        {
                            wrongOptions[wrongCount] = "D";
                            wrongCount++;
                        }
                        wrongOptions = wrongOptions.OrderBy(x => rand.Next()).ToArray();
                        
                        if (q.answer == "A" || wrongOptions[0] == "A")
                        {
                            Console.WriteLine($"A: {q.optionA}");
                        }
                        else
                        {
                            Console.WriteLine("A: -----");
                        }
                        if (q.answer == "B" || wrongOptions[0] == "B")
                        {
                            Console.WriteLine($"B: {q.optionB}");
                        }
                        else
                        {
                            Console.WriteLine("B: -----");
                        }
                        if (q.answer == "C" || wrongOptions[0] == "C")
                        {
                            Console.WriteLine($"C: {q.optionC}");
                        }
                        else
                        {
                            Console.WriteLine("C: -----");
                        }
                        if (q.answer == "D" || wrongOptions[0] == "D")
                        {
                            Console.WriteLine($"D: {q.optionD}");
                        }
                        else
                        {
                            Console.WriteLine("D: -----");
                        }

                        answer = Console.ReadLine().ToUpper();

                        if (answer == q.answer)//correct answer
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nCorrect! You've won {ladder[currentLevel]}!");
                            Console.ResetColor();

                            if (safeHavens.Contains(currentLevel))
                            {
                                bankAmount = ladder[currentLevel];
                                Console.WriteLine($"Safe Haven Reached!!! {ladder[currentLevel]}");//safe haven add money to bank amount
                            }
                            currentLevel++;
                            Thread.Sleep(1500);
                        }
                        else if (answer != q.answer)
                        {
                            Console.WriteLine($"\nWrong the correct answer was: {q.answer}");//incorrect answer finish game
                            gameOver = true;
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sorry this has already been used");
                    }
                }
                else if (answer == "2")
                {
                    if (!phone)
                    {
                        phone = true;
                        Console.WriteLine("The phone is ringing...");
                        Thread.Sleep(2000);
                        Console.WriteLine($"Your Friend has told you that {q.answer} is the correct answer");

                        answer = Console.ReadLine().ToUpper();

                        if (answer == q.answer)//correct asnwer
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nCorrect! You've won {ladder[currentLevel]}!");
                            Console.ResetColor();

                            if (safeHavens.Contains(currentLevel))
                            {
                                bankAmount = ladder[currentLevel];
                                Console.WriteLine($"Safe Haven Reached!!! {ladder[currentLevel]}");//safe haven add money to bank ammount
                            }
                            currentLevel++;
                            Thread.Sleep(1500);
                        }
                        else if (answer != q.answer)
                        {
                            Console.WriteLine($"\nWrong the correct answer was: {q.answer}");//incorrect answer finish game
                            gameOver = true;
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry this has already been used");
                    }

                }
                else if (answer == "3")
                {
                    if (!audience)
                    {
                        audience = true;
                        Console.WriteLine("Asking the Audience...");
                        Thread.Sleep(2000);
                        int correctpercent = rand.Next(70,100);
                        int remainder = 100 - correctpercent;
                        int left1 = rand.Next(0, remainder);
                        int left2 = rand.Next(0, remainder - left1);
                        int left3 = remainder - left1 - left2;
                        if (q.answer == "A")
                        {
                            Console.WriteLine($"A:{q.optionA} {correctpercent}%");
                            Console.WriteLine($"B:{q.optionB} {left1}%");
                            Console.WriteLine($"C:{q.optionC} {left2}%");
                            Console.WriteLine($"D:{q.optionD} {left3}%");
                        }
                        else if (q.answer == "B")
                        {
                            Console.WriteLine($"A:{q.optionA} {left1}%");
                            Console.WriteLine($"B:{q.optionB} {correctpercent}%");
                            Console.WriteLine($"C:{q.optionC} {left2}%");
                            Console.WriteLine($"D:{q.optionD} {left3}");
                        }
                        else if (q.answer == "C")
                        {
                            Console.WriteLine($"A:{q.optionA} {left2}%");
                            Console.WriteLine($"B:{q.optionB} {left1}%");
                            Console.WriteLine($"C:{q.optionC} {correctpercent}%");
                            Console.WriteLine($"D:{q.optionD} {left3}%");
                        }
                        else if (q.answer == "D")
                        {
                            Console.WriteLine($"A:{q.optionA} {left3}%");
                            Console.WriteLine($"B:{q.optionB} {left1}%");
                            Console.WriteLine($"C:{q.optionC} {left2}%");
                            Console.WriteLine($"D:{q.optionD} {correctpercent}%");
                        }
                        answer = Console.ReadLine().ToUpper();

                        if (answer == q.answer)//correct asnwer
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nCorrect! You've won {ladder[currentLevel]}!");
                            Console.ResetColor();

                            if (safeHavens.Contains(currentLevel))
                            {
                                bankAmount = ladder[currentLevel];
                                Console.WriteLine($"Safe Haven Reached!!! {ladder[currentLevel]}");//safe haven add money to bank ammount
                            }
                            currentLevel++;
                            Thread.Sleep(1500);
                        }
                        else if (answer != q.answer)
                        {
                            Console.WriteLine($"\nWrong the correct answer was: {q.answer}");//incorrect answer finish game
                            gameOver = true;
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry this has already been used");
                    }
                    

                }

                else if (answer == q.answer)//correct answer
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nCorrect! You've won {ladder[currentLevel]}!");
                    Console.ResetColor();

                    if (safeHavens.Contains(currentLevel))
                    {
                        bankAmount = ladder[currentLevel];
                        Console.WriteLine($"Safe Haven Reached!!! {ladder[currentLevel]}");//safe haven add money to bank ammount
                    }
                    currentLevel++;
                    Thread.Sleep(1500);
                }
                else if (answer != q.answer) 
                {
                    Console.WriteLine($"\nWrong the correct answer was: {q.answer}");//incorrect answer finish game
                    gameOver = true;
                    Thread.Sleep(2000);
                }
                Console.Clear();


            }
            //show final results
            if (currentLevel == 15)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"CONGRATULATIONS {newfinal.firstname.ToUpper()} {newfinal.lastname.ToUpper()}!");
                Console.WriteLine("YOU ARE A MILLIONAIRE!");
                Console.ResetColor();
            }
            else if (walked)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{newfinal.firstname} walked away with {ladder[currentLevel - 1]}!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Wrong answer! {newfinal.firstname} goes home with {bankAmount}!");
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }

}
