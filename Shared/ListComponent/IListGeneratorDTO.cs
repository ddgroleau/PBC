﻿using PBC.Shared.DOM_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.ListComponent
{
    public interface IListGeneratorDTO
    {
        public int ListId { get; set; }
        public int Days { get; set; }
        public List<ListDayDTO> GeneratedDays { get; set; }
    }
}
