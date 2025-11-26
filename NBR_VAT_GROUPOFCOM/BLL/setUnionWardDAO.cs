using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class setUnionWardDAO
    {
        private short unionWardId;

        private string unionWardName;

        private short policeStationId;

        private short upazilaId;

        private bool isDeleted;

        private bool isUnion = true;

        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public bool IsUnion
        {
            get
            {
                return this.isUnion;
            }
            set
            {
                this.isUnion = value;
            }
        }

        public short PoliceStationId
        {
            get
            {
                return this.policeStationId;
            }
            set
            {
                this.policeStationId = value;
            }
        }

        public short UnionWardId
        {
            get
            {
                return this.unionWardId;
            }
            set
            {
                this.unionWardId = value;
            }
        }

        public string UnionWardName
        {
            get
            {
                return this.unionWardName;
            }
            set
            {
                this.unionWardName = value;
            }
        }

        public short UpazilaId
        {
            get
            {
                return this.upazilaId;
            }
            set
            {
                this.upazilaId = value;
            }
        }

        public setUnionWardDAO()
        {
        }
    }
}