﻿namespace Learning.Application.Dtos.RequestDtos
{
    public class BuildSentanceQuestionRequestDto
    {
        public string Condition { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public List<string> Words { get; set; } = new List<string>();

        //Relation with Domain
        public int DomainId { get; set; }
    }
}