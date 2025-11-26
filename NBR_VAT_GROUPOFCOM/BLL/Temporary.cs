using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Temporary
    {
        private short rowNo;

        private string categoryName;

        private string subCategoryName;

        private string itemName;

        private string serialNo;

        private string pLotNo;

        private string batchNo;

        private DateTime mfgDate;

        private string strProperty1;

        private string strProperty2;

        private string strProperty3;

        private string strProperty4;

        private string strProperty5;

        private string strUnitName;

        private double unitPriceBDT;

        private double othersPrice;

        private double vat;

        private double sd;

        private double cd;

        private double tti;

        private double atv;

        private double ait;

        private double rd;

        private double toatlPrice;

        private double grandTotalPrice;

        private int quantity;

        public double AIT
        {
            get
            {
                return this.ait;
            }
            set
            {
                this.ait = value;
            }
        }

        public double ATV
        {
            get
            {
                return this.atv;
            }
            set
            {
                this.atv = value;
            }
        }

        public string BatchNo
        {
            get
            {
                return this.batchNo;
            }
            set
            {
                this.batchNo = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public double CD
        {
            get
            {
                return this.cd;
            }
            set
            {
                this.cd = value;
            }
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public DateTime MfgDate
        {
            get
            {
                return this.mfgDate;
            }
            set
            {
                this.mfgDate = value;
            }
        }

        public double OthersPrice
        {
            get
            {
                return this.othersPrice;
            }
            set
            {
                this.othersPrice = value;
            }
        }

        public string PLotNo
        {
            get
            {
                return this.pLotNo;
            }
            set
            {
                this.pLotNo = value;
            }
        }

        public string Property1
        {
            get
            {
                return this.strProperty1;
            }
            set
            {
                this.strProperty1 = value;
            }
        }

        public string Property2
        {
            get
            {
                return this.strProperty2;
            }
            set
            {
                this.strProperty2 = value;
            }
        }

        public string Property3
        {
            get
            {
                return this.strProperty3;
            }
            set
            {
                this.strProperty3 = value;
            }
        }

        public string Property4
        {
            get
            {
                return this.strProperty4;
            }
            set
            {
                this.strProperty4 = value;
            }
        }

        public string Property5
        {
            get
            {
                return this.strProperty5;
            }
            set
            {
                this.strProperty5 = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public double RD
        {
            get
            {
                return this.rd;
            }
            set
            {
                this.rd = value;
            }
        }

        public short RowNo
        {
            get
            {
                return this.rowNo;
            }
            set
            {
                this.rowNo = value;
            }
        }

        public double SD
        {
            get
            {
                return this.sd;
            }
            set
            {
                this.sd = value;
            }
        }

        public string SerialNo
        {
            get
            {
                return this.serialNo;
            }
            set
            {
                this.serialNo = value;
            }
        }

        public string SubCategoryName
        {
            get
            {
                return this.subCategoryName;
            }
            set
            {
                this.subCategoryName = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.grandTotalPrice;
            }
            set
            {
                this.grandTotalPrice = value;
            }
        }

        public double TTI
        {
            get
            {
                return this.tti;
            }
            set
            {
                this.tti = value;
            }
        }

        public string UnitName
        {
            get
            {
                return this.strUnitName;
            }
            set
            {
                this.strUnitName = value;
            }
        }

        public double UnitPriceBDT
        {
            get
            {
                return this.unitPriceBDT;
            }
            set
            {
                this.unitPriceBDT = value;
            }
        }

        public double UnitPriceTotal
        {
            get
            {
                return this.toatlPrice;
            }
            set
            {
                this.toatlPrice = value;
            }
        }

        public double VAT
        {
            get
            {
                return this.vat;
            }
            set
            {
                this.vat = value;
            }
        }

        public Temporary()
        {
        }
    }
}