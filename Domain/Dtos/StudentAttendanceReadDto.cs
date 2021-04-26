using System;

namespace Domain.Dtos
{
    public class StudentAttendanceReadDto
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }

        //[System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public string AttendAt { get; set; }
        public string LeaveAt { get; set; }

    }
}