﻿using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities
{
    [PrimaryKey(nameof(ID))]
    public class Group
    {
        public int ID { get; set; }
        public string GroupNumber { get; set; } = string.Empty;
        public string ShortNumber { get; set; } = string.Empty;
        public int StudentNumber { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
