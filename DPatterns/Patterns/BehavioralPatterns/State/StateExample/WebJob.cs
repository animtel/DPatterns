using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.BehavioralPatterns.State.StateExample
{
    #region GoodPractice
    class Job
    {
        public IJobState State { get; set; }

        public Job(IJobState currentState)
        {
            State = currentState;
        }

        public void NextPhase()
        {
            State.NextPhase(this);
        }

        public void BeforePhase()
        {
            State.BeforePhase(this);
        }
    }

    interface IJobState
    {
        void NextPhase(Job job);
        void BeforePhase(Job job);
    }

    class JobStoppedState : IJobState
    {
        public void NextPhase(Job job)
        {
            //for example job.StartProcess of... and other
            Console.WriteLine("Set up state of job in pending of actions");
            job.State = new PendingState();
        }

        public void BeforePhase(Job job)
        {
            Console.WriteLine("Doing nothing because it's already stopped");
        }
    }
    class PendingState : IJobState
    {
        public void NextPhase(Job job)
        {
            Console.WriteLine("We receive some data and can to start processing it!");
            job.State = new InProgressState(); //pass received data into this state for processing
        }

        public void BeforePhase(Job job)
        {
            Console.WriteLine("We haven't receive any data and stopped of pending");
            job.State = new JobStoppedState();
        }
    }
    class InProgressState : IJobState
    {
        public void NextPhase(Job job)
        {
            Console.WriteLine("Doing nothing because we already processing data");
        }

        public void BeforePhase(Job job)
        {
            Console.WriteLine("Close connection, close memory streams, close all and stoping processing and go to pending new data");
            job.State = new PendingState();
        }
    }
    #endregion

    #region BadPractice
    enum BadJobState
    {
        Stopped,
        Pending,
        InProgress
    }
    class BadJob
    {
        public BadJobState State { get; set; }

        public BadJob(BadJobState state)
        {
            State = state;
        }

        public void NextPhase()
        {
            if (State == BadJobState.Stopped)
            {
                Console.WriteLine("Set up state of job in pending of actions");
                State = BadJobState.Pending;
            }
            else if (State == BadJobState.Pending)
            {
                Console.WriteLine("We receive some data and can to start processing it!");
                State = BadJobState.InProgress;
            }
            else if (State == BadJobState.InProgress)
            {
                Console.WriteLine("Doing nothing because we already processing data");
            }
        }
        public void BeforePhase()
        {
            if (State == BadJobState.Pending)
            {
                Console.WriteLine("We haven't receive any data and stopped of pending");
                State = BadJobState.Stopped;
            }
            if (State == BadJobState.Stopped)
            {
                Console.WriteLine("Doing nothing because it's already stopped");
            }
            else if (State == BadJobState.InProgress)
            {
                Console.WriteLine("Close connection, close memory streams, close all and stoping processing and go to pending new data");
                State = BadJobState.Pending;
            }
        }
    }
    #endregion
}
