using System.Threading;

namespace Events
{
    public class Work
    {
        // Method that simulate a process that causes call event raiser.
        public void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100); // Simulates work doing
            }

            Worker.GetInstance().OnWorkDone(this, "Work finished."); // Calls event raiser
        }
    }
}