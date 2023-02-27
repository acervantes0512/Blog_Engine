using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Implementations_test.MoqObjects
{
    public class MockPost : Post
    {
        public MockPost()
        {
            this.Id = 1;
            this.StatusPostId = 3;
            this.Tittle = "Titulo mock";
            this.Content = "Contenido mockContenido mock Contenido mock Contenido mock";
            this.CreationDate = Convert.ToDateTime("26/02/2023");
            this.UserAuthorId = 4;
        }
    }
}
