using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CONTINUATION_TODO
{


    public static class ToDoItems
    {
        //public static User user;

        enum UserChoice
        {
            AddTask = 1,
            DeleteTask,
            ViewTasks,
            Exit
        }



        public static void MyMethod()
        {
            List<User> users = new List<User>(); // Add a list of users to keep track of registered users


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string text = "***********************************WELCOME  TO CROWN GLORY TODO APP!*******************************";
            int screenWidth = Console.WindowWidth;
            int left = (screenWidth - text.Length) / 2;

            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(text);

            Console.ResetColor();

            //  Console.Write("Please register to proceed  ");
            // Console.WriteLine("Please register with your name, email,   password.");
            // Console.WriteLine("Please register with your name, email,   password.");


            User user = new User();

            string name = "";
            while (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[a-zA-Z]{2,}$"))
            {
                Console.Write("Kindly Enter Your Name: ");
                name = Console.ReadLine();
                Console.Clear();

                if (!Regex.IsMatch(name, @"^[a-zA-Z]{2,}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Name! Name must only contain letters and be at least two characters long.");
                    Console.ResetColor();
                }
            }

            user.Name = name;



            string email = "";
            while (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || users.Exists(u => u.Email == email))
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Clear();

                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid email address.");
                    Console.ResetColor(); // Resets the color to the default color
                }
                else if (users.Exists(u => u.Email == email)) // Check if user already exists
                {
                    Console.WriteLine("User with this email already exists. Please try again.");
                }
            }

            /*user.Email = email;
            user.Username = email.Split('@')[0]; // Extract username from email

            int cursorTop = Math.Max(0, Console.CursorTop);
            Console.SetCursorPosition(0, cursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"Welcome {user.Username.Substring(0, 1).ToUpper()}{user.Username.Substring(1)} to Crown Glory ToDo App!");
            Console.ResetColor();

            Console.WriteLine();*/



            string password = "";
            while (string.IsNullOrEmpty(password))
            {
                Console.Write("Password: ");
                var passwordInput = new ConsoleKeyInfo();
                while (passwordInput.Key != ConsoleKey.Enter)
                {
                    passwordInput = Console.ReadKey(true);

                    if (passwordInput.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (passwordInput.Key != ConsoleKey.Enter)
                    {
                        password += passwordInput.KeyChar;
                        Console.Write("*");
                    }
                }
                Console.WriteLine();

                if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z0-9]{8}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid password. Password must be at least 8 characters long and contain at least one letter and one number.");
                    Console.ResetColor();
                    password = "";
                }
            }

            user.Id = Guid.NewGuid();
            Console.WriteLine($"User ID: {user.Id}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Thank you for registering!");
            Console.ResetColor();

            List<Task> toDoList = new List<Task>();
            while (true)
            {
                Console.WriteLine("Kindly choose from the options below.");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Forgot Password");
                int loginChoice;
                while (!int.TryParse(Console.ReadLine(), out loginChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }

                if (loginChoice == 1)
                {
                    Console.Write("Email: ");
                    string inputEmail = Console.ReadLine();

                    Console.Write("Password: ");
                    string inputPassword = Console.ReadLine();

                    if (inputEmail == email && inputPassword == password)
                    {
                        Console.WriteLine("Login successful!");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Incorrect email or password. Please try again.");
                        Console.Clear();
                    }

                    Console.Write("Confirm Password: ");
                    string confirmPassword = Console.ReadLine();

                    while (inputPassword != confirmPassword)
                    {
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Passwords do not match. Please try again.");
                            Console.ResetColor();

                            Console.Write("Password: ");
                            inputPassword = Console.ReadLine();

                            Console.Write("Confirm Password: ");
                            confirmPassword = Console.ReadLine();
                        }

                        if (inputEmail == email && inputPassword == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login successful!");
                            Console.ResetColor();

                            // Continue with the rest of the code...
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect email or password. Please try again.");
                            Console.ResetColor();

                            //Console.Clear();
                            {
                                if (loginChoice == 2)
                                {
                                    Console.Write("Please enter your email address: ");
                                    string resetEmail = Console.ReadLine();

                                    // Code to send password reset link or temporary password to user's email goes here

                                    Console.WriteLine("Password reset instructions sent to your email address.");
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Please select an option:");
                                Console.WriteLine("1. Add task");
                                Console.WriteLine("2. Delete task");
                                Console.WriteLine("3. View tasks");



                                int choice;
                                while (!int.TryParse(Console.ReadLine(), out choice))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid choice. Please enter a number.");
                                    Console.ResetColor();
                                }

                                if (choice == (int)UserChoice.AddTask)

                                {


                                    string title;

                                    while (true)
                                    {
                                        Console.Write("Title: ");
                                        title = Console.ReadLine();

                                        // Check if the title contains only letters and spaces
                                        if (!string.IsNullOrWhiteSpace(title) && title.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                        {
                                            break; // Valid title, exit the loop
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid title. Please enter a valid title with letters and spaces only.");
                                            Console.ResetColor();
                                        }
                                    }

                                    // Proceed to the next stage with the valid title
                                    // ...

                                    Console.Write("Description: ");
                                    string description = Console.ReadLine();

                                    DateTime dueDate;
                                    while (true)
                                    {
                                        Console.Write("Due Date (MM/dd/yyyy): ");
                                        if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                                        {
                                            if (DateTime.Compare(dueDate.Date, DateTime.Now.Date) < 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid date. Please enter a future date.");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy.");
                                            Console.ResetColor();
                                        }
                                    }

                                    string completed;
                                    while (true)
                                    {
                                        Console.Write("Completed? (Y/N): ");
                                        string completedInput = Console.ReadLine().ToUpper();

                                        if (completedInput == "Y")
                                        {
                                            completed = "Yes";
                                            break;
                                        }
                                        else if (completedInput == "N")
                                        {
                                            completed = "No";
                                            break;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please enter Y or N.");
                                            Console.ResetColor();
                                        }
                                    }



                                    Priority priorityChoice;

                                    while (true)
                                    {
                                        Console.Write("Priority Level (Low, Medium, High): ");
                                        string input = Console.ReadLine().Trim();

                                        if (input.Equals("Low", StringComparison.OrdinalIgnoreCase))
                                        {
                                            priorityChoice = Priority.Low;
                                            break;
                                        }
                                        else if (input.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                                        {
                                            priorityChoice = Priority.Medium;
                                            break;
                                        }
                                        else if (input.Equals("High", StringComparison.OrdinalIgnoreCase))
                                        {
                                            priorityChoice = Priority.High;
                                            break;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please enter Low, Medium, or High.");
                                            Console.ResetColor();
                                        }
                                    }

                                    // Proceed to the next stage with the valid priorityChoice
                                    // ...

                                    Task newTask = new Task()
                                    {
                                        // Id = ++Task.taskCount,
                                        Title = title,
                                        Description = description,
                                        DueDate = dueDate,
                                        PriorityLevel = priorityChoice,
                                        Completed = completed
                                    };

                                    toDoList.Add(newTask);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Task added successfully!");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                }
                                else if (choice == (int)UserChoice.DeleteTask)
                                {
                                    if (toDoList.Count == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("No tasks to delete.");
                                        Console.WriteLine();
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Select the task to delete:");

                                        for (int i = 0; i < toDoList.Count; i++)
                                        {

                                            Console.WriteLine($"{i + 1}. {toDoList[i].Id}");

                                        }

                                        int taskIndex;
                                        while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 1 || taskIndex > toDoList.Count)

                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid task. Please select a number from the list.");
                                            Console.ResetColor();
                                        }

                                        Task taskToDelete = toDoList[taskIndex - 1];
                                        toDoList.Remove(taskToDelete);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Task deleted successfully!");
                                        Console.WriteLine();
                                        Console.ResetColor();
                                    }
                                }
                                else if (choice == (int)UserChoice.ViewTasks)
                                {
                                    if (toDoList.Count == 0)
                                    {
                                        Console.WriteLine("No tasks to display.");
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Here are your tasks:");
                                        Console.WriteLine("|--------------------------------------------------------------------------------------------------|");
                                        Console.WriteLine("| Id  | Title          | Description         | Due Date        |    Priority    |     Completed    |");
                                        Console.WriteLine("|-----|----------------|---------------------|-----------------|----------------|------------------|");

                                        foreach (Task task in toDoList)
                                        {
                                            int taskIndex = toDoList.IndexOf(task) + 1;
                                            string taskId = taskIndex.ToString().PadRight(5);
                                            string title = task.Title.Length <= 15 ? task.Title.PadRight(15) : task.Title.Substring(0, 12) + "...";
                                            string description = task.Description.Length <= 20 ? task.Description.PadRight(20) : task.Description.Substring(-17) + "...";
                                            string dueDate = task.DueDate.ToShortDateString().PadRight(15);
                                            string priority = task.PriorityLevel.ToString().PadRight(16);
                                            string completed = task.IsCompleted ? "Yes" : "No";

                                            Console.WriteLine($"|{taskId}|{title}|{description}|{dueDate}|{priority}|{completed}|");
                                        }

                                        Console.WriteLine("|-----|----------------|---------------------|-----------------|----------------|-----------------|");




                                    }
                                }
                                else if (choice == (int)UserChoice.Exit)
                                {
                                    Console.WriteLine("Goodbye!");
                                    //break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice. Please select a number from the list.");
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
