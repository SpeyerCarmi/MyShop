﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; } = null!;
        [JsonIgnore]
        public virtual Product Product { get; set; } = null!;
    }
}