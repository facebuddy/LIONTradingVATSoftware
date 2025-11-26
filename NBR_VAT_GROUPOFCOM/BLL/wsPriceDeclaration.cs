using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class wsPriceDeclaration : WebService
    {
        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public wsPriceDeclaration()
        {
        }

        [WebMethod]
        public double GetItemUnitConversionValue(string fUnit, string tUnit)
        {
            double num = 1;
            DataTable valueFromScriept = this.objPDBll.GetValueFromScriept(int.Parse(fUnit), int.Parse(tUnit));
            if (valueFromScriept != null)
            {
                if (valueFromScriept.Rows.Count > 0)
                {
                    num = Convert.ToDouble(valueFromScriept.Rows[0]["convert_value"]);
                }
                else if (num == 1)
                {
                    DataTable valueFromScrieptSec = this.objPDBll.GetValueFromScrieptSec(int.Parse(fUnit), int.Parse(tUnit));
                    if (valueFromScrieptSec.Rows.Count > 0)
                    {
                        num = 1 / Convert.ToDouble(valueFromScrieptSec.Rows[0]["convert_value"]);
                    }
                }
            }
            return num;
        }
    }
}
