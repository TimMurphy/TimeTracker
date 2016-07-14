﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Domain.Infrastructure.Support;

namespace TimeTracker.Domain.Infrastructure.Events
{
    public class EventQueue : IEventQueue
    {
        private readonly IEventStore EventStore;

        internal readonly Queue<IEvent> Queue = new Queue<IEvent>();

        public EventQueue(IEventStore eventStore)
        {
            EventStore = eventStore;
        }

        public Task AddAsync(IEnumerable<IEvent> events)
        {
            return Task.Run(() => Queue.Enqueue(events));
        }

        public Task ProcessAsync()
        {
            /////////////////////////////////////////
            // this is what i am working on
            /////////////////////////////////////////
            throw new NotImplementedException("this is what i am working on");
        }

        public void RegisterEventHandler(Action<IEvent> eventHandler)
        {
            throw new NotImplementedException();
        }
    }
}