﻿namespace Web_API_for_scheduling.Models.dto.date
{
    public class WeekDto
    {
        public Guid ID { get; set; }
        public SemesterDto? Semester { get; set; }
        public int? WeekNumber { get; set; }
    }
}
