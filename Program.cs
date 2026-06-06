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
                Console.Clear();
                Console.WriteLine("=====Menu=====");
                Console.WriteLine("1 : Display Students");
                Console.WriteLine("2 : Edit player interest");//need to do
                Console.WriteLine("3 : Finalists");//need to do refer to assigment brief find and list them
                Console.WriteLine("4 : Start game");
                Console.WriteLine("0 : to exit program");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                

                switch (choice)
                {
                    case 1:
                        Displaystudent(student);// make it sort by last name
                        break;
                    case 2:
                        Edit(student); break;
                    //case 3:
                    //    task3(); break;
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
        public static void Displaystudent(Students[] student)
        {
            //have to sort by last name

            Console.WriteLine("First Name:\t\tLast Name:\t\tInterests:");
            for (int i = 0; i < student.Length; i++)
            {
                
                Console.WriteLine($"{student[i].firstname.PadRight(8)}\t\t{student[i].lastname.PadRight(8)}\t\t{student[i].interest.PadRight(8)}");
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
    }
}
