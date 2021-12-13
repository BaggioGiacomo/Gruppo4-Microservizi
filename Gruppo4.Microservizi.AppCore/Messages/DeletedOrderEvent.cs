﻿using Gruppo4MicroserviziDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4MicroserviziDTO.DTOs
{
    public class DeletedOrderEvent
    {
        public Guid Id { get; set; }
        public IList<ProductInOrder> Products { get; set; } = new List<ProductInOrder>();
    }
}
