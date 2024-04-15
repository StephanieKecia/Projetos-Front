using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDados;
using CapaDeEntidade;

namespace CapaDeNegocio
{
    public class ClasseNegocio
    {
        ClasseDados clsDados = new ClasseDados();

        public string usuario { get; set; }
        public string senha { get; set; }

        public DataTable N_Login(ClasseEntidade obje)
        {
            return clsDados.DLogin(obje);
        }

    }
}
