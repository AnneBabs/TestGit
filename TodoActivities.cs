using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Challenge 1: Create a Todo-List , I want to be able to add, and edit activities from this todo-list
//Each Item in the To-do list can have Name of activity,
//Day of week I want to do it, Whether it has been done or Nor
namespace ToDo_list
{
    public class TodoActivities
    {
        public string activity { get; set; }
        public string status { get; set; }
        
        public string dueday { get; set; }
        public string notes { get; set; }

        public static List<TodoActivities> todolist = new List<TodoActivities>();

        public void newlist(string Activity, string Status, string Dueday, string Notes) 
        {
            TodoActivities newlist = new TodoActivities(Activity, Status, Dueday, Notes);
        }

        public TodoActivities( string Activity, string Status, string Dueday,string Notes) 
        {
            this.activity = Activity;
            this.status = Status;
            this.dueday = Dueday;
            this.notes = Notes;

        }

        public static string TodoHistory()
     
        {
           
            var report = new System.Text.StringBuilder();

            report.AppendLine("Activity\t\tStatus\t\tDuedate\t\tNotes");

            foreach (var item in TodoActivities.todolist)
            {
               // Console.WriteLine(item.activity);

              report.AppendLine($"{item.activity}\t\t{item.dueday}\t\t{item.status}\t\t{item.notes}");
            }
            return report.ToString();

        }



        public static void TodoLists()

        {
            Console.WriteLine("Please choose a note to edit (enter number to choose)");
            int index = 1;
            foreach (var item in TodoActivities.todolist)
            {
                Console.WriteLine(index + ": "+ item.activity);
                index++;

                
            }

           

        }

    }

    //public class 
}


