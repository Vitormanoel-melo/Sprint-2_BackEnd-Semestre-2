﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClassesHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeRepository { get; set; }

        public ClassesHabilidadeController()
        {
            _classeRepository = new ClasseHabilidadeRepository();
        }

    }
}
