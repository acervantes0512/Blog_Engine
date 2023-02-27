using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Implementations_test.MoqObjects
{
    public class MockStatusPost : StatusPost
    {
        public MockStatusPost()
        {
            this.Id = 1;
            this.Name = "EstadoPrueba";            
        }
    }
}
