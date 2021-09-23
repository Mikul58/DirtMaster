﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirtMaster.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
