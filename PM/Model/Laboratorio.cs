﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Laboratorio
    {
        public string cnpj { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string site { get; set; }
        public string rua { get; set; }
        public string cep { get; set; }
        public string lista_servicos_prestados { get; set; }
    }
}
