using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace nDeath.Models
{
    [DataContract]
    public class Point
    {
        [DataMember (Name = "X")]
        public int X { get; set; }

        [DataMember(Name = "Y")]
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}