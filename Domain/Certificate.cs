using System;

namespace Domain
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}