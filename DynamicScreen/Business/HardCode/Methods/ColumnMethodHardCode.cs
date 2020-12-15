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
        #region topologia
        public IEnumerable<ValueDto> ObterListaDeTopologias()
        {
            var topologia = new Topologias().ListaTopologias;
            return MapTopologiaToValueDto(topologia);
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
        #endregion

        #region chave
        public IEnumerable<ValueDto> ObterListaDeChaves()
        {
            var chave = new Chaves().ListaChaves;
            return MapChaveToValueDto(chave);
        }

        private IEnumerable<ValueDto> MapChaveToValueDto(IEnumerable<Chave> chaves)
        {
            foreach (var item in chaves)
            {
                var valueDto = new ValueDto
                {
                    Id = item.Codigo,
                    Value = item.Descricao
                };
                yield return valueDto;
            }
        }
        #endregion

        #region transformador
        public IEnumerable<ValueDto> ObterListaDeTransformadores()
        {
            var transformador = new Transformadores().ListaTransformadores;
            return MapTransformadorToValueDto(transformador);
        }

        private IEnumerable<ValueDto> MapTransformadorToValueDto(IEnumerable<Transformador> transformadores)
        {
            foreach (var item in transformadores)
            {
                var valueDto = new ValueDto
                {
                    Id = item.Codigo,
                    Value = item.Descricao
                };
                yield return valueDto;
            }
        }
        #endregion

        #region condutor
        public IEnumerable<ValueDto> ObterListaDeCondutores()
        {
            var condutor = new Condutores().ListaCondutores;
            return MapCondutorToValueDto(condutor);
        }

        private IEnumerable<ValueDto> MapCondutorToValueDto(IEnumerable<Condutor> condutores)
        {
            foreach (var item in condutores)
            {
                var valueDto = new ValueDto
                {
                    Id = item.Codigo,
                    Value = item.Descricao
                };
                yield return valueDto;
            }
        }
        #endregion
    }

    #region topologia
    public class Topologias
    {
        public List<Topologia> ListaTopologias { get; set; }

        public Topologias()
        {
            ListaTopologias = new List<Topologia>
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

    #endregion

    #region chave
    public class Chaves
    {
        public List<Chave> ListaChaves { get; set; }

        public Chaves()
        {
            ListaChaves = new List<Chave>
            {
                new Chave
                {
                    Codigo = "15002640",
                    Descricao = "CHAVE FUS. DSTB,TIPO C,15KV C/PF. PORCELANA"
                },
                new Chave
                {
                    Codigo = "20009773",
                    Descricao = "SECCIONADORA DE FACA UNIP 15KV 630A"
                },
                new Chave
                {
                    Codigo = "20016373",
                    Descricao = "RELIGADOR AUT MONO S. 25KV 3 RELIG TR30S"
                },
            };
        }
    }

    public class Chave
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }


    #endregion

    #region transformador
    public class Transformadores
    {
        public List<Transformador> ListaTransformadores { get; set; }

        public Transformadores()
        {
            ListaTransformadores = new List<Transformador>
            {
                new Transformador
                {
                    Codigo = "20004095",
                    Descricao = "Monofásico 13,8kV - 10kVA"
                },
                new Transformador
                {
                    Codigo = "20004099",
                    Descricao = "Monofásico 13,8kV - 15kVA"
                },
                new Transformador
                {
                    Codigo = "20004214",
                    Descricao = "Monofásico 19,9kV - 10kVA"
                },
            };
        }
    }

    public class Transformador
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    #endregion

    #region condutor
    public class Condutores
    {
        public List<Condutor> ListaCondutores { get; set; }

        public Condutores()
        {
            ListaCondutores = new List<Condutor>
            {
                new Condutor
                {
                    Codigo = "20009698",
                    Descricao = "CABO DE ALUM. TRIPLEX 35 MM2"
                },
                new Condutor
                {
                    Codigo = "20009716",
                    Descricao = "CABO DE ALUM. QUADRUPLEX 70 MM2"
                }
            };
        }
    }

    public class Condutor
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    #endregion

}
