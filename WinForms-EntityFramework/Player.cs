using System;
using System.Collections.Generic;
using System.Text;

namespace WinForms_EntityFramework
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
