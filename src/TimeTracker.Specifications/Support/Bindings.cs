using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TimeTracker.Specifications.Support
{
    [Binding]
    public class Bindings
    {
        public static readonly List<Action> AfterTestRunTasks = new List<Action>();

        [AfterTestRun]
        public static void AfterTestRun()
        {
            foreach (var afterTestRunTask in AfterTestRunTasks.ToArray())
            {
                AfterTestRunTasks.Remove(afterTestRunTask);
                afterTestRunTask();
            }
        }
    }
}
