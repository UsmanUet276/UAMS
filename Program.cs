using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS
{
    internal class Program
    {
        static int totalSeats = 0;
        static void Main(string[] args)
        {
            List<degreeProgram> offeredPrograms = new List<degreeProgram>();
            List<student> registeredStudents = new List<student>();
            string op = " ";
            while(true)
            {
                op = mainMenu();

                if(op == "1")
                {
                    addStudent(registeredStudents , offeredPrograms);
                }
                else if(op == "2")
                {
                    addDegree(offeredPrograms);
                }
                else if (op == "3")
                {
                    menu();
                    selectStudents(offeredPrograms, registeredStudents);
                    printAllStudents(registeredStudents);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (op == "4")
                {
                    menu();
                    printRegisteredStudents(registeredStudents);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (op == "5")
                {
                    menu();
                    Console.Write("Enter Degree Program Name : ");
                    string dpName = Console.ReadLine();
                    printDegreeStudents(registeredStudents, dpName);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (op == "6")
                {
                    menu();
                    Console.Write("Enter Student Name : ");
                    string studentName = Console.ReadLine();
                    registerSubject(registeredStudents , offeredPrograms);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (op == "7")
                {
                    menu();
                    generateFees(registeredStudents);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (op == "8")
                {
                    menu();
                    Console.WriteLine("Thank you for using this program");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
        static void menu()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*                  UMS                  *");
            Console.WriteLine("*****************************************");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        static string mainMenu()
        {
            string op = " ";
            Console.WriteLine("*****************************************");
            Console.WriteLine("*                  UMS                  *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("* 1. Add a new student                  *");
            Console.WriteLine("* 2. Add a new degree program           *");
            Console.WriteLine("* 3. Generate Merit List                *");
            Console.WriteLine("* 4. View Registered students           *");
            Console.WriteLine("* 5. View students of specific program  *");
            Console.WriteLine("* 6. Registered Subjects of a student   *");
            Console.WriteLine("* 7. Calculate Fees of all Students     *");
            Console.WriteLine("* 8. Exit                               *");
            Console.WriteLine("*****************************************");
            Console.Write("Enter One option : ");
            op = Console.ReadLine();
            Console.Clear();
            return op;
        }
        static void addDegree(List<degreeProgram> offeredPrograms)
        {
            menu();
            Console.WriteLine("Add a new degree program");
            Console.Write("Enter the name of the degree program : ");
            string name = Console.ReadLine();
            Console.Write("Enter the duration of the degree program : ");
            string duration = Console.ReadLine();
            Console.Write("Enter seats in degree : ");
            int seats = takeIntInput(Console.ReadLine());
            totalSeats = totalSeats + seats;
            Console.Write("Enter the number of subjects offered in the degree program : ");
            int num = takeIntInput(Console.ReadLine());
            Console.Clear();
            degreeProgram dp = new degreeProgram(name, duration , addSubjectOfDegree(num) , seats);
            offeredPrograms.Add(dp);
        }
        static List<subject> addSubjectOfDegree(int num )
        {
            int cHours = 0;
            List<subject> allSubjects = new List<subject>();
            for(int i = 0; i<num; i++)
            {
                menu();
                if (cHours > 21)
                {
                    Console.WriteLine("All credit Hours are filled");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Subject No : {0}", i + 1);
                    Console.Write("Enter Subject Code : ");
                    string code = Console.ReadLine();
                    Console.Write("Enter Subject Type : ");
                    string subjectType = Console.ReadLine();
                    Console.Write("Enter Subject Credit Hours : ");
                    int creditHours = takeIntInput(Console.ReadLine());
                    Console.Write("Enter Subject Fee : ");
                    int subjectFee = takeIntInput(Console.ReadLine());
                    subject temp = new subject(code, creditHours, subjectType, subjectFee);
                    allSubjects.Add(temp);
                    cHours = cHours + creditHours;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            return allSubjects;
        }
        static void addStudent(List<student> registeredStudents , List<degreeProgram> offeredPrograms)
        {
            menu();
            Console.WriteLine("Enter new Student.");
            Console.Write("Enter Student Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age : ");
            int age = takeIntInput(Console.ReadLine());
            Console.Write("Enter FSC Marks : ");
            float fscMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks : ");
            float ecatMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Available degree : ");
            printAllDegree(offeredPrograms);
            Console.Write("Enter How many Pereference You want to Enter : ");
            int n = takeIntInput(Console.ReadLine());
            student temp = new student(name, age, fscMarks, ecatMarks);
            registeredStudents.Add(temp);
            registeredStudents[registeredStudents.Count - 1].calculateMerit();
            prefSelect(n , registeredStudents , offeredPrograms);
        }
        static void printAllDegree(List<degreeProgram> offeredPrograms)
        {
            for(int i = 0; i < offeredPrograms.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + offeredPrograms[i].title);
            }
        }
        static void prefSelect(int n , List<student> registeredStudents , List<degreeProgram> offeredPrograms)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Choose an option from above for preference {0} : " , i+1);
                int num = takeIntInput(Console.ReadLine());
                registeredStudents[registeredStudents.Count - 1].prefrences.Add(offeredPrograms[num-1]);
            }
        }
        static void selectStudents(List<degreeProgram> offeredPrograms , List<student> registeredStudents)
        {
            for(int k =0; k<registeredStudents.Count; k++)
            {
                int idx = getMaximum(registeredStudents);
                for (int j = 0; j < registeredStudents[idx].prefrences.Count; j++)
                {
                    for (int i = 0; i < offeredPrograms.Count; i++)
                    {
                        if (registeredStudents[idx].prefrences[j].title == offeredPrograms[i].title && offeredPrograms[i].seats > 0)
                        {
                            offeredPrograms[i].seats = offeredPrograms[i].seats - 1;
                            registeredStudents[idx].selectedInDegree = offeredPrograms[i];
                            registeredStudents[idx].isAdmitted = true;
                            break;
                        }
                    }
                    if (registeredStudents[idx].isAdmitted == true)
                    {
                        break;
                    }
                }
            }
        }
        static int getMaximum(List<student> registeredStudents)
        {
            double max = 0;
            int idx = 0;
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if (registeredStudents[i].merit > max && registeredStudents[i].cheakMax == false)
                {
                    max = registeredStudents[i].merit;
                    idx = i;
                }
            }
            registeredStudents[idx].cheakMax = true;
            return idx;
        }
        static void printAllStudents(List<student> registeredStudents)
        {
            degreeProgram temp = new degreeProgram("not admitted");
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if(registeredStudents[i].isAdmitted == true)
                {
                    Console.WriteLine(registeredStudents[i].name + " is admitted in " + registeredStudents[i].selectedInDegree.title);
                }
                else
                {
                    Console.WriteLine(registeredStudents[i].name + " is not admitted");
                    registeredStudents[i].selectedInDegree = temp;
                }
            }
        }
        static void printDegreeStudents(List<student> registeredStudents, string dpName)
        {
            Console.WriteLine("Name             FSC Marks      ECAT Marks      Merit");
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if (registeredStudents[i].selectedInDegree.title == "not admitted")
                {
                    continue;
                }
                else if (registeredStudents[i].selectedInDegree.title == dpName)
                {
                    Console.WriteLine(registeredStudents[i].name + "               " + registeredStudents[i].fscMarks + "               " + registeredStudents[i].ecatMarks + "               " + registeredStudents[i].merit);
                }
            }
        }
        static void registerSubject(List<student> registeredStudents , List<degreeProgram> offeredProgram)
        {
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if (registeredStudents[i].isRegistered == true)
                {
                    int offProgIdx = 0;
                    printAllSubjects(offeredProgram, registeredStudents[i].selectedInDegree.title);
                    Console.WriteLine("Enter Subject Code for " + registeredStudents[i].name);
                    string code = Console.ReadLine();
                    int idx = getSubjectIdx(registeredStudents , offeredProgram, registeredStudents[i].selectedInDegree.title, code , offProgIdx);
                    registeredStudents[i].creditHours = registeredStudents[i].creditHours + offeredProgram[offProgIdx].offeredSubjects[idx].creditHours;
                    if (registeredStudents[i].creditHours > 9)
                    {
                        Console.WriteLine("You have already 9 credit hours");
                        registeredStudents[i].creditHours = registeredStudents[i].creditHours - offeredProgram[offProgIdx].offeredSubjects[idx].creditHours;
                        break;
                    }
                    else
                    {
                        registeredStudents[i].registeredSubjects.Add(offeredProgram[offProgIdx].offeredSubjects[idx]);
                        registeredStudents[i].isRegistered = true;
                        Console.WriteLine("Subject Registered!");
                    }
                }
            }
        }
        static void printAllSubjects(List<degreeProgram> offeredProgram , string title)
        {
            for (int i = 0; i < offeredProgram.Count; i++)
            {
                if (offeredProgram[i].title == title)
                {
                    for (int j = 0; j < offeredProgram[i].offeredSubjects.Count; j++)
                    {
                        Console.WriteLine(j + 1 + offeredProgram[i].offeredSubjects[j].code);
                    }
                }
            }
        }
        static int getSubjectIdx(List<student> registeredStudents, List<degreeProgram> offeredProgram, string title, string code , int offProgIdx)
        {
            int idx = 0;
            for (int j = 0; j < offeredProgram.Count; j++)
            {
                if (offeredProgram[j].title == title)
                {
                    for (int k = 0; k < offeredProgram[j].offeredSubjects.Count; k++)
                    {
                        if (offeredProgram[j].offeredSubjects[k].code == code)
                        {
                            offProgIdx = j;
                            idx = k;
                            break;
                        }
                    }
                }
            }
            return idx;
        }
        static void generateFees(List<student> registeredStudents)
        {
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if (registeredStudents[i].isRegistered == true)
                {
                    for(int j = 0; j<registeredStudents[i].registeredSubjects.Count; j++)
                    {
                        registeredStudents[i].fees = registeredStudents[i].fees + registeredStudents[i].registeredSubjects[j].subjectFee;
                    }
                }
            }
            Console.WriteLine("Fees Generated!");
        }
        static void printRegisteredStudents(List<student> registeredStudents)
        {
            Console.WriteLine("Name             FSC Marks      ECAT Marks      Merit");
            for (int i = 0; i < registeredStudents.Count; i++)
            {
                if (registeredStudents[i].isRegistered == true)
                {
                    Console.WriteLine(registeredStudents[i].name + "               " + registeredStudents[i].fscMarks + "               " + registeredStudents[i].ecatMarks + "               " + registeredStudents[i].merit);
                }
            }
        }
        static bool isNumber(string line)
        {
            bool flag = true;

            for (int i = 0; i < line.Length; i++)
            {
                if (!(line[i] >= 48 && line[i] <= 57))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static int takeIntInput(string line)
        {
            int num = 0;
            while (true)
            {
                if (isNumber(line))
                {
                    num = int.Parse(line);
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                    line = Console.ReadLine();
                }
            }
            return num;
        }
    }
}
