using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsTreasuryChallanDAODetail
    {
        private int scroll_Id;

        private int trns_treasury_detailId;

        private int tr_challan_id;

        private int purchase_challan_id;

        private string purchase_challan_no;

        private decimal amount;

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public int Index_Id
        {
            get;
            set;
        }

        public bool Is_SD
        {
            get;
            set;
        }

        public bool Is_VAT
        {
            get;
            set;
        }

        public int Party_Id
        {
            get;
            set;
        }

        public int Purchase_challan_id
        {
            get
            {
                return this.purchase_challan_id;
            }
            set
            {
                this.purchase_challan_id = value;
            }
        }

        public string purchaseChallanNo
        {
            get
            {
                return this.purchase_challan_no;
            }
            set
            {
                this.purchase_challan_no = value;
            }
        }

        public int Scroll_Id
        {
            get
            {
                return this.scroll_Id;
            }
            set
            {
                this.scroll_Id = value;
            }
        }

        public int Tr_challan_id
        {
            get
            {
                return this.tr_challan_id;
            }
            set
            {
                this.tr_challan_id = value;
            }
        }

        public int Trns_treasury_detailId
        {
            get
            {
                return this.trns_treasury_detailId;
            }
            set
            {
                this.trns_treasury_detailId = value;
            }
        }

        public trnsTreasuryChallanDAODetail()
        {
        }
    }
}