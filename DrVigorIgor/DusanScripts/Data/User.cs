﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CldMedAPI.Data
{
    public class User
    {
        private int _id;
        private string _name;
        private string _username;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Username { get => _username; set => _username = value; }
    }
}
