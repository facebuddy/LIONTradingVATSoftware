using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class DadoMasterDAO
    {
        public DateTime ApplyDate
        {
            get;
            set;
        }

        public long DadoID
        {
            get;
            set;
        }

        public int OrganizationID
        {
            get;
            set;
        }

        public int OrgBranchID
        {
            get;
            set;
        }

        public int PriceDclarationID
        {
            get;
            set;
        }

        public string PriceDeclarationNo
        {
            get;
            set;
        }

        public int ProductID
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public long SaleChallanID
        {
            get;
            set;
        }

        public string SaleChallanNo
        {
            get;
            set;
        }

        public char TrnsType
        {
            get;
            set;
        }

        public int UnitID
        {
            get;
            set;
        }

        public string UnitName
        {
            get;
            set;
        }

        public int UserIDInsert
        {
            get;
            set;
        }

        public int UserIDUpdate
        {
            get;
            set;
        }

        public DadoMasterDAO()
        {
        }
    }
}