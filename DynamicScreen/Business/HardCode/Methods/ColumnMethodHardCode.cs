using DynamicScreen.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicScreen.Business.Util;
using DynamicScreen.Dto;

namespace DynamicScreen.Business.HardCode.Methods
{
    public class ColumnMethodHardCode : IColumnMethod
    {
        public IEnumerable<ValueDto> ObterListaDeTopologias()
        {
            var topologia = new Topologias().ListaCondutores;
            return MapTopologiaToValueDto(topologia);
        }

        public IEnumerable<ValueDto> ObterRadioStatus()
        {
            var valueDtos = new List<ValueDto>()
            {
                new ValueDto
                {
                    Id = "true",
                    Value = "Ativo"
                },
                new ValueDto
                {
                    Id = "false",
                    Value = "Inativo"
                }
            };

            return valueDtos;
        }
        public IEnumerable<ValueDto> ObterVelocidadeDoVento()
        {
            var valueDtos = new List<ValueDto>()
            {
                new ValueDto
                {
                    Id = "60",
                    Value = "60km/h"
                },
                new ValueDto
                {
                    Id = "80",
                    Value = "80km/h"
                },
                new ValueDto
                {
                    Id = "100",
                    Value = "100km/h"
                }
            };

            return valueDtos;
        }

        private IEnumerable<ValueDto> MapTopologiaToValueDto(IEnumerable<Topologia> topologias)
        {
            foreach (var item in topologias)
            {
                var valueDto = new ValueDto
                {
                    Id = item.Codigo,
                    Value = item.Descricao
                };
                yield return valueDto;
            }
        }
    }

    public class Topologias
    {
        public List<Topologia> ListaCondutores { get; set; }

        public Topologias()
        {
            ListaCondutores = new List<Topologia>
            {
                new Topologia
                {
                    Codigo = "001",
                    Descricao = "RDA"
                },
                new Topologia
                {
                    Codigo = "002",
                    Descricao = "RDC"
                },
                new Topologia
                {
                    Codigo = "003",
                    Descricao = "RDP"
                },
            };
        }
    }

    public class Topologia
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
