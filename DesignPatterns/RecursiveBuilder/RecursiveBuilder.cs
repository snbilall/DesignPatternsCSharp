using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.RecursiveBuilder
{
    public class Person
    {
        public string Name { get; set; }
        public string Job { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Job: {Job}";
        }
    }

    public class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder <T> : PersonBuilder where T: PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonIJobBuilder<T> : PersonInfoBuilder<PersonIJobBuilder<T>> where T : PersonIJobBuilder<T>
    {
        public T WorksAsA(string job)
        {
            person.Job = job;
            return (T)this;
        }
    }

    public class PersonBuilderApi : PersonIJobBuilder<PersonBuilderApi> { }
}
