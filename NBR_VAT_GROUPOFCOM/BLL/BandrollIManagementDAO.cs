using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class BandrollIManagementDAO
    {
        private int bandroll_id;

        private int row_no;

        private int item_id;

        private int property_id1;

        private int property_id2;

        private int property_id3;

        private int property_id4;

        private int property_id5;

        private string property_Text1;

        private string property_Text2;

        private string property_Text3;

        private string property_Text4;

        private string property_Text5;

        private int unit_id;

        private decimal quantity;

        private bool is_deleted;

        private DateTime date_insert;

        private DateTime date_update;

        private short user_id_insert;

        private short user_id_update;

        private string remark;

        private string brandName;

        private decimal bandrollAdjAmount;

        private DateTime mfgDate;

        private DateTime expiryDate;

        public decimal BandrollAdjAmount
        {
            get
            {
                return this.bandrollAdjAmount;
            }
            set
            {
                this.bandrollAdjAmount = value;
            }
        }

        public string BrandName
        {
            get
            {
                return this.brandName;
            }
            set
            {
                this.brandName = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }
            set
            {
                this.expiryDate = value;
            }
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public int Item_id
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

        public int Property_id1
        {
            get
            {
                return this.property_id1;
            }
            set
            {
                this.property_id1 = value;
            }
        }

        public int Property_id2
        {
            get
            {
                return this.property_id2;
            }
            set
            {
                this.property_id2 = value;
            }
        }

        public int Property_id3
        {
            get
            {
                return this.property_id3;
            }
            set
            {
                this.property_id3 = value;
            }
        }

        public int Property_id4
        {
            get
            {
                return this.property_id4;
            }
            set
            {
                this.property_id4 = value;
            }
        }

        public int Property_id5
        {
            get
            {
                return this.property_id5;
            }
            set
            {
                this.property_id5 = value;
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

        public decimal Quantity
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

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }

        public int Row_No
        {
            get
            {
                return this.row_no;
            }
            set
            {
                this.row_no = value;
            }
        }

        public int Unit_id
        {
            get
            {
                return this.unit_id;
            }
            set
            {
                this.unit_id = value;
            }
        }

        public short User_id_insert
        {
            get
            {
                return this.user_id_insert;
            }
            set
            {
                this.user_id_insert = value;
            }
        }

        public short User_id_update
        {
            get
            {
                return this.user_id_update;
            }
            set
            {
                this.user_id_update = value;
            }
        }

        public BandrollIManagementDAO()
        {
        }
    }
}
