using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__IMTAHAN_PRAYEKTI
{
    public class YanlisNomreException : Exception
    {
        public override string Message => "Nomre yanliz reqem ve - ola biler ve bir nomreden iki eded ola bilmez";
    }
}
