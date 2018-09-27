﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.WebService.Models
{
    public class CountryModel : GeographicElementModel
    {
        public string Alpha3Code { get; set; }
        public List<StateModel> States { get; set; }
    }
}
