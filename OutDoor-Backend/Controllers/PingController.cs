﻿using Microsoft.AspNetCore.Mvc;
using OutDoor_Models.Models;
using OutDoor_Services;

namespace OutDoor_Backend.Controllers
{
    public class PingController : ControllerBase
    {
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public PingController(IWebHostEnvironment currentEnvironment)
        {
            CurrentEnvironment = currentEnvironment;
        }

        [HttpGet]
        [Route("/ping")]
        public string Ping()
        {
            var envName = CurrentEnvironment.EnvironmentName;
            var appName = CurrentEnvironment.ApplicationName;

            return " Ok app runing \n EnvName: " + envName + "\n AppName: " + appName;
        }
    }
}