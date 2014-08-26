using System;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using TimeTracker.Domain.Infrastructure.Mapping;

namespace TimeTracker.UnitTests.Domain.Infrastructure.Steps
{
    [Binding]
    public class MappingSteps
    {
        private DummyCommand From;
        private DummyEvent To;

        [Given(@"from object has public properties")]
        public void GivenFromObjectHasPublicProperties()
        {
            From = new DummyCommand(Guid.NewGuid(), "dummy string");
        }

        [Given(@"to class has public constructor with zero arguments")]
        public void GivenToClassHasPublicConstructorWithZeroArguments()
        {
            typeof(DummyEvent).GetConstructors().Any(c => !c.GetParameters().Any()).Should().BeTrue();
        }

        [Given(@"to class has public constructor with one or more arguments")]
        public void GivenToClassHasPublicConstructorWithOneOrMoreArguments()
        {
            typeof(DummyEvent).GetConstructors().Count(c => c.GetParameters().Any()).Should().Be(1);
        }

        [When(@"I call from\.MapTo<To>")]
        public void WhenICallFrom_MapTo()
        {
            To = From.MapTo<DummyEvent>();
        }

        [Then(@"to object is created via public constructor with arguments")]
        public void ThenToObjectIsCreatedViaPublicConstructorWithArguments()
        {
            To.Should().BeOfType<DummyEvent>();
            To.Should().NotBeNull();
            To.Id.Should().Be(From.Id);
            To.Name.Should().Be(From.Name);
        }

        public class DummyCommand
        {
            public DummyCommand(Guid id, string name)
            {
                Id = id;
                Name = name;
            }

            public Guid Id { get; private set; }
            public String Name { get; private set; }
        }

        public class DummyEvent
        {
            // ReSharper disable once EmptyConstructor
            // 
            // Empty constructor is part of spec.
            public DummyEvent()
            {
            }

            public DummyEvent(Guid id, string name)
            {
                Id = id;
                Name = name;
            }

            public Guid Id { get; private set; }
            public string Name { get; private set; }
        }
    }
}