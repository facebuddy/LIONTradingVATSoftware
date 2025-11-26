using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CreditNoteDetailDAO
    {
        private short rowNo;

        private string category;

        private string subCategory;

        private string item;

        private int property1;

        private int property2;

        private int property3;

        private int property4;

        private int property5;

        private string property_Text1;

        private string property_Text2;

        private string property_Text3;

        private string property_Text4;

        private string property_Text5;

        private string hscode;

        private int quantity;

        private string unit;

        private double unitPrice;

        private double vat;

        private double sd;

        private double gUnitPrice;

        private double gTotalPrice;

        private double previousAmount;

        private double totalPricewithVat;

        private double totalTax;

        private string reasonOfReturn;

        private int challan_id;

        private short unitId;

        private short userId;

        private short item_id;

        private double hdVat;

        private double hdSD;

        private char type;

        private short decreaseId;

        private long detailId;

        private char status;

        private short sp_return;

        private string typeP;

        private decimal credquantity;

        public decimal actualQuantity
        {
            get;
            set;
        }

        public double ActUnitPrice
        {
            get;
            set;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public int Challan_id
        {
            get
            {
                return this.challan_id;
            }
            set
            {
                this.challan_id = value;
            }
        }

        public int creditUnitId
        {
            get;
            set;
        }

        public decimal CredQuantity
        {
            get
            {
                return this.credquantity;
            }
            set
            {
                this.credquantity = value;
            }
        }

        public short DecreaseId
        {
            get
            {
                return this.decreaseId;
            }
            set
            {
                this.decreaseId = value;
            }
        }

        public long DetailId
        {
            get
            {
                return this.detailId;
            }
            set
            {
                this.detailId = value;
            }
        }

        public double GTotalPrice
        {
            get
            {
                return this.gTotalPrice;
            }
            set
            {
                this.gTotalPrice = value;
            }
        }

        public double GUnitPrice
        {
            get
            {
                return this.gUnitPrice;
            }
            set
            {
                this.gUnitPrice = value;
            }
        }

        public double HdSD
        {
            get
            {
                return this.hdSD;
            }
            set
            {
                this.hdSD = value;
            }
        }

        public double HdVat
        {
            get
            {
                return this.hdVat;
            }
            set
            {
                this.hdVat = value;
            }
        }

        public string Hscode
        {
            get
            {
                return this.hscode;
            }
            set
            {
                this.hscode = value;
            }
        }

        public string Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public short Item_id
        {
            get
            {
                return this.item_id;
            }
            set
            {
                this.item_id = value;
            }
        }

        public double PreviousAmount
        {
            get
            {
                return this.previousAmount;
            }
            set
            {
                this.previousAmount = value;
            }
        }

        public int Property1
        {
            get
            {
                return this.property1;
            }
            set
            {
                this.property1 = value;
            }
        }

        public string Property1_Text
        {
            get
            {
                return this.property_Text1;
            }
            set
            {
                this.property_Text1 = value;
            }
        }

        public int Property2
        {
            get
            {
                return this.property2;
            }
            set
            {
                this.property2 = value;
            }
        }

        public string Property2_Text
        {
            get
            {
                return this.property_Text2;
            }
            set
            {
                this.property_Text2 = value;
            }
        }

        public int Property3
        {
            get
            {
                return this.property3;
            }
            set
            {
                this.property3 = value;
            }
        }

        public string Property3_Text
        {
            get
            {
                return this.property_Text3;
            }
            set
            {
                this.property_Text3 = value;
            }
        }

        public int Property4
        {
            get
            {
                return this.property4;
            }
            set
            {
                this.property4 = value;
            }
        }

        public string Property4_Text
        {
            get
            {
                return this.property_Text4;
            }
            set
            {
                this.property_Text4 = value;
            }
        }

        public int Property5
        {
            get
            {
                return this.property5;
            }
            set
            {
                this.property5 = value;
            }
        }

        public string Property5_Text
        {
            get
            {
                return this.property_Text5;
            }
            set
            {
                this.property_Text5 = value;
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

        public string ReasonOfReturn
        {
            get
            {
                return this.reasonOfReturn;
            }
            set
            {
                this.reasonOfReturn = value;
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

        public double Sd
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

        public short Sp_Return
        {
            get
            {
                return this.sp_return;
            }
            set
            {
                this.sp_return = value;
            }
        }

        public char Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string SubCategory
        {
            get
            {
                return this.subCategory;
            }
            set
            {
                this.subCategory = value;
            }
        }

        public double TotalPricewithVat
        {
            get
            {
                return this.totalPricewithVat;
            }
            set
            {
                this.totalPricewithVat = value;
            }
        }

        public double TotalTax
        {
            get
            {
                return this.totalTax;
            }
            set
            {
                this.totalTax = value;
            }
        }

        public char Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string TypeP
        {
            get
            {
                return this.typeP;
            }
            set
            {
                this.typeP = value;
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public short UnitId
        {
            get
            {
                return this.unitId;
            }
            set
            {
                this.unitId = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public short UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        public double Vat
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

        public CreditNoteDetailDAO()
        {
        }
    }
}
