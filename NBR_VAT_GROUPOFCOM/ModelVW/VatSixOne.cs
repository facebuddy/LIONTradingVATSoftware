using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class VatSixOne
    {
        public string product_name { get; set; }
        public int product_id { get; set; }
        public DateTime transaction_date { get; set; }
        public string supplier_name { get; set; }
        public string supplier_address { get; set; }
        public string supplier_vat_reg_no { get; set; }
        public DateTime purchase_date { get; set; }
        public string remarks { get; set; }
        public string reference_number { get; set; }
        public int quantity_purchase { get; set; }
        public double ctn_quantity_purchase { get; set; }
        public decimal purchase_netamount { get; set; }
        public decimal purchase_total_amount { get; set; }
        public decimal purchase_unit_price { get; set; }
        public double purchase_rebate_percent { get; set; }
        public decimal purchase_rebate_amount { get; set; }
        public string tracking_no { get; set; }
        public string invoice_no { get; set; }
        public DateTime sale_date { get; set; }
        public string product_name_biboron { get; set; }
        public string distributor_name { get; set; }
        public string distributor_address { get; set; }
        public int sale_quantity { get; set; }
        public string distributor_reg_number { get; set; }
        public decimal sale_amount { get; set; }
        public decimal net_amount_without_mushok { get; set; }
        public decimal vat_amount { get; set; }
        public int opening { get; set; }
        public int openingjer { get; set; }
        public int paromvikjer { get; set; }
        public int prantikjet { get; set; }
        public string montobbo { get; set; }
        public string Operationtype { get; set; }
    }
}