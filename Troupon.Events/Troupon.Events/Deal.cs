using System;

namespace Troupon.Events
{
    public class Deal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CurrentPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string Address { get; set; }
    }
}
