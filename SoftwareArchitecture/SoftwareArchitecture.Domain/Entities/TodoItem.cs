﻿using SoftwareArchitecture.Domain.Enums;

namespace SoftwareArchitecture.Domain.Enitites
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Done { get; set; }
    }
}
