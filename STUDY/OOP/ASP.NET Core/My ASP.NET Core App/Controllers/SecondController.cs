﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_ASP.NET_Core_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {
        private IStudent _student;

        public SecondController(IStudent student) {

            this._student = student;

        }
        // GET: api/<SecondController>
        [HttpGet]
        public int Get()
        {
            //Tight Coupled
            //MathStudent cls = new MathStudent();
            //return cls.GetStudentCount();


            //Implement Loosly copupled design.
            return _student.GetStudentCount();
        }

    }
}
