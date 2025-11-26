using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ContructualProductionIsCheck
    {
        private bool is_item_checkt;

        public bool IS_item_checkt
        {
            get
            {
                return this.is_item_checkt;
            }
            set
            {
                this.is_item_checkt = value;
            }
        }

        public ContructualProductionIsCheck()
        {
        }
    }
}