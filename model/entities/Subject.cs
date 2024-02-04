﻿using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities
{
    [PrimaryKey(nameof(ID))]
    public class Subject
    {
        public Guid ID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public int? LectureHours { get; set; }
        public int? PracticHours { get; set; }
        public int? TotalHours { get; set; }
        public int? ConsultationHours { get; set; }
        public string TypeOfCertification { get; set; } = string.Empty;
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
