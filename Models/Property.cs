﻿using PropertyManApi.Enums;

namespace PropertyManApi.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public PropertyType PropertyType { get; set; }
        public virtual IList<Unit> Units { get; set; } = [];
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    }
}
