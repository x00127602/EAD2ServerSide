using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace GameServerAPI.Models
{
    public class GameServerItem
    {
        //ID for Game
        public long Id { get; set; }

        //Animal Crossing, GTA5, Pokemon
        public String GameName { get; set; }

        //EG PC, Switch, PS4, Xbox One, Other
        public String Playstation4 { get; set; }

        public String XboxOne { get; set; }

        public String Switch { get; set; }

        public String PC { get; set; }

        //Star Rating
        [Range(0, 5)]
        public double Rating { get; set; }
    }
}
