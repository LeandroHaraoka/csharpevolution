using System;

namespace Events
{
    public class WorkListener
    {
        public WorkListener()
        {
            // Subscribe to event WorkDone.
            Worker.GetInstance().WorkDone += 
                (sender, eventArgs) =>
                {
                    Console.WriteLine(eventArgs.Name);
                };            
        }
    }
}