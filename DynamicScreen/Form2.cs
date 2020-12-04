using DynamicScreen.Business.HardCode;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class Form2 : Form
    {
        private readonly IConfigurationRepository _configurationRepository;
        public Form2(Context db)
        {
            InitializeComponent();

            _configurationRepository = new ConfigurationRepository(db);

            var testeClass = new TransformadorParamEng();
            testeClass.Teste();

            //Obstáculo = 231
            //Transformador = 44

            var lista = _configurationRepository.GetConfigurationColumnRows(11);

            var cargaInicial = new InitialDataBase(db);
        }

    }

    public enum TipoFase
    {
        Monofasico = 1,
        Trifasico = 2,
    }

    public class TransformadorParamEng
    {
        public double TensaoOperacao { get; set; }
        public TipoFase TipoFaseDestino { get; set; }
        public string FaseOrigem { get; set; }
        public long Codigo { get; set; }
        public int Visao { get; set; }
        public string Descricao { get; set; }
        public double Potencia { get; set; }
        public bool AtivoPdn { get; set; }
        public long CodigoChave { get; set; }
        public long CodigoElo { get; set; }


        public List<TransformadorParamEng> ListaTransformadorPdnHardCoded;

        public void Teste()
        {
            ListaTransformadorPdnHardCoded = new List<TransformadorParamEng>();

            ListaTransformadorPdnHardCoded.AddRange(new TransformadorParamEng[]{
                new TransformadorParamEng(){
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AB",
                    Codigo = 20004095,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng(){
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "BC",
                    Codigo = 20004095,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AC",
                    Codigo = 20004095,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004095,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AB",
                    Codigo = 20004099,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "BC",
                    Codigo = 20004099,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AC",
                    Codigo = 20004099,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004099,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AB",
                    Codigo = 20004126,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 37KVA",
                    Potencia = 37,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "BC",
                    Codigo = 20004126,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 37KVA",
                    Potencia = 37,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AC",
                    Codigo = 20004126,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 37KVA",
                    Potencia = 37,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004126,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 37KVA",
                    Potencia = 37,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AB",
                    Codigo = 20004154,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006349
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "BC",
                    Codigo = 20004154,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006349
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "AC",
                    Codigo = 20004154,
                    Visao = 3,
                    Descricao = "Monofásico 13,8KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006349
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004155,
                    Descricao = "Trifásico 13,8KVA - 30KVA",
                    Potencia = 30,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004193,
                    Visao = 3,
                    Descricao = "Trifásico 13,8KVA - 45KVA",
                    Potencia = 45,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004412,
                    Visao = 3,
                    Descricao = "Trifásico 13,8KVA - 75KVA",
                    Potencia = 75,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004452,
                    Visao = 3,
                    Descricao = "Trifásico 13,8KVA - 112,5KVA",
                    Potencia = 112.5,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006349
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004456,
                    Visao = 3,
                    Descricao = "Trifásico 13,8KVA - 150KVA",
                    Potencia = 150,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006379
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 13.8,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004480,
                    Visao = 3,
                    Descricao = "Trifásico 13,8KVA - 225KVA",
                    Potencia = 225,
                    AtivoPdn = true,
                    CodigoChave = 15002640,
                    CodigoElo = 15006379
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "A",
                    Codigo = 20004214,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "B",
                    Codigo = 20004214,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "C",
                    Codigo = 20004214,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004214,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 10KVA",
                    Potencia = 10,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "A",
                    Codigo = 20004218,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "B",
                    Codigo = 20004218,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "C",
                    Codigo = 20004218,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004218,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 15KVA",
                    Potencia = 15,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "A",
                    Codigo = 20004243,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 25KVA",
                    Potencia = 25,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "B",
                    Codigo = 20004243,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 25KVA",
                    Potencia = 25,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "C",
                    Codigo = 20004243,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 25KVA",
                    Potencia = 25,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "A",
                    Codigo = 20004249,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 37,5KVA",
                    Potencia = 37.5,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "B",
                    Codigo = 20004249,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 37,5KVA",
                    Potencia = 37.5,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "C",
                    Codigo = 20004249,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 37,5KVA",
                    Potencia = 37.5,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004249,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 37,5KVA",
                    Potencia = 37.5,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006340
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "A",
                    Codigo = 20004273,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "B",
                    Codigo = 20004273,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "C",
                    Codigo = 20004273,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Monofasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004273,
                    Visao = 3,
                    Descricao = "Monofásico 19,9KV - 50KVA",
                    Potencia = 50,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004516,
                    Visao = 3,
                    Descricao = "Trifásico 34,5KV - 30KVA",
                    Potencia = 30,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006310
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004540,
                    Visao = 3,
                    Descricao = "Trifásico 34,5KV - 45KVA",
                    Potencia = 45,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006315
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004546,
                    Visao = 3,
                    Descricao = "Trifásico 34,5KV - 75KVA",
                    Potencia = 75,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006344
                },
                new TransformadorParamEng()
                {
                    TensaoOperacao = 34.5,
                    TipoFaseDestino = TipoFase.Trifasico,
                    FaseOrigem = "ABC",
                    Codigo = 20004561,
                    Visao = 3,
                    Descricao = "Trifásico 34,5KV - 112,5KVA",
                    Potencia = 112.5,
                    AtivoPdn = true,
                    CodigoChave = 15002645,
                    CodigoElo = 15006340
                }
            });
        }
    }
}
