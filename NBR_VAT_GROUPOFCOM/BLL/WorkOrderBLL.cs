using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WorkOrderBLL
    {
        private DBUtility db = new DBUtility();

        public WorkOrderBLL()
        {
        }



        public DataTable GetPreodicStockReportData(DateTime fDate, DateTime tDate, long itemId, string branchIds, string productType)
        {
            int orgId = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string filterItem = string.Empty;
            DataTable dataTable = new DataTable();

            try
            {
                if (itemId != -99)
                {
                    filterItem = $" and item_id = {itemId}";
                }

                string query = $@"
 select item_id, product_type, weight, weight_unit_id, unit_codei,
        max(item_name) item,
        max(unit_id) unit_id,
        max(unit_code) unit,
        max(preQuantity) preQuantity,
        max(preQntAmount) preQntAmount,
        max(proq) proq,
        max(prot) prot,
        (max(pq) - max(dpq)) purqnt,
        (max(pt) - max(dpt)) puramount,
        (max(pv) - max(dpv)) purvat,
        (max(psd) - max(dpsd)) pursd,
        max(productionpq)  productionqnt,
        max(productionpt)  productionpuramount,
        max(productionpv)  productionpurvat,
        max(productionpsd) productionpursd,
        max(openpq) openpurqnt,
        max(openpt) openpuramount,
        max(openpv) openpurvat,
        max(opensd) openpursd,
        (max(sq) + max(trnsisuueq) + max(gq) - max(cpq)) salqnt,
        (max(st1) + max(st) + max(trnsissueprice) + max(gp) - max(cpt)) salamount,
        (max(sv1) + max(sv) + max(trnsissuevat) + max(gv) - max(cpv)) salvat,
        (max(ssd1) + max(ssd) + max(trnsissuesd) + max(gs) - max(cpsd)) salsd
from
(
    select item_id, item_name, unit_id, unit_code, product_type, weight, weight_unit_id, unit_codei,
    (
        -- Opening Qty (Purchase - Sale/Transfer/Gift + Credit Note)
        (
            select coalesce(sum(d.quantity), 0)
            from trns_purchase_detail d
            inner join trns_purchase_master m on d.challan_id = m.challan_id
            where CAST(m.date_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and d.item_id = mqmm.item_id
              and m.is_trns_accepted = true
              and challan_type not in ('D','Cr')
              and m.organization_id = {orgId}
              and m.org_branch_reg_id in({branchIds})
        )
        -
        (
            select coalesce(sum(d.quantity), 0)
            from trns_sale_detail d
            inner join trns_sale_master m on d.challan_id = m.challan_id
            where CAST(m.date_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and d.item_id = mqmm.item_id
              and d.installment_status = false
              and m.organization_id = {orgId}
              and m.org_branch_reg_id in({branchIds})
        )
        -
        (
            select coalesce(sum(tnd.quantity), 0)
            from trns_transfer_detail tnd
            inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
            where CAST(tnm.issues_date AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and tnd.item_id = mqmm.item_id
              and tnm.transfer_status = 'I'
              and tnm.organization_id = {orgId}
              and tnm.issuing_branch_id in({branchIds})
        )
        -
        (
            select coalesce(sum(gd.quantity), 0)
            from gift_items_detail gd
            where CAST(gd.date_consumable_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and gd.item_id = mqmm.item_id
              and gd.organization_id = {orgId}
              and gd.org_branch_id in({branchIds})
        )
        +
        (
            select coalesce(sum(tnd.quantity), 0)
            from trns_note_detail tnd
            inner join trns_note_master tnm on tnd.note_id = tnm.note_id
            where CAST(tnm.date_note AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and tnd.item_id = mqmm.item_id
              and tnd.status <> 'O'
              and tnm.note_type = 'C'
              and tnm.organization_id = {orgId}
              and tnm.org_branch_reg_id in({branchIds})
        )
    ) preQuantity,
    (
        -- Opening Amount (Purchase - Sale/Transfer/Gift + Credit Note)
        (
            select coalesce(sum(d.quantity * d.purchase_unit_price), 0)
            from trns_purchase_detail d
            inner join trns_purchase_master m on d.challan_id = m.challan_id
            where CAST(m.date_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and d.item_id = mqmm.item_id
              and m.is_trns_accepted = true
              and challan_type not in ('D','Cr')
              and m.organization_id = {orgId}
              and m.org_branch_reg_id in({branchIds})
        )
        -
        (
            select coalesce(sum(d.quantity * d.actual_price), 0)
            from trns_sale_detail d
            inner join trns_sale_master m on d.challan_id = m.challan_id
            where CAST(m.date_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and d.item_id = mqmm.item_id
              and d.installment_status = false
              and m.organization_id = {orgId}
              and m.org_branch_reg_id in({branchIds})
        )
        -
        (
            select coalesce(sum(tnd.quantity * tnd.unit_price), 0)
            from trns_transfer_detail tnd
            inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
            where CAST(tnm.issues_date AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and tnd.item_id = mqmm.item_id
              and tnm.transfer_status = 'I'
              and tnm.organization_id = {orgId}
              and tnm.issuing_branch_id in({branchIds})
        )
        -
        (
            select coalesce(sum(gd.price), 0)
            from gift_items_detail gd
            where CAST(gd.date_consumable_challan AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and gd.item_id = mqmm.item_id
              and gd.organization_id = {orgId}
              and gd.org_branch_id in({branchIds})
        )
        +
        (
            select coalesce(sum(tnd.quantity * tnd.actual_price), 0)
            from trns_note_detail tnd
            inner join trns_note_master tnm on tnd.note_id = tnm.note_id
            where CAST(tnm.date_note AS DATE) < to_date('{fDate:dd/MM/yyyy}','dd/MM/yyyy')
              and tnd.item_id = mqmm.item_id
              and tnd.status <> 'O'
              and tnm.note_type = 'C'
              and tnm.organization_id = {orgId}
              and tnm.org_branch_reg_id in({branchIds})
        )
    ) preQntAmount,
    (
        -- Production Qty in period
        select cast(coalesce(sum(d.quantity), 0) as decimal(18,2))
        from trns_production_detail d
        inner join trns_production_master m on d.production_id = m.production_id
        where d.item_id = mqmm.item_id
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy')
              >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy')
              <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.status = 'R'
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) proq,
    (
        -- Production Amount in period
        select cast(
            coalesce(
                sum(
                    d.quantity *
                    (
                        select coalesce(
                                   case
                                       when max(purchase_unit_price) = 0
                                           then max(total_price / quantity)
                                       else max(purchase_unit_price)
                                   end,
                                   0
                               )
                        from trns_purchase_detail
                        where item_id = mqmm.item_id
                          and quantity != 0
                    )
                ), 0
            ) as decimal(18,2)
        )
        from trns_production_detail d
        inner join trns_production_master m on d.production_id = m.production_id
        where d.item_id = mqmm.item_id
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy')
              >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy')
              <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.status = 'R'
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) prot,
    (
        select coalesce(sum(d.quantity), 0)
        from trns_purchase_detail d
        inner join trns_purchase_master m on d.challan_id = m.challan_id
        where m.is_trns_accepted = true
          and d.approver_stage = 'F'
          and d.item_id = mqmm.item_id
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
          and m.challan_type in ('P','D','O','T')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) pq,
    (
        select coalesce(sum(d.quantity * d.purchase_unit_price), 0)
        from trns_purchase_detail d
        inner join trns_purchase_master m on d.challan_id = m.challan_id
        where m.is_trns_accepted = true
          and d.approver_stage = 'F'
          and d.item_id = mqmm.item_id
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
          and m.challan_type in ('P','D','O','T')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) pt,
    (
        select coalesce(sum(d.purchase_vat), 0)
        from trns_purchase_detail d
        inner join trns_purchase_master m on d.challan_id = m.challan_id
        where m.is_trns_accepted = true
          and d.approver_stage = 'F'
          and d.item_id = mqmm.item_id
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
          and m.challan_type in ('P','D','O','T')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) pv,
    (
        select coalesce(sum(d.purchase_sd), 0)
        from trns_purchase_detail d
        inner join trns_purchase_master m on d.challan_id = m.challan_id
        where m.is_trns_accepted = true
          and d.approver_stage = 'F'
          and d.item_id = mqmm.item_id
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
          and m.challan_type in ('P','D','O','T')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) psd,
    (
        select coalesce(sum(tnd.quantity), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'C'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) cpq,
    (
        select coalesce(sum(tnd.quantity * tnd.actual_price), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'C'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) cpt,
    (
        select coalesce(sum(tnd.vat_amount), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'C'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) cpv,
    (
        select coalesce(sum(tnd.return_sd), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'C'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) cpsd,
    (
        select coalesce(sum(tnd.quantity), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'D'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) dpq,
    (
        select coalesce(sum(tnd.quantity * tnd.actual_price), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'D'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) dpt,
    (
        select coalesce(sum(tnd.vat_amount), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'D'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) dpv,
    (
        select coalesce(sum(tnd.return_sd), 0)
        from trns_note_detail tnd
        inner join trns_note_master tnm on tnd.note_id = tnm.note_id
        where tnd.item_id = mqmm.item_id
          and tnm.note_type = 'D'
          and tnd.status <> 'O'
          and tnm.organization_id = {orgId}
          and tnm.org_branch_reg_id in({branchIds})
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
    ) dpsd,
    (
        select cast(coalesce(sum(d.quantity), 0) as decimal(18,2))
        from trns_production_detail d
        inner join trns_production_master m on d.production_id = m.production_id
        where d.item_id = mqmm.item_id
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.status = 'R'
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) productionpq,
    (
        select cast(
            coalesce(
                sum(
                    d.quantity *
                    (
                        select coalesce(
                                   case
                                       when max(purchase_unit_price) = 0
                                           then max(total_price / quantity)
                                       else max(purchase_unit_price)
                                   end,
                                   0
                               )
                        from trns_purchase_detail
                        where item_id = mqmm.item_id
                          and quantity != 0
                    )
                ), 0
            ) as decimal(18,2)
        )
        from trns_production_detail d
        inner join trns_production_master m on d.production_id = m.production_id
        where d.item_id = mqmm.item_id
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.status = 'R'
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) productionpt,
    0 productionpv, 0 productionpsd,
    0 openpq, 0 openpt, 0 openpv, 0 opensd,
    (
        select coalesce(sum(d.quantity), 0)
        from trns_sale_detail d
        inner join trns_sale_master m on d.challan_id = m.challan_id
        where to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.item_id = mqmm.item_id
          and d.installment_status = false
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) sq,
    (
        select coalesce(sum(d.quantity * d.actual_price), 0)
        from trns_sale_detail d
        inner join trns_sale_master m on d.challan_id = m.challan_id
        where to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.item_id = mqmm.item_id
          and d.installment_status = false
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) st,
    (
        select coalesce(sum(d.vat), 0)
        from trns_sale_detail d
        inner join trns_sale_master m on d.challan_id = m.challan_id
        where to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.item_id = mqmm.item_id
          and d.installment_status = false
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) sv,
    (
        select coalesce(sum(d.sd), 0)
        from trns_sale_detail d
        inner join trns_sale_master m on d.challan_id = m.challan_id
        where to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and d.item_id = mqmm.item_id
          and d.installment_status = false
          and m.organization_id = {orgId}
          and m.org_branch_reg_id in({branchIds})
    ) ssd,
    (
        select coalesce(sum(tnd.quantity), 0)
        from trns_transfer_detail tnd
        inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
        where cast(tnm.issues_date as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(tnm.issues_date as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and tnd.item_id = mqmm.item_id
          and tnm.transfer_status = 'I'
          and tnm.organization_id = {orgId}
          and tnm.issuing_branch_id in({branchIds})
    ) trnsisuueq,
    (
        select coalesce(sum(tnd.quantity * tnd.unit_price), 0)
        from trns_transfer_detail tnd
        inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
        where cast(tnm.issues_date as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(tnm.issues_date as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and tnd.item_id = mqmm.item_id
          and tnm.transfer_status = 'I'
          and tnm.organization_id = {orgId}
          and tnm.issuing_branch_id in({branchIds})
    ) trnsissueprice,
    (
        select coalesce(sum(tnd.vat_amount), 0)
        from trns_transfer_detail tnd
        inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
        where cast(tnm.issues_date as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(tnm.issues_date as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and tnd.item_id = mqmm.item_id
          and tnm.transfer_status = 'I'
          and tnm.organization_id = {orgId}
          and tnm.issuing_branch_id in({branchIds})
    ) trnsissuevat,
    (
        select coalesce(sum(tnd.sd_amount), 0)
        from trns_transfer_detail tnd
        inner join trns_transfer_master tnm on tnd.transfer_id = tnm.transfer_id
        where cast(tnm.issues_date as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(tnm.issues_date as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and tnd.item_id = mqmm.item_id
          and tnm.transfer_status = 'I'
          and tnm.organization_id = {orgId}
          and tnm.issuing_branch_id in({branchIds})
    ) trnsissuesd,
    0 sq1, 0 st1, 0 sv1, 0 ssd1,
    (
        select coalesce(sum(gd.quantity), 0)
        from gift_items_detail gd
        where cast(gd.date_consumable_challan as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(gd.date_consumable_challan as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and gd.item_id = mqmm.item_id
          and gd.organization_id = {orgId}
          and gd.org_branch_id in({branchIds})
    ) gq,
    (
        select coalesce(sum(gd.price), 0)
        from gift_items_detail gd
        where cast(gd.date_consumable_challan as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(gd.date_consumable_challan as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and gd.item_id = mqmm.item_id
          and gd.organization_id = {orgId}
          and gd.org_branch_id in({branchIds})
    ) gp,
    (
        select coalesce(sum(gd.discounted_vat), 0)
        from gift_items_detail gd
        where cast(gd.date_consumable_challan as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(gd.date_consumable_challan as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and gd.item_id = mqmm.item_id
          and gd.organization_id = {orgId}
          and gd.org_branch_id in({branchIds})
    ) gv,
    (
        select coalesce(sum(gd.discounted_sd), 0)
        from gift_items_detail gd
        where cast(gd.date_consumable_challan as date) >= to_date('{fDate:MM/dd/yyyy}','MM/dd/yyyy')
          and cast(gd.date_consumable_challan as date) <= to_date('{tDate:MM/dd/yyyy}','MM/dd/yyyy')
          and gd.item_id = mqmm.item_id
          and gd.organization_id = {orgId}
          and gd.org_branch_id in({branchIds})
    ) gs
    from
    (
        select tpd.item_id,
               i.item_name,
               tpd.unit_id,
               iu.unit_code,
               i.product_type,
               i.weight,
               i.weight_unit_id,
               iuu.unit_code unit_codei
        from trns_purchase_master tpm
        inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id
        inner join item i on tpd.item_id = i.item_id
        left join item_unit iu  on tpd.unit_id      = iu.unit_id
        left join item_unit iuu on i.weight_unit_id = iuu.unit_id
        where tpm.organization_id = {orgId}
          and tpm.org_branch_reg_id in({branchIds})
          and tpm.is_deleted = false
          and tpm.is_trns_accepted = true

        UNION

        select tsd.item_id,
               i.item_name,
               tsd.unit_id,
               iu.unit_code,
               i.product_type,
               i.weight,
               i.weight_unit_id,
               iuu.unit_code
        from trns_sale_master tsm
        inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id
        left join item i       on tsd.item_id = i.item_id
        left join item_unit iu on tsd.unit_id = iu.unit_id
        left join item_unit iuu on i.weight_unit_id = iuu.unit_id
        where tsm.is_deleted = false
          and tsm.organization_id = {orgId}
          and tsm.org_branch_reg_id in({branchIds})
    ) mqmm
) mqmm2
where product_type = '{productType}'
      {filterItem}
group by item_id, product_type, weight, unit_codei, weight_unit_id
order by item_id;";

                dataTable = db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dataTable;
        }

        public DataTable GetProductionInformationByItemId(DateTime fDate, DateTime tDate, long Item_id, string branchIds)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { " select d.item_id,i.item_name,d.quantity,0 purchase_vat,0 purchase_sd, to_char(m.date_production,'dd-MON-yyyy') date_production,m.date_production dtc,\r\n\r\n\r\ncast(coalesce((d.quantity * (select coalesce(case when d.unit_price!=0 then d.unit_price/d.quantity  when max(purchase_unit_price)=0 then (max(total_price/quantity)) else max(purchase_unit_price) end,0)  from trns_purchase_detail where item_id = ", Item_id, " and quantity!=0)),0) as decimal(18,2)) price,\r\n'Received' remarks,d.unit_price\r\n\t\t                from trns_production_detail d\r\n                                inner join trns_production_master m on d.production_id = m.production_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                      where cast (m.Date_Production as Date) >= TO_DATE('", fDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.Date_Production as Date) <= TO_DATE('", tDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                       AND d.item_id =  ", Item_id, "  AND d.Is_deleted = false AND d.status = 'R' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ") order by m.Date_Production" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetTaxRateByItemId(long Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] itemId = new object[] { " select hs_code,item_id, item_name,unit_code,date_effective,max(Cd)Cd,max(Rd)Rd,max(Sd)Sd, max(Vat)Vat,max(Ait)Ait,max(Atv)Atv,max(Tti)Tti,max(AT_)AT_,sum(trade_price)trade_price,trns_type  \r\n            from (\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,itv.tax_value CD,0 RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='1'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n            union all\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,0 CD,itv.tax_value RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='2'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n            union all\r\n\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,0 CD,0 RD,itv.tax_value Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='3'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n            union all\r\n\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,0 CD,0 RD,0 Sd,itv.tax_value Vat,0 Ait, 0 Atv,0 Tti,0 AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='4'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n            union all\r\n\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,0 CD,0 RD,0 Sd,0 Vat,itv.tax_value Ait, 0 Atv,0 Tti,0 AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='5'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n            union all\r\n\r\n            select i.hs_code,i.item_id,i.item_name,iu.unit_code,itv.date_effective,0 CD,0 RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,itv.tax_value AT_,0 as trade_price,case when itv.is_tran_sale=true then 'Sale' end  trns_type\r\n            from Item i left outer join\r\n            item_unit iu on i.unit_id=iu.unit_id left outer join\r\n            item_tax_values itv on i.Item_id=itv.Item_id and itv.tax_id='8'\r\n            where i.Is_deleted=false and i.item_id=", Item_id, "  AND itv.is_current  = true AND itv.is_tran_sale=true\r\n\r\n           \r\n            ) item_tax group by hs_code,item_name, unit_code,item_id,date_effective,trns_type" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }


        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, string GRN, string Voucher)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", purchaseDetailDAO.ItemID, "' ");
                str5 = string.Concat(str5, " ) ");
                if (purchaseDetailDAO.PriceId > 0)
                {
                    purchaseDetailDAO.PriceId.ToString();
                }
                purchaseDetailDAO.DetailID = Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(Challan_id, row_no, Item_id, property_id1, property_id2, property_id3,property_id4, property_id5,\r\n                                            unit_id, Quantity, User_id_insert, lot_no, detail_id,total_price,purchase_unit_price, purchase_vat,discount_amount,difference)\r\n                                VALUES (", ChallanID, ", ", purchaseDetailDAO.RowNo, ", ", purchaseDetailDAO.ItemID, ",  ", str, ", ", str1, ", \r\n                                          ", str2, ", ", str3, ", ", str4, ",\r\n                                          ", purchaseDetailDAO.UnitID, ", ", purchaseDetailDAO.Quantity, ", ", purchaseDetailDAO.UserIdInsert, ", \r\n                                          ", str5, ", ", purchaseDetailDAO.DetailID, ", ", purchaseDetailDAO.TotalPrice, ",\r\n                                          ", purchaseDetailDAO.PurchaseUnitPrice, ", ", purchaseDetailDAO.PurchaseVAT, ",", purchaseDetailDAO.Discount, ",'", purchaseDetailDAO.Difference, "')" };
                arrDetailList.Add(string.Concat(challanID));
            }
            if (GRN != "-1")
            {
                empty = string.Concat(empty, "  and grn_no = '", GRN, "'");
            }
            if (Voucher != "-1")
            {
                empty = string.Concat(empty, "  and vouchar_no = '", Voucher, "'");
            }
            arrDetailList.Add(string.Concat("update trns_vendor_master set status = true where is_deleted = false ", empty, " "));
            return arrDetailList;
        }

        public decimal AdjustTransferredPreodicStockReportData(DateTime fDate, DateTime tDate, int itemId, decimal stockQnt)
        {
            decimal num = stockQnt;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            int num3 = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            int num4 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select ttd.quantity from trns_transfer_detail ttd\r\n                            inner join trns_transfer_master ttm  on ttd.transfer_id = ttm.transfer_id\r\n                            where ttd.item_id = ", itemId, " and ttm.organization_id = ", num3, " and ttm.issuing_branch_id = ", num4, " and to_date(to_char(ttm.issues_date, 'MM/dd/yyyy'), 'MM/dd/yyyy') > to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                      and to_date(to_char(ttm.issues_date, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
            string str = string.Concat(objArray);
            object[] objArray1 = new object[] { "select ttd.quantity from trns_transfer_detail ttd\r\n                            inner join trns_transfer_master ttm  on ttd.transfer_id=ttm.transfer_id\r\n                            where ttd.item_id=", itemId, " and ttm.organization_id=", num3, " and ttm.receiving_branch_id=", num4, " and to_date(to_char(ttm.issues_date,'MM/dd/yyyy'),'MM/dd/yyyy') > to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                      and to_date(to_char(ttm.issues_date,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
            string str1 = string.Concat(objArray1);
            DataTable dataTable = this.db.GetDataTable(str);
            DataTable dataTable1 = this.db.GetDataTable(str1);
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                num1 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
                num -= num1;
            }
            if (dataTable1.Rows.Count > 0 && dataTable1 != null)
            {
                num2 = Convert.ToDecimal(dataTable1.Rows[0]["quantity"]);
                num += num2;
            }
            return num;
        }

        public bool DeleteTemplate(int tempID)
        {
            bool flag = false;
            try
            {
                string str = string.Concat("update price_item set is_deleted = true where price_id = ", tempID);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw;
            }
            return flag;
        }

        public DataTable GetAllCategoryforDLL()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select distinct ic.category_id, ic.category_name \r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id  \r\n                            where ic.parent_id = 0 and i.product_type = 'R'");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllDataByVoucher(string GRN, string Voucher)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (GRN != "-1")
                {
                    empty = string.Concat(empty, " and tvm.grn_no = '", GRN, "' ");
                }
                if (Voucher != "-1")
                {
                    empty = string.Concat(empty, " and tvm.vouchar_no = '", Voucher, "' ");
                }
                string str = string.Concat(" select tvd.item_id, i.item_name,tvd.unit_id, iu.unit_code,tvd.quantity,tvd.unit_price,tvd.discount,tvd.tax, 0 current_rate,tvd.total_amount, 0 Difference\r\n                             from trns_vendor_master tvm\r\n                             inner join trns_vendor_details tvd on tvm.work_order_id = tvd.work_order_id\r\n                             inner join item i on tvd.item_id = i.item_id\r\n                             inner join item_unit iu on tvd.unit_id = iu.unit_id\r\n                             where tvm.is_deleted = false \r\n                                   and tvm.status = false ", empty);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllGoodsByTemplateNo(int TID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pri.item_id, i.item_name, pri.unit_id, iu.unit_name,iu.unit_code,pri.quantity, pri.unit_price,pri.discount_price, pri.tax \r\n                                from price_item pi\r\n                                inner join price_raw_item pri on pi.price_id = pri.price_id\r\n                                inner join item i on pri.item_id = i.item_id\r\n                                inner join item_unit iu on pri.unit_id = iu.unit_id\r\n                                where pi.price_id = ", TID, " order by pri.row_no");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllPurchaseDataForList(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select tpm.challan_id as ChallanNo, to_char(date_challan,'dd-MON-yyyy') BillDate,subject as Subject,contails_challan_no as Contails,'Due' BillsReceived, \r\n                            sum(tpd.quantity*tpd.purchase_unit_price) as Amount\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                            where tpm.date_challan >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy')\r\n                            and tpm.date_challan <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy') \r\n                            group by tpm.challan_id,date_challan,subject,contails_challan_no" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllPurItemCategory(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select distinct ic.category_name,ic.category_id\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item i on tpd.item_id = i.item_id\r\n                            inner join item_category isc on i.sub_category_id = isc.category_id\r\n                            inner join item_category ic on isc.parent_id = ic.category_id\r\n                            where --ic.category_id = 0 and\r\n                            tpm.date_challan >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy')\r\n                            and tpm.date_challan <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy') \r\n                            order by ic.category_id" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllRawItem()
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                dataTable = this.db.GetDataTable("select item_id, item_name from item where product_type = 'R' and is_deleted = false ");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllRawItemforDLL()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select item_id, item_name from item where is_deleted = false and product_type = 'R' order by item_name");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllSubCategoryforDLL()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select distinct isc.category_id sub_category_id, isc.category_name sub_category_name\r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id\r\n                            where i.product_type = 'R'");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllTemplateforGrid()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select price_id template_id, price_declaration_no TemplateNo ,to_char(date_effective,'dd-MON-yyyy') EffectiveDate, \r\n                            price_declaration_year TemplateYear\r\n                            from price_item \r\n                            where is_deleted = false and item_id is null and unit_id is null");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllTemplateNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select price_id template_id, price_declaration_no template_no from price_item \r\n                            where is_deleted = false and item_id is null and unit_id is null --and date_effective >= now()");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllUnit()
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                dataTable = this.db.GetDataTable("select unit_id, unit_name,unit_code from item_unit where is_deleted = false ");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllVendor()
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                dataTable = this.db.GetDataTable("select party_id, party_name from trns_party where is_deleted = false ");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public decimal getAvailStock(int ItemID, DateTime toDay)
        {
            decimal num = new decimal(0);
            object[] objArray = new object[] { " SELECT coalesce((\r\n      ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDay, "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDay, "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n-\r\n( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDay, "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND D.STATUS IN ('I','S')))\r\n   -\r\n    ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDay, "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDay, "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n\r\n    ),0) availStock  " };
            string str = string.Concat(objArray);
            object singleValue = this.db.GetSingleValue(str);
            if (singleValue != null)
            {
                num = Convert.ToDecimal(singleValue);
            }
            return num;
        }

        public DataTable GetCategoryWisePurchasePeriodicData(DateTime fDate, DateTime tDate, string purchase_type)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                if (purchase_type != "A")
                {
                    str = string.Concat("and tpm.purchase_type = '", purchase_type, "'");
                }
                string[] strArrays = new string[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') Date,tpd.quantity, tpm.challan_no, \r\n                            sum(tpd.quantity*tpd.purchase_unit_price) Amount, tpm.subject,'Due' BillsReceived,isc.category_name,i.item_name\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item i on tpd.item_id = i.item_id\r\n                            inner join item_category isc on i.sub_category_id = isc.category_id\r\n                            inner join item_category ic on isc.parent_id = ic.category_id\r\n                            where tpm.date_challan >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            and tpm.date_challan <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')", str, "\r\n                            group by tpd.quantity,isc.category_name,i.item_name,tpm.date_challan,tpm.challan_no,tpm.subject order by tpm.date_challan" };
                string str1 = string.Concat(strArrays);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetCategoryWisePurchasePeriodicDataByCategoryID(int catID, DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') Date, tpm.contails_challan_no, sum(tpd.quantity*tpd.purchase_unit_price) Amount, tpm.subject\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item i on tpd.item_id = i.item_id\r\n                            inner join item_category isc on i.sub_category_id = isc.category_id\r\n                            inner join item_category ic on isc.parent_id = ic.category_id\r\n                            where ic.category_id = ", catID, " \r\n                            and tpm.date_challan >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy')\r\n                            and tpm.date_challan <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy')\r\n                            group by tpm.date_challan,tpm.contails_challan_no,tpm.subject order by tpm.date_challan" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetCategoryWisePurchasePeriodicDataByCategoryID2(int catID, DateTime fDate, DateTime tDate, string purchase_type)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                if (purchase_type != "A")
                {
                    str = string.Concat("and tpm.purchase_type = '", purchase_type, "'");
                }
                object[] objArray = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') Date, tpm.challan_no,tpd.quantity, \r\n                            sum(tpd.quantity*tpd.purchase_unit_price) Amount, tpm.subject,'Due' BillsReceived,isc.category_name,i.item_name\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item i on tpd.item_id = i.item_id\r\n                            inner join item_category isc on i.sub_category_id = isc.category_id\r\n                            inner join item_category ic on isc.parent_id = ic.category_id\r\n                            where ic.category_id = ", catID, " \r\n                            and tpm.date_challan >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            and tpm.date_challan <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, " and tpd.approver_stage='F'\r\n                           \r\n                            group by tpd.quantity,isc.category_name,i.item_name,tpm.date_challan,tpm.challan_no,tpm.subject order by tpm.date_challan" };
                string str1 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        private ArrayList getCPDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                WOGoodsDAO wOGoodsDAO = new WOGoodsDAO();
                wOGoodsDAO = (WOGoodsDAO)arrDeailDAO[i];
                object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, user_id_insert,status)\r\n                                VALUES (", productionID, ", ", wOGoodsDAO.RowNo, ", ", wOGoodsDAO.ItemID, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", wOGoodsDAO.UnitID, ", ", wOGoodsDAO.Quantity, ", ", wOGoodsDAO.UserID, ",'I')" };
                arrDetailList.Add(string.Concat(objArray));
            }
            return arrDetailList;
        }

        public DataTable GetFinishProductProductionInformationByItemId(DateTime fDate, DateTime tDate, long Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] itemId = new object[] { "select tpd.item_id,i.item_name,tpd.quantity,(tpd.quantity*tpd.purchase_unit_price) price, to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpm.date_challan dtc,\r\n                       purchase_vat,purchase_sd,                     \r\n                       'Received' remarks \r\n                       from trns_purchase_master tpm\r\n                       inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                       inner join item i on tpd.item_id = i.item_id\r\n                       where i.item_id=", Item_id, "  and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.quantity !=0 and tpm.challan_type='C' order by dtc" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetGoodReceipentNoteDetails(int ID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] d = new object[] { "select i.item_name,tvd.quantity, iu.unit_code,tvd.unit_price,tvd.discount,tvd.tax,tvd.total_amount amount,\r\n                            (select sum(total_amount) from trns_vendor_details where work_order_id = ", ID, ") total_amount,\r\n                            (select sum(discount) from trns_vendor_details where work_order_id = ", ID, ") total_discount,\r\n                            (select sum(tax) from trns_vendor_details where work_order_id = ", ID, ") total_tax\r\n                            from trns_vendor_details tvd\r\n                            inner join item i on tvd.item_id = i.item_id\r\n                            inner join item_unit iu on tvd.unit_id = iu.unit_id\r\n                            where tvd.work_order_id = ", ID };
                string str = string.Concat(d);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetGoodReceipentNoteMaster(string VoucherNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select  tvm.work_order_id,tvm.grn_no,tvm.reg_no,tvm.purchase_order,tvm.receiving_store,tvm.vouchar_no,to_char(tvm.order_date,'dd-MON-yyyy') date,\r\n\t                            ae.employee_name, tp.party_name,to_char(current_date,'dd-MON-yyyy HH:mm:ss') pdate\r\n                            from trns_vendor_master tvm\r\n                            inner join admn_employee ae on tvm.user_id_insert = ae.employee_id\r\n                            inner join trns_party tp on tvm.vendor_id = tp.party_id\r\n                            where vouchar_no = '", VoucherNo, "' and tvm.status = false");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetGoodReceipentNoteMaster2(string VoucherNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select  tvm.work_order_id,tvm.grn_no,tvm.reg_no,tvm.purchase_order,tvm.receiving_store,tvm.vouchar_no,to_char(tvm.order_date,'dd-MON-yyyy') date,\r\n\t                            ae.employee_name, tp.party_name,to_char(current_date,'dd-MON-yyyy HH:mm:ss') pdate\r\n                            from trns_vendor_master tvm\r\n                            inner join admn_employee ae on tvm.user_id_insert = ae.employee_id\r\n                            inner join trns_party tp on tvm.vendor_id = tp.party_id\r\n                            where vouchar_no = '", VoucherNo, "' and to_char(order_date,'MM/dd/yyyy') = to_char(current_date,'MM/dd/yyyy')");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetGRNNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select grn_no from trns_vendor_master where is_deleted = false and status = false");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetGRNNoByVoucherNo(string VoucherNO)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select grn_no from trns_vendor_master where vouchar_no = '", VoucherNO, "' and is_deleted = false and status = false");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetItemsByItemID(int IID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id,i.item_name,i.hs_code,iu.unit_id, iu.unit_name\r\n                            from Item i\r\n                            inner join item_unit iu on i.unit_id = iu.unit_id\r\n                            where i.item_id = ", IID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPreodicStockReportData(DateTime fDate, DateTime tDate, int itemId, string productType)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            string empty = string.Empty;
            string str = "";
            DataTable dataTable = new DataTable();
            try
            {
                if (itemId != -99)
                {
                    str = string.Concat("and item_id = ", itemId);
                }
                object[] objArray = new object[] { "\r\n                     \r\n                         select item_id,product_type,weight,weight_unit_id,unit_codei,max(item_name) item,max(unit_id) unit_id, max(unit_code) unit, \r\n                     max(preQuantity) preQuantity,max(preQntAmount) preQntAmount,max(proq) proq, max(prot) prot,\r\n\t                (max(pq)-max(dpq)) purqnt, (max(pt)-max(dpt)) puramount,(max(pv)-max(dpv)) purvat,(max(psd)-max(dpsd)) pursd,           \r\n                   max(productionpq) productionqnt,max(productionpt) productionpuramount,max(productionpv) productionpurvat,max(productionpsd) productionpursd,\r\n                   max(openpq) openpurqnt,max(openpt) openpuramount,max(openpv) openpurvat,max(opensd) openpursd,\r\n\t               (max(sq)+max(trnsisuueq)+max(gq)-max(cpq)) salqnt, (max(st1)+max(st)+max(trnsissueprice)+max(gp)-max(cpt)) salamount, (max(sv1)+max(sv)+max(trnsissuevat)+max(gv)-max(cpv)) salvat, (max(ssd1)+max(ssd)+max(trnsissuesd)+max(gs)-max(cpsd)) salsd\r\n                from\r\n                (\r\n\r\n                select item_id, item_name,unit_id,unit_code ,product_type,weight,weight_unit_id,unit_codei,\r\n               (\r\n\t\t           --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_purchase_detail as d inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id =mqmm.item_id  and M.is_trns_accepted=true  and challan_type not in ('D','Cr','T') AND m.organization_id= ", num, "   and d.approver_stage='F'AND m.org_branch_reg_id = ", num1, ")\r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_sale_detail as d inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                     where CAST(m.date_challan AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = mqmm.item_id  and d.approver_stage='F' AND  m.organization_id= ", num, "   AND m.org_branch_reg_id = ", num1, ")     \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t             select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t             where CAST(m.date_note AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=mqmm.item_id  AND  m.organization_id= ", num, "  AND m.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n                    --Transfer Issue\r\n                    (\r\n\t\t            select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t            where CAST(m.issues_date AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=mqmm.item_id  AND m.organization_id= ", num, " AND  m.issuing_branch_id= ", num1, "\r\n                    )+\r\n                     (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_production_detail as d inner join trns_production_master as m on d.production_id = m.production_id\r\n                    where  CAST(m.date_production AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = mqmm.item_id  AND m.organization_id= ", num, "  and m.trns_status='R'   AND m.org_branch_reg_id = ", num1, ")\r\n\r\n\r\n                     --gift\r\n                    +\r\n                     (select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where  CAST(gd.date_consumable_challan  AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and gd.item_id= mqmm.item_id  AND organization_id=", num, "  AND \r\n                     org_branch_id=", num1, " AND gd.is_deleted=false)\r\n\r\n                     )\r\n                    +\r\n                    --credit\r\n                    (\r\n\t                select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t            where CAST(m.date_note AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=mqmm.item_id  AND m.organization_id= ", num, "  AND m.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n\t\t            --Transfer Receive\r\n\t\t            (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t             where CAST(m.issues_date AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'R' AND d.item_id=mqmm.item_id  AND m.organization_id= ", num, "  AND m.receiving_branch_id = ", num1, ")                        \r\n                    ) preQuantity,\r\n               (\r\n\t\t           --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.purchase_unit_price) end from trns_purchase_detail as d inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and M.is_trns_accepted=true  AND d.item_id =mqmm.item_id and challan_type not in ('D','Cr','T')  and d.approver_stage='F' AND m.organization_id= ", num, "  AND m.org_branch_reg_id = ", num1, ")\r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end from trns_sale_detail as d inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                     where CAST(m.date_challan AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = mqmm.item_id AND  m.organization_id= ", num, "  and d.approver_stage='F'  AND m.org_branch_reg_id = ", num1, ")     \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t             select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t             where CAST(m.date_note AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=mqmm.item_id AND  m.organization_id= ", num, "  AND m.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n                    --Transfer Issue\r\n                    (\r\n\t\t            select case when sum(d.quantity) is null then 0 else 0 end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t            where CAST(m.issues_date AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=mqmm.item_id AND m.organization_id= ", num, "   AND m.issuing_branch_id = ", num1, "\r\n                    )\r\n                     +\r\n                   \r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity*(select purchase_unit_price from trns_purchase_detail pd where pd.item_id=mqmm.item_id limit 1)) end from trns_production_detail as d inner join trns_production_master as m on d.production_id = m.production_id\r\n                    where  CAST(m.date_production AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id =mqmm.item_id AND m.organization_id= ", num, "  and m.trns_status='R'   AND m.org_branch_reg_id = ", num1, ")\r\n                   \r\n\r\n                     --gift\r\n                    +\r\n                     (select coalesce(sum(gd.price),0) from gift_items_detail gd  where CAST(gd.date_consumable_challan  AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and gd.item_id= mqmm.item_id  AND organization_id=", num, "  AND \r\n                     org_branch_id=", num1, " AND gd.is_deleted=false)\r\n                     ) \r\n                    +\r\n                    --credit\r\n                    (\r\n\t                select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t            where CAST(m.date_note AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=mqmm.item_id AND m.organization_id= ", num, "  AND m.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n\t\t            --Transfer Receive\r\n\t\t            (select case when sum(d.quantity) is null then 0 else 0 end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t             where CAST(m.issues_date AS DATE) < to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'R' AND d.item_id=mqmm.item_id AND m.organization_id= ", num, "   AND m.receiving_branch_id = ", num1, ")                        \r\n                    )  preQntAmount,\r\n               \r\n                (\r\n                select cast(coalesce(sum(d.quantity),0) as decimal(18,2)) \r\n\t\t        from trns_production_detail d\r\n                inner join trns_production_master m on d.production_id = m.production_id\r\n                where d.item_id = mqmm.item_id \r\n                and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n\t\t\t\tand to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and d.status='R'  AND m.organization_id= ", num, " AND m.org_branch_reg_id = ", num1, "\r\n                               \r\n                ) proq,\r\n                (\r\n                select cast(coalesce(sum((d.quantity * (select coalesce(case when max(purchase_unit_price)=0 then (max(total_price/quantity)) else max(purchase_unit_price) end,0)  from trns_purchase_detail where item_id = mqmm.item_id and quantity!=0))),0) as decimal(18,2)) \r\n\t\t        from trns_production_detail d\r\n                inner join trns_production_master m on d.production_id = m.production_id\r\n                where d.item_id = mqmm.item_id \r\n                and to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n\t\t\t\tand to_date(to_char(m.date_production,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and d.status='R'  AND m.organization_id= ", num, " AND m.org_branch_reg_id = ", num1, "\r\n                               \r\n                ) prot,\r\n                0 pq, 0 pt, 0 pv, 0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,  0 productionpv, 0 productionpsd,\r\n                0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd  ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from\r\n                (\r\n                select tpd.item_id, i.item_name, tpd.unit_id, iu.unit_code,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code unit_codei\r\n                from trns_purchase_master tpm\r\n                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                left join item_unit iu on tpd.unit_id = iu.unit_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, "  and tpd.approver_stage='F' and tpm.is_deleted = false  and tpm.is_trns_accepted=true\r\n                UNION  \r\n\r\n                select tsd.item_id, i.item_name item_name, tsd.unit_id unit_id, iu.unit_code unit_code,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code--, 0 prequantity, 0 preqntamount,0 pq,0 pt,0 pv,0 psd\r\n                from trns_sale_master tsm\r\n                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                left join item i on tsd.item_id = i.item_id\r\n                left join item_unit iu on tsd.unit_id = iu.unit_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where tsm.is_deleted=false  and tsd.approver_stage='F' and tsm.organization_id = ", num, " AND tsm.org_branch_reg_id = ", num1, " )mqmm\r\n\r\n                UNION ALL\r\n\r\n                select tpd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id, iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot, sum(tpd.quantity) pq,sum(tpd.quantity*tpd.purchase_unit_price) pt,\r\n                 sum(purchase_vat) pv,sum(purchase_sd) psd, 0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,\r\n                 0 productionpv, 0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd  ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_purchase_master tpm\r\n                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')   and tpd.approver_stage='F' and tpm.is_trns_accepted=true and tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, " and tpm.challan_type in ('P','T')\r\n                group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n                UNION ALL\r\n\r\n                  select tpd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code, 0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq, 0 pt, 0 pv,0 psd, sum(tpd.quantity) cpq,sum(tpd.quantity*tpd.purchase_unit_price) cpt,\r\n                  sum(purchase_vat) cpv,sum(purchase_sd) cpsd, 0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,\r\n                  0 productionpv, 0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd ,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                  from trns_purchase_master tpm\r\n                  inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                  inner join item i on tpd.item_id = i.item_id\r\n                  left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                  where to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                  and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and tpd.approver_stage='F' and tpm.is_trns_accepted=true and tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, "  and tpm.challan_type='Cr'\r\n                  group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n UNION ALL\r\n\r\n                select tpd.item_id, i.item_name, 0 unit_id, '' unit_code ,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq, 0 pt, 0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd, sum(tpd.quantity) dpq,sum(tpd.quantity*tpd.purchase_unit_price) dpt,\r\n                sum(purchase_vat) dpv,sum(purchase_sd) dpsd, 0 productionpq,0 productionpt,\r\n                0 productionpv, 0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd ,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_purchase_master tpm\r\n                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and tpd.approver_stage='F' and tpm.is_trns_accepted=true and tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, "  and tpm.challan_type='D'\r\n                group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n UNION ALL\r\n                select tpd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id, iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd, sum(tpd.quantity) productionpq,sum(tpd.quantity*tpd.purchase_unit_price) productionpt,\r\n                       sum(purchase_vat) productionpv,sum(purchase_sd) productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd  ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_purchase_master tpm\r\n                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n               left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                      and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.approver_stage='F' and tpm.is_trns_accepted=true and tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, "  and tpm.challan_type='C'\r\n                group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n             UNION ALL\r\n               select tpd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id, iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,\r\n                 0 productionpv, 0 productionpsd,sum(tpd.quantity) openpq,sum(tpd.total_price) openpt,\r\n                       sum(purchase_vat) openpv,sum(purchase_sd) opensd, 0 sq, 0 st, 0 sv, 0 ssd  ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_purchase_master tpm\r\n                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                      and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and tpd.approver_stage='F' and tpm.is_trns_accepted=true and tpm.organization_id = ", num, " AND tpm.org_branch_reg_id = ", num1, "   and tpm.challan_type='O'\r\n                group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n                UNION ALL\r\n\r\n                select tsd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code, 0 prequantity, 0 preqntamount,0 proq, 0 prot, 0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,\r\n                 0 productionpv, 0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,\r\n                  coalesce(sum(tsd.quantity),0)  sq, coalesce(sum(tsd.quantity*tsd.actual_price),0) st, sum(tsd.vat) sv, sum(tsd.sd) ssd  ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_sale_master tsm\r\n                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                left join item i on tsd.item_id = i.item_id\r\n                left join item_unit iu on tsd.unit_id = iu.unit_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tsm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                and to_date(to_char(tsm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                and installment_status=false \r\n                and tsm.organization_id = ", num, " AND tsm.org_branch_reg_id = ", num1, "  and tsd.approver_stage='F'\r\n                group by i.item_name,tsd.item_id,i.item_name,tsd.unit_id,iu.unit_code,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n                UNION ALL\r\n\r\n                select tsd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id,iuu.unit_code, 0 prequantity, 0 preqntamount,0 proq, 0 prot, 0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,0 productionpq,0 productionpt,\r\n                 0 productionpv, 0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,\r\n                 0 sq, 0 st, 0 sv, 0 ssd ,0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,0 trnsissuesd,coalesce(sum(tsd.quantity),0)  sq1, coalesce(sum(tsd.quantity*tsd.actual_price),0) st1, sum(tsd.vat) sv1, sum(tsd.sd) ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_sale_master tsm\r\n                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                left join item i on tsd.item_id = i.item_id\r\n                left join item_unit iu on tsd.unit_id = iu.unit_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tsm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                and to_date(to_char(tsm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  and tsd.approver_stage='F'\r\n               and installment_status=true \r\n                and tsm.organization_id = ", num, " AND tsm.org_branch_reg_id = ", num1, " \r\n                group by i.item_name,tsd.item_id,i.item_name,tsd.unit_id,iu.unit_code,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n                 UNION ALL\r\n                select tpd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id, iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,\r\n                 0 productionpq,0 productionpt,\r\n                      0 productionpv,0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd,\r\n                       sum(tpd.quantity) trnsisuueq,sum(tpd.quantity*tpd.unit_price)trnsissueprice, sum(tpd.vat_amount) trnsissuevat,\r\n                       sum(tpd.sd_amount) trnsissuesd,0 sq1, 0 st1, 0 sv1, 0 ssd1,0 gq,0 gp,0 gv,0 gs\r\n                from trns_transfer_master tpm\r\n                inner join trns_transfer_detail tpd on tpm.transfer_id = tpd.transfer_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n               left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(tpm.issues_date,'MM/dd/yyyy'),'MM/dd/yyyy') >=to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  \r\n                      and to_date(to_char(tpm.issues_date,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  \r\n                      and tpm.organization_id = ", num, " AND tpm.issuing_branch_id =", num1, " and tpm.transfer_status = 'I'\r\n                group by i.item_name,tpd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id\r\n\r\n               UNION ALL\r\n                select gd.item_id, i.item_name, 0 unit_id, '' unit_code,i.product_type,i.weight,i.weight_unit_id, iuu.unit_code,0 prequantity, 0 preqntamount,0 proq, 0 prot,0 pq,0 pt,0 pv,0 psd,0 cpq, 0 cpt, 0 cpv,0 cpsd,0 dpq, 0 dpt, 0 dpv,0 dpsd,\r\n                 0 productionpq,0 productionpt,\r\n                      0 productionpv,0 productionpsd,0 openpq,0 openpt,0 openpv,0 opensd,0 sq, 0 st, 0 sv, 0 ssd,\r\n                       0 trnsisuueq,0 trnsissueprice, 0 trnsissuevat,\r\n                      0,0 sq1, 0 st1, 0 sv1, 0 ssd1,sum(gd.quantity) gq,sum(gd.price) gp,sum(gd.discounted_vat) gv,sum(gd.discounted_sd) gs\r\n                from gift_items_detail gd\r\n                inner join item i on gd.item_id = i.item_id\r\n                left join item_unit iuu on i.weight_unit_id = iuu.unit_id\r\n                where to_date(to_char(gd.date_consumable_challan ,'MM/dd/yyyy'),'MM/dd/yyyy') >=to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                      and to_date(to_char(gd.date_consumable_challan ,'MM/dd/yyyy'),'MM/dd/yyyy') <=  to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  \r\n                      and gd.organization_id = ", num, " AND gd.org_branch_id =", num1, " \r\n                group by i.item_name,gd.item_id,i.product_type,i.weight,iuu.unit_code,i.weight_unit_id) mqmm2               \r\n              where product_type='", productType, "' ", str, "\r\n                group by item_id,product_type,weight,unit_codei,weight_unit_id\r\n                order by item_id" };
                empty = string.Concat(objArray);
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getPriceRawItemForGridCount(int TempID)
        {
            string str = string.Concat("select pi.price_id temp_id,pi.price_declaration_no temp_no,pi.price_declaration_year temp_year, \r\n                            to_char(pi.date_effective,'dd/MM/yyyy') date ,pri.item_id, pri.unit_id,i.sub_category_id,\r\n                            pri.quantity,pri.quantity_total,pri.unit_price,pri.discount_price, pri.tax\r\n                            from price_item pi\r\n                            inner join price_raw_item pri on pi.price_id = pri.price_id\r\n                            inner join item i on pri.Item_id = i.item_id\r\n                            WHERE pi.price_id = ", TempID, " AND pi.is_deleted = false and i.is_deleted = false");
            return this.db.GetDataTable(str);
        }

        public DataTable getProductInfo(string product)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat(" SELECT I.ITEM_ID,I.ITEM_NAME,I.HS_CODE,IU.UNIT_ID, IU.UNIT_NAME\r\n                             FROM ITEM I\r\n                             INNER JOIN ITEM_UNIT IU ON I.UNIT_ID = IU.UNIT_ID\r\n                             WHERE I.ITEM_NAME LIKE '%", product, "%' AND I.IS_DELETED= FALSE AND I.PRODUCT_TYPE = 'R'");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetProductionInformationByItemId(DateTime fDate, DateTime tDate, int Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { " select d.item_id,i.item_name,d.quantity,0 purchase_vat,0 purchase_sd, to_char(m.date_production,'dd-MON-yyyy') date_production,m.date_production dtc,\r\n\r\n\r\ncast(coalesce((d.quantity * (select coalesce(case when d.unit_price!=0 then d.unit_price/d.quantity  when max(purchase_unit_price)=0 then (max(total_price/quantity)) else max(purchase_unit_price) end,0)  from trns_purchase_detail where item_id = ", Item_id, " and quantity!=0)),0) as decimal(18,2)) price,\r\n'Received' remarks,d.unit_price\r\n\t\t                from trns_production_detail d\r\n                                inner join trns_production_master m on d.production_id = m.production_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                      where cast (m.Date_Production as Date) >= TO_DATE('", fDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.Date_Production as Date) <= TO_DATE('", tDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                       AND d.item_id =  ", Item_id, "  AND d.Is_deleted = false AND d.status = 'R' AND m.organization_id= ", num1, " AND M.org_branch_reg_id = ", num, " order by m.Date_Production" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getPurchaseChallanProduct(int challan_id)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("select i.item_name,pd.Quantity,pd.purchase_unit_price,(pd.purchase_unit_price*pd.Quantity) as total_price, pd.purchase_vat,\r\n                                (pd.purchase_unit_price*pd.Quantity+pd.purchase_vat) grand_total\r\n                                from trns_purchase_detail as pd\r\n                                join trns_purchase_master as pm on pm.Challan_id=pd.Challan_id\r\n                                join Item as i on i.Item_id=pd.Item_id\r\n                                 where pm.Challan_id=", challan_id);
            return this.db.GetDataTable(str);
        }

        public DataTable getPurchaseChallanProductByInvoice(string invoice)
        {
            DataTable dataTable = new DataTable();
            string[] strArrays = new string[] { "select  i.item_name,pd.Quantity,pd.purchase_unit_price as cunit_price,(pd.purchase_unit_price*pd.Quantity) as total_price, pd.purchase_vat,\r\n                                (pd.purchase_unit_price*pd.Quantity+pd.purchase_vat) grand_total,\r\n                                (select unit_price from trns_vendor_details tvd1\r\n                                   inner join trns_vendor_master tvm1 on tvm1.work_order_id = tvd1.work_order_id\r\n                                   where tvm1.vouchar_no = '", invoice, "' and  tvd1.Item_id = i.item_id and tvm1.status= false\r\n                                )punit_price,pd.difference,pd.discount_amount,iu.unit_code\r\n                                from trns_purchase_detail as pd\r\n                                inner join trns_purchase_master as pm on pm.Challan_id=pd.Challan_id\r\n                                inner join Item as i on i.Item_id=pd.Item_id\r\n                                inner join item_unit iu on pd.unit_id = iu.unit_id\r\n                                where pm.contails_challan_no='", invoice, "'" };
            string str = string.Concat(strArrays);
            return this.db.GetDataTable(str);
        }
        //public DataTable GetPurchaseInformationByItemId(DateTime fDate, DateTime tDate, long Item_id, string branchIds)
        //{
        //    DataTable dataTable = new DataTable();
        //    try
        //    {
        //        int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
        //        object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,tpd.quantity,(tpd.quantity*tpd.purchase_unit_price) price,\r\n                       purchase_vat,purchase_sd,\r\n                       case when  tpm.challan_type='P' then 'Purchase' \r\n                       when tpm.challan_type='O' then 'Opening Balance'\r\n                       when tpm.challan_type='T' then 'Transfer Receive'\r\n                       when tpm.challan_type='D' then 'Debit' end remarks \r\n                       from trns_purchase_master tpm\r\n                       inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                       inner join item i on tpd.item_id = i.item_id\r\n                       where i.item_id=", Item_id, " and tpm.organization_id=", num, " and tpm.org_branch_reg_id in(", branchIds, ") and tpm.is_trns_accepted=true  and tpm.approver_stage='F'\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.quantity !=0 and tpm.challan_type in ('P','D','O','T')" };
        //        string str = string.Concat(itemId);
        //        dataTable = this.db.GetDataTable(str);
        //    }
        //    catch (Exception exception)
        //    {
        //        ReallySimpleLog.WriteLog(exception);
        //    }
        //    return dataTable;
        //}

        public DataTable GetPurchaseInformationByItemId(DateTime fDate, DateTime tDate, long itemId, string branchIds)
        {
            DataTable dataTable = new DataTable();

            try
            {
                int orgId = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);

                // PostgreSQL তারিখ compare করার জন্য YYYY-MM-DD ফরম্যাট নেয়া ভালো
                string fromDate = fDate.ToString("yyyy-MM-dd");
                string toDate = tDate.ToString("yyyy-MM-dd");

                string query = $@"
            select 
                to_char(tpm.date_challan,'dd-MON-yyyy') as date_challan,
                tpd.item_id,
                i.item_name,
                tpd.quantity,
                (tpd.quantity * tpd.purchase_unit_price) as price,
                tpd.purchase_vat,
                tpd.purchase_sd,
                case 
                    when tpm.challan_type = 'P' then 'Purchase'
                    when tpm.challan_type = 'O' then 'Opening Balance'
                    when tpm.challan_type = 'T' then 'Transfer Receive'
                    when tpm.challan_type = 'D' then 'Debit'
                end as remarks
            from trns_purchase_master tpm
            inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id
            inner join item i on tpd.item_id = i.item_id
            where tpd.item_id = {itemId}
              and tpm.organization_id = {orgId}
              and tpm.org_branch_reg_id in ({branchIds})
              and tpm.is_trns_accepted = true
              -- approver_stage কলাম না থাকায় এটা সরানো হয়েছে:
              -- and tpm.approver_stage = 'F'
              and tpm.date_challan::date >= '{fromDate}'::date
              and tpm.date_challan::date <= '{toDate}'::date
              and tpd.quantity <> 0
              and tpm.challan_type in ('P','D','O','T');
        ";

                dataTable = this.db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }

            return dataTable;
        }


        public DataTable GetPurchaseInformationByItemId(DateTime fDate, DateTime tDate, long Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                long num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                long num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,tpd.quantity,(tpd.quantity*tpd.purchase_unit_price) price,\r\n                       purchase_vat,purchase_sd,\r\n                       case when  tpm.challan_type='P' then 'Purchase' \r\n                       when tpm.challan_type='O' then 'Opening Balance'\r\n                       when tpm.challan_type='T' then 'Transfer Receive'\r\n                       when tpm.challan_type='D' then 'Debit' end remarks \r\n                       from trns_purchase_master tpm\r\n                       inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                       inner join item i on tpd.item_id = i.item_id\r\n                       where i.item_id=", Item_id, " and tpm.organization_id=", num1, " and tpm.org_branch_reg_id=", num, " and tpm.is_trns_accepted=true  and tpd.approver_stage='F'\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.quantity !=0 and tpm.challan_type in ('P','D','O','T')" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleInformationByItemId(DateTime fDate, DateTime tDate, long Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,case when installment_status=false then tpd.quantity else 0 end quantity,(tpd.quantity*tpd.actual_price) price,\r\n                      vat,sd ,'Sale' remarks, tpm.date_challan orderDate\r\n                from trns_sale_master tpm\r\n                inner join trns_sale_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                where i.item_id=", Item_id, "  and  tpm.organization_id=", num1, " and tpm.org_branch_reg_id=", num, "  and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.approver_stage='F'\r\n                union ALL\r\n                select to_char(tnm.date_note,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.actual_price) price,\r\n                tnd.return_vat,tnd.return_sd ,'Credit' remarks , tnm.date_note orderDate\r\n                from trns_note_master tnm\r\n                inner join trns_note_detail tnd on tnm.note_id = tnd.note_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num1, " and tnm.org_branch_reg_id=", num, " and tnm.date_note >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and tnm.date_note <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnd.status!='O' and tnm.note_type='C'\r\n           union ALL\r\n                 select to_char(tnm.issues_date,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.unit_price) price,\r\n                tnd.vat_amount,tnd.sd_amount ,'Transfer Receive' remarks , tnm.issues_date orderDate\r\n                from trns_transfer_master tnm\r\n                inner join trns_transfer_detail tnd on tnm.transfer_id = tnd.transfer_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num1, " and tnm.issuing_branch_id=", num, " \r\n                and cast(tnm.issues_date as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(tnm.issues_date as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnm.transfer_status = 'I'\r\n union ALL\r\n                select to_char(gd.date_consumable_challan ,'dd-MON-yyyy') date_challan,gd.item_id,i.item_name,gd.quantity,gd.price,\r\n                gd.discounted_vat vat_amount,gd.discounted_sd sd_amount ,case when gd.remarks='' then 'Gift' else gd.remarks end remarks, gd.date_consumable_challan orderDate\r\n                from gift_items_detail gd               \r\n                inner join item i on gd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and gd.organization_id=", num1, " and gd.org_branch_id=", num, "  \r\n                and cast(gd.date_consumable_challan as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(gd.date_consumable_challan as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n\r\n                order by orderDate desc" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        //public DataTable GetSaleInformationByItemId(DateTime fDate, DateTime tDate, long Item_id, string branchIds)
        //{
        //    DataTable dataTable = new DataTable();
        //    try
        //    {
        //        int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
        //        object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,case when installment_status=false then tpd.quantity else 0 end quantity,(tpd.quantity*tpd.actual_price) price,\r\n                      vat,sd ,CASE WHEN tpm.CHALLAN_TYPE='D' THEN 'Dispose' ELSE 'Sale' END as remarks, tpm.date_challan orderDate\r\n                from trns_sale_master tpm\r\n                inner join trns_sale_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                where i.item_id=", Item_id, "  and  tpm.organization_id=", num, " and tpm.org_branch_reg_id in(", branchIds, ") and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpm.approver_stage='F'\r\n                \r\n                union ALL\r\n\r\n                select to_char(tnm.date_note,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.actual_price) price,\r\n                tnd.return_vat,tnd.return_sd ,'Credit' remarks , tnm.date_note orderDate\r\n                from trns_note_master tnm\r\n                inner join trns_note_detail tnd on tnm.note_id = tnd.note_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num, " and tnm.org_branch_reg_id in(", branchIds, ") and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnd.status!='O' and tnm.note_type='C'\r\n           \r\n                union ALL\r\n\r\n                 select to_char(tnm.issues_date,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.unit_price) price,\r\n                tnd.vat_amount,tnd.sd_amount ,'Transfer Receive' remarks , tnm.issues_date orderDate\r\n                from trns_transfer_master tnm\r\n                inner join trns_transfer_detail tnd on tnm.transfer_id = tnd.transfer_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num, " and tnm.issuing_branch_id in(", branchIds, ") \r\n                and cast(tnm.issues_date as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(tnm.issues_date as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnm.transfer_status = 'I'\r\n                \r\n                union ALL\r\n\r\n                select to_char(gd.date_consumable_challan ,'dd-MON-yyyy') date_challan,gd.item_id,i.item_name,gd.quantity,gd.price,\r\n                gd.discounted_vat vat_amount,gd.discounted_sd sd_amount ,case when gd.remarks='' then 'Gift' else gd.remarks end remarks, gd.date_consumable_challan orderDate\r\n                from gift_items_detail gd               \r\n                inner join item i on gd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and gd.organization_id=", num, " and gd.org_branch_id in(", branchIds, ")  \r\n                and cast(gd.date_consumable_challan as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(gd.date_consumable_challan as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n\r\n                order by orderDate desc" };
        //        string str = string.Concat(itemId);
        //        dataTable = this.db.GetDataTable(str);
        //    }
        //    catch (Exception exception)
        //    {
        //        ReallySimpleLog.WriteLog(exception);
        //    }
        //    return dataTable;
        //}

        public DataTable GetSaleInformationByItemId(DateTime fDate, DateTime tDate, long itemId, string branchIds)
        {
            DataTable dataTable = new DataTable();

            try
            {
                int orgId = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);

                // PostgreSQL-এর জন্য yyyy-MM-dd ফরম্যাট ব্যবহার করাই সহজ
                string fromDate = fDate.ToString("yyyy-MM-dd");
                string toDate = tDate.ToString("yyyy-MM-dd");

                string query = $@"
            -- 1) Sale / Dispose
            select 
                to_char(tpm.date_challan,'dd-MON-yyyy')      as date_challan,
                tpd.item_id,
                i.item_name,
                case 
                    when installment_status = false then tpd.quantity 
                    else 0 
                end                                          as quantity,
                (tpd.quantity * tpd.actual_price)            as price,
                vat,
                sd,
                case 
                    when tpm.challan_type = 'D' then 'Dispose'
                    else 'Sale'
                end                                          as remarks,
                tpm.date_challan                             as orderDate
            from trns_sale_master tpm
            inner join trns_sale_detail tpd on tpm.challan_id = tpd.challan_id
            inner join item i              on tpd.item_id     = i.item_id
            where tpd.item_id         = {itemId}
              and tpm.organization_id = {orgId}
              and tpm.org_branch_reg_id in ({branchIds})
              and tpm.date_challan::date >= '{fromDate}'::date
              and tpm.date_challan::date <= '{toDate}'::date
              -- আগের মতো approver_stage ফিল্টার দরকার হলে, আগে টেবিলে কলাম আছে কিনা নিশ্চিত হয়ে তারপর আবার যোগ করবেন
              -- and tpm.approver_stage = 'F'

            union all

            -- 2) Credit Note
            select 
                to_char(tnm.date_note,'dd-MON-yyyy')         as date_challan,
                tnd.item_id,
                i.item_name,
                tnd.quantity,
                (tnd.quantity * tnd.actual_price)            as price,
                tnd.return_vat,
                tnd.return_sd,
                'Credit'                                     as remarks,
                tnm.date_note                                as orderDate
            from trns_note_master tnm
            inner join trns_note_detail tnd on tnm.note_id = tnd.note_id
            inner join item i              on tnd.item_id = i.item_id
            where tnd.item_id         = {itemId}
              and tnm.organization_id = {orgId}
              and tnm.org_branch_reg_id in ({branchIds})
              and tnm.date_note::date >= '{fromDate}'::date
              and tnm.date_note::date <= '{toDate}'::date
              and tnd.status <> 'O'
              and tnm.note_type = 'C'

            union all

            -- 3) Transfer Receive
            select 
                to_char(tnm.issues_date,'dd-MON-yyyy')       as date_challan,
                tnd.item_id,
                i.item_name,
                tnd.quantity,
                (tnd.quantity * tnd.unit_price)              as price,
                tnd.vat_amount,
                tnd.sd_amount,
                'Transfer Receive'                           as remarks,
                tnm.issues_date                              as orderDate
            from trns_transfer_master tnm
            inner join trns_transfer_detail tnd on tnm.transfer_id = tnd.transfer_id
            inner join item i                on tnd.item_id    = i.item_id
            where tnd.item_id           = {itemId}
              and tnm.organization_id   = {orgId}
              and tnm.issuing_branch_id in ({branchIds})
              and tnm.issues_date::date >= '{fromDate}'::date
              and tnm.issues_date::date <= '{toDate}'::date
              and tnm.transfer_status = 'I'

            union all

            -- 4) Gift / Consumable
            select 
                to_char(gd.date_consumable_challan,'dd-MON-yyyy') as date_challan,
                gd.item_id,
                i.item_name,
                gd.quantity,
                gd.price,
                gd.discounted_vat                             as vat_amount,
                gd.discounted_sd                              as sd_amount,
                case 
                    when gd.remarks = '' then 'Gift'
                    else gd.remarks
                end                                           as remarks,
                gd.date_consumable_challan                    as orderDate
            from gift_items_detail gd
            inner join item i on gd.item_id = i.item_id
            where gd.item_id          = {itemId}
              and gd.organization_id  = {orgId}
              and gd.org_branch_id in ({branchIds})
              and gd.date_consumable_challan::date >= '{fromDate}'::date
              and gd.date_consumable_challan::date <= '{toDate}'::date

            order by orderDate desc;
        ";

                dataTable = this.db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }

            return dataTable;
        }


        public DataTable GetSubCategoryWithItem(int item_id)
        {
            string str = string.Concat("select IC.category_id,IC.category_name,IC.parent_id,IC.category_level,I.item_id,I.sub_category_id,I.item_name from item_category AS IC\r\n            LEFT JOIN item AS I\r\n            ON IC.category_id = I.sub_category_id\r\n            WHERE  IC.is_deleted = false AND I.is_deleted = false AND item_id = ", item_id);
            return this.db.GetDataTable(str);
        }

        public int GetTempID(string tempNo)
        {
            int num = 0;
            try
            {
                string str = string.Concat("select price_id from price_item where is_deleted = false and price_declaration_no = '", tempNo, "'");
                object singleValue = this.db.GetSingleValue(str);
                if (singleValue != null)
                {
                    num = Convert.ToInt32(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return num;
        }

        public DataTable GetVoucherNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select vouchar_no from trns_vendor_master where is_deleted = false and status = false");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetVoucherNoByGRNNo(string GRN_no)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select vouchar_no from trns_vendor_master where grn_no = '", GRN_no, "' and  is_deleted = false and status = false");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public bool InsertGoodsRequisitionVendor(GRVendorMasterDAO objMaster, ArrayList list)
        {
            ArrayList arrayLists = new ArrayList();
            long num = (long)0;
            bool flag = false;
            try
            {
                object singleValue = this.db.GetSingleValue("select coalesce(max(work_order_id),0) from trns_vendor_master");
                num = Convert.ToInt64(this.db.GetSingleValue("select coalesce(max(detail_id),0) from trns_vendor_details"));
                objMaster.ID = Convert.ToInt64(singleValue) + (long)1;
                object[] d = new object[] { "INSERT INTO trns_vendor_master(work_order_id, organization_id, org_branch_id, vendor_id, grn_no,reg_no, purchase_order,\r\n                                                                    receiving_store, vouchar_no, template_id,template_no, order_date, user_id_insert)\r\n                                    VALUES (", objMaster.ID, ",", objMaster.OrganizationID, ",", objMaster.OrganizationBranchID, ",", objMaster.VendorID, ",\r\n                                            '", objMaster.GRN, "','", objMaster.RegNo, "','", objMaster.PurchaseOrder, "','", objMaster.ReceivingStore, "',\r\n                                              '", objMaster.VoucharNo, "',", objMaster.TemplateID, ",'", objMaster.TemplateNo, "',\r\n                                    to_timestamp('", null, null, null, null };
                d[23] = objMaster.Date.ToString("MM/dd/yyyy HH:mm");
                d[24] = "','MM/dd/yyyy HH24:MI'),";
                d[25] = objMaster.UserID;
                d[26] = ")";
                arrayLists.Add(string.Concat(d));
                for (int i = 0; i < list.Count; i++)
                {
                    WOGoodsDAO wOGoodsDAO = new WOGoodsDAO();
                    wOGoodsDAO = (WOGoodsDAO)list[i];
                    num += (long)1;
                    object[] objArray = new object[] { "INSERT INTO trns_vendor_details(work_order_id, row_no, detail_id, item_id, unit_id, quantity, \r\n                                    unit_price, discount, tax, total_amount,user_id_insert)\r\n                                VALUES (", objMaster.ID, ",", wOGoodsDAO.RowNo, ",", num, ",", wOGoodsDAO.ItemID, ",", wOGoodsDAO.UnitID, ",\r\n                                        ", wOGoodsDAO.Quantity, ",", wOGoodsDAO.UnitPrice, ",", wOGoodsDAO.Discount, ",", wOGoodsDAO.Tax, ",\r\n                                         ", wOGoodsDAO.Total, ",", wOGoodsDAO.UserID, ")" };
                    arrayLists.Add(string.Concat(objArray));
                }
                flag = this.db.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool insertRMPIssuedData(WOGoodsMaster objCPM, ArrayList arrDetail)
        {
            ArrayList arrayLists = new ArrayList();
            objCPM.ProductionID = Convert.ToInt32(this.db.GetSingleValue("SELECT nextval('production_id_seq')"));
            object[] productionID = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, \r\n                                            production_year, material_type, date_production, user_id_insert, trns_status)\r\n                                VALUES (", objCPM.ProductionID, ",", objCPM.BranchID, ",", objCPM.OrganizationID, ", '", objCPM.ChallanNo, "', \r\n        (select coalesce (max (cg_challan_batch_no),0)+1 from trns_production_master where trns_status IN ('I','R','D','S','E') \r\n                        and production_year ='", objCPM.ProductionYear, "'), ", objCPM.ProductionYear, ", '", objCPM.MaterialType, "', \r\n                        to_timestamp('", null, null, null, null, null, null };
            productionID[15] = objCPM.ProductionDate.ToString("MM/dd/yyyy HH:mm");
            productionID[16] = "','MM/dd/yyyy HH24:MI'), @";
            productionID[17] = objCPM.UserID;
            productionID[18] = ",'";
            productionID[19] = objCPM.Status;
            productionID[20] = "')";
            arrayLists.Add(string.Concat(productionID));
            object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
            arrayLists.Add(string.Concat(challanBookId));
            arrayLists = this.getCPDetails(arrayLists, arrDetail, objCPM.ProductionID);
            return this.db.ExecuteBatchDML(arrayLists);
        }

        public bool InsertVoucherData(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO, string GRN, string Voucher)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.db.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str1 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'F')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str2 = string.Concat(objArray);
            }
            else
            {
                str2 = " null,  null, ";
            }
            str3 = (objMDAO.BankBranchId <= 0 ? " null " : objMDAO.BankBranchId.ToString());
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(", '", objMDAO.AggrementNo, "'");
            }
            if (!string.IsNullOrEmpty(objMDAO.Subject) && !string.IsNullOrEmpty(objMDAO.CChallanNo))
            {
                empty2 = ",Subject,contails_challan_no";
                string[] subject = new string[] { ", '", objMDAO.Subject, "', '", objMDAO.CChallanNo, "'" };
                empty3 = string.Concat(subject);
            }
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id, Organization_id, challan_type, purchase_type, date_challan, \r\n                            date_goods_delivery, party_id,Type,transaction_type,scroll_no,bank_name,branch_name, ultimate_destination, \r\n                            ", str, "  User_id_insert, challan_no, Remarks, bank_branch_id,payment_method,payment_info ", empty, " ", empty2, " )\r\n        VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                 ", str2, " '", objMDAO.Type, "','", objMDAO.TransactionType, "','", objMDAO.ScrollNo, "','", objMDAO.BankName, "',\r\n                '", objMDAO.BranchName, "','", objMDAO.UltimateDestination, "', ", str1, " ", objMDAO.UserIdInsert, ",\r\n                '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "', ", str3, ",'", objMDAO.PaymentMethod, "','", objMDAO.PaymentInfo, "' \r\n                 ", empty1, " ", empty3, " )" };
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID, GRN, Voucher);
            DataTable dataTable = new DataTable();
            return this.db.ExecuteBatchDML(arrayLists);
        }

        public DataTable LoadSCIByCategoryID(int CatID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select  isc.category_id sub_category_id, isc.category_name sub_category_name,\r\n                            i.item_id, i.item_name\r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id\r\n                            where i.is_deleted = false and  ic.category_id = ", CatID, "\r\n                            order by i.item_name");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable LoadSCIByItemID(int ItemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct ic.category_id, ic.category_name, isc.category_id sub_category_id, isc.category_name sub_category_name,\r\n                            i.item_id, i.item_name, i.unit_id, iu.unit_name, iu.unit_code, i.hs_code,i.item_sku\r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id \r\n                            inner join item_unit iu on i.unit_id = iu.unit_id \r\n                            where  i.item_id = ", ItemID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }
    }
}
