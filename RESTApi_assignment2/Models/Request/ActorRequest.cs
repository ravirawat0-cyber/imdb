﻿using System;

namespace IMDB.Models.Request
{
    public class ActorRequest
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }   
        public string Sex { get; set; }
    }
}
