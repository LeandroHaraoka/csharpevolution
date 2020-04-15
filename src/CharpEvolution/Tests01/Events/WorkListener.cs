using System;

namespace Events
{
    public class WorkListener
    {
        public WorkListener()
        {
            Worker.GetInstance().WorkDone += 
                (sender, eventArgs) =>
                {
                    Console.WriteLine(eventArgs.Name);
                };            
        }
    }
}