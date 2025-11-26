using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class DebitNoteDetailDAO
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

        private string oA_Subject;

        private string oA_caseNo;

        private string oA_CaseDetail;

        private double oA_Amount;

        private string typeP;

        private decimal vat_amount;

        private int no_of_days;

        private decimal interest_pct;

        private decimal interest_amount;

        private decimal ait_pct;

        private decimal ait_amount;

        private string particulars;

        private decimal debquantity;

        public decimal AIT_Amount
        {
            get
            {
                return this.ait_amount;
            }
            set
            {
                this.ait_amount = value;
            }
        }

        public decimal AIT_Pct
        {
            get
            {
                return this.ait_pct;
            }
            set
            {
                this.ait_pct = value;
            }
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

        public short Code_id_m
        {
            get;
            set;
        }

        public decimal DebQuantity
        {
            get
            {
                return this.debquantity;
            }
            set
            {
                this.debquantity = value;
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

        public decimal Interest_Amount
        {
            get
            {
                return this.interest_amount;
            }
            set
            {
                this.interest_amount = value;
            }
        }

        public decimal Interest_Pct
        {
            get
            {
                return this.interest_pct;
            }
            set
            {
                this.interest_pct = value;
            }
        }

        public bool isRebatable
        {
            get;
            set;
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

        public int No_of_Days
        {
            get
            {
                return this.no_of_days;
            }
            set
            {
                this.no_of_days = value;
            }
        }

        public double OA_Amount
        {
            get
            {
                return this.oA_Amount;
            }
            set
            {
                this.oA_Amount = value;
            }
        }

        public string OA_CaseDetail
        {
            get
            {
                return this.oA_CaseDetail;
            }
            set
            {
                this.oA_CaseDetail = value;
            }
        }

        public string OA_CaseNo
        {
            get
            {
                return this.oA_caseNo;
            }
            set
            {
                this.oA_caseNo = value;
            }
        }

        public string OA_Subject
        {
            get
            {
                return this.oA_Subject;
            }
            set
            {
                this.oA_Subject = value;
            }
        }

        public short OtherDeductReasonId
        {
            get;
            set;
        }

        public string Particulars
        {
            get
            {
                return this.particulars;
            }
            set
            {
                this.particulars = value;
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

        public short reason_drcr
        {
            get;
            set;
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

        public decimal Vat_Amount
        {
            get
            {
                return this.vat_amount;
            }
            set
            {
                this.vat_amount = value;
            }
        }

        public DebitNoteDetailDAO()
        {
        }
    }
}
