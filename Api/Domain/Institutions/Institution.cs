﻿using Api.Data.Entities;
using Api.Domain.Countries;

namespace Api.Domain.Institutions
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string Address { get; set; }

        public virtual Country Countries { get; set; }
    }
}
