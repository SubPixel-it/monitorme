using System;
using System.Collections.Generic;
using System.Timers;
using BusinessLogic;
using Models;

namespace Terminal
{
    class Program
    {
        private static MonitorLogic monitorLogic = new MonitorLogic();
        private static Timer checkTimer = new Timer();
        private static object lockObject = new object();
        
        static void Main(string[] args)
        {
            Console.WriteLine("\t~ MonitorMe Terminal ~");
            Console.WriteLine("");

            checkTimer.Interval = 1000;
            checkTimer.Enabled = true;
            checkTimer.AutoReset = true;
            checkTimer.Elapsed += CheckTimerOnElapsed;
            checkTimer.Start();

            Console.ReadLine();
            checkTimer.Stop();
            Console.WriteLine("\t~ Check stopped, press enter to close Terminal. ~");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void CheckTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                List<Monitor> activeMonitors = monitorLogic.Get(Monitor.State.Active);
                foreach (var monitor in activeMonitors)
                {
                    if ((DateTime.UtcNow - monitor.LastBeat) > monitor.MaxInterval)
                    {
                        Console.WriteLine($"Monitor {monitor.Name} last beat is over max interval!");
                        monitor.Status = Monitor.State.Alarm;
                        monitorLogic.Update(monitor);
                    }
                }
            }
        }
    }
}