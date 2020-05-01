using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_list
{
    class Program
    {
        static void Main(string[] args)
        {

            TodoActivities activity1 = new TodoActivities("Watch C# videos","true","Monday","Watch C# videos to improve knowledge");
           TodoActivities.todolist.Add(activity1);
            TodoActivities activity2 = new TodoActivities("Exercising", "true", "Monday", "Exercising for 30 minuites to improve blood flow");
            TodoActivities.todolist.Add(activity2);
            TodoActivities activity3 = new TodoActivities("Meeting", "true", "Tuesday", "Attending strategy meeting");
            TodoActivities.todolist.Add(activity3);
            TodoActivities activity4 = new TodoActivities("Cooking", "true", "Thursday", "Watch some cooking shows");
            TodoActivities.todolist.Add(activity4);

          Start:

            Console.WriteLine("Welcome to your Personal ToDo list: \n \t Enter A to create a new Todo: " +
                "\n \t Enter S to show all TodList: \n \t Enter E to Edit: ");
            Console.Write("Enter a choice: ");

            string action = Console.ReadLine();
               
                if (action == "A")
                {
                Console.Write("please enter your activity: ");
                string activity = Console.ReadLine();

                Console.Write("Enter Due Day: ");
                string dueday = Console.ReadLine();

                Console.Write("Enter ToDo notes: ");
                string notes = Console.ReadLine();

                string status = "Not Done";
                //

                TodoActivities newactivity = new TodoActivities(activity, status, dueday, notes);
                TodoActivities.todolist.Add(newactivity);

                Console.WriteLine($"You have added {newactivity.activity} as an entry to your Todo list," +
                    $" the activity is due on {newactivity.dueday} ");

               // Console.ReadLine();
                goto Start;

               }
                else {Console.WriteLine("Enter a Valid Entry");}


              //Console.WriteLine(TodoActivities.TodoHistory());


            if (action == "S")
            {
                Console.WriteLine(TodoActivities.TodoHistory());
                goto Start;
            }

            if (action == "E")
            {
                TodoActivities.TodoLists();
                int selection = Convert.ToInt32( Console.ReadLine());


                var selected = TodoActivities.todolist[selection - 1];
                if (selected.status.Length>0)
                {
                    Console.Write("Enter New Due Day: ");
                    string dueday = Console.ReadLine();

                 
                    selected.dueday = dueday;
                    TodoActivities.todolist[selection - 1] = selected;

                    Console.WriteLine($"You have modiifed {selected.activity} as an entry to your Todo list," +
                 $" the activity is due on {selected.dueday} ");
                    goto Start;

                }

                
            }
        }
    }
}
