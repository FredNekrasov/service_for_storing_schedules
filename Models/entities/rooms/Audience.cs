﻿using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities.rooms
{
    [PrimaryKey(nameof(ID))]
    public class Audience
    {
        public int ID { get; set; }
        public int AudienceTypeID { get; set; }
        public int SeatsNumber { get; set; }
        public int StudentNumber { get; set; }
        public string AudienceNumber { get; set; } = string.Empty;
        public virtual AudienceType AudienceType { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
