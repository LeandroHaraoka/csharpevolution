using System;

namespace Events
{
    public sealed class Worker
    {
        private static readonly Worker _Instance = new Worker();
        private Worker()
        {
        }

        public static Worker GetInstance()
        {
            return _Instance;
        }

        public event EventHandler<WorkDoneEventArgs> WorkDone;

        public void OnWorkDone(object sender, string name)
        {
            var workDoneDelegate =  WorkDone as EventHandler<WorkDoneEventArgs>;
            if (workDoneDelegate != null)
            {
                workDoneDelegate(sender, new WorkDoneEventArgs{Name = name});
            }
        }
    }
}


