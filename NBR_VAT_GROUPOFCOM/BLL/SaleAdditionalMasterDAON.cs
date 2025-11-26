using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SaleAdditionalMasterDAON
    {
        private int intChallanID;

        private string approvalRefNo;

        private string purchaseOrderNo;

        private string deliveryChallanNo;

        private string mrpNo;

        private string projectDetail;

        private string clientContact;

        private string ownContact;

        private short shUserIdInsert;

        private short shUserIdUpdate;

        public string ApprovalRefNo
        {
            get
            {
                return this.approvalRefNo;
            }
            set
            {
                this.approvalRefNo = value;
            }
        }

        public int ChallanID
        {
            get
            {
                return this.intChallanID;
            }
            set
            {
                this.intChallanID = value;
            }
        }

        public string ClientContact
        {
            get
            {
                return this.clientContact;
            }
            set
            {
                this.clientContact = value;
            }
        }

        public string DeliveryChallanNo
        {
            get
            {
                return this.deliveryChallanNo;
            }
            set
            {
                this.deliveryChallanNo = value;
            }
        }

        public string MrpNo
        {
            get
            {
                return this.mrpNo;
            }
            set
            {
                this.mrpNo = value;
            }
        }

        public string OwnContact
        {
            get
            {
                return this.ownContact;
            }
            set
            {
                this.ownContact = value;
            }
        }

        public string ProjectDetail
        {
            get
            {
                return this.projectDetail;
            }
            set
            {
                this.projectDetail = value;
            }
        }

        public string PurchaseOrderNo
        {
            get
            {
                return this.purchaseOrderNo;
            }
            set
            {
                this.purchaseOrderNo = value;
            }
        }

        public short UserIdInsert
        {
            get
            {
                return this.shUserIdInsert;
            }
            set
            {
                this.shUserIdInsert = value;
            }
        }

        public short UserIdUpdate
        {
            get
            {
                return this.shUserIdUpdate;
            }
            set
            {
                this.shUserIdUpdate = value;
            }
        }

        public SaleAdditionalMasterDAON()
        {
        }
    }
}

