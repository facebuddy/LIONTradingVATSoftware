<?php

namespace Seng\Core;

use App\Http\Controllers\Controller;
use App\Models\ComponentGroupMaster;
use App\Models\ComponentMaster;
use App\Models\ProductMaster;
use App\Models\ProductPrice;
use Carbon\Carbon;
use App\Models\ProductComponent;
use App\Models\Utility;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Session;

class reportService extends Controller
{

  public $successStatus = 200;

  public function testReport()
  {
    return 'Service report Api!';
  }

  public function InventoryList(Request $request)
  {


    //  return response()->json('Ok');
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $product_name = '%' . $pname . '%';

    $baseQuery = "Select  product_masters.product_id                                                             As id,
                        product_masters.barcode                                                                As barcode,
                        product_masters.product_code                                                           As product_code,
                        product_masters.name                                                                   As name,
                        product_masters.bn_name                                                                As bn_name,
                        product_masters.company_id                                                             As company_id, 
                        product_masters.oldcode                                                                As oldcode, 
                        product_masters.product_image_url                                                      As product_image_url,
                        product_masters.status                                                                 As status,
                        product_masters.unittype_id                                                            As unittype_id,
                        unit_types.unit_name                                                                   As unit_name,
                        product_masters.pics_qty                                                               As pics_qty,
                        productComponent.*,
                        price_types.id                                                                         As pricetype_id,

                        price_types.price_name                                                      As price_name,
                        IFNULL(product_prices.product_price, 0)                                     As product_price,
                        IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                        IFNULL(inventories.quantity, 0)                                             AS stock,
                        IFNULL(inventories.quantity/product_masters.pics_qty, 0)                                               AS  stock_qtn,

                        IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                 ( SELECT  product_prices.product_price FROM  product_prices 
                        LEFT JOIN price_types ON product_prices.price_id=price_types.id
                    WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                FROM  product_masters 
                      LEFT JOIN 

                  (SELECT n.product_id,
                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                      FROM (

                              SELECT  product_components.product_id                                             As product_id,
                                      component_masters.component_id                                            As component_id,
                                      component_group_masters.group_name                                        As group_name,
                                      component_group_masters.id                                                As component_group_id,
                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                      component_masters.component_name                                          As component_name
                                FROM component_group_masters
                                INNER JOIN component_masters
                                  ON component_group_masters.id=component_masters.component_group_id
                                INNER JOIN product_components 
                                  ON product_components.component_id=component_masters.component_id) n
                                GROUP BY n.product_id 
                            ) AS productComponent

                          ON product_masters.product_id=productComponent.product_id
                        LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                        LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id and product_prices.price_id=1
                        LEFT JOIN price_types ON product_prices.price_id=price_types.id
                        LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                        LEFT JOIN inventories ON product_masters.product_id=inventories.product_id
                     
                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }
    $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery);

    return response()->json($productsList);
  }

  public function InventoryListPrint(Request $request)
  {


    //  return response()->json('Ok');
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $product_name = '%' . $pname . '%';

    $baseQuery = "Select  product_masters.product_id                                                             As id,
                        product_masters.barcode                                                                As barcode,
                        product_masters.product_code                                                           As product_code,
                        product_masters.name                                                                   As name,
                        product_masters.bn_name                                                                As bn_name,
                        product_masters.company_id                                                             As company_id, 
                        product_masters.oldcode                                                                As oldcode, 
                        product_masters.product_image_url                                                      As product_image_url,
                        product_masters.status                                                                 As status,
                        product_masters.unittype_id                                                            As unittype_id,
                        unit_types.unit_name                                                                   As unit_name,
                        product_masters.pics_qty                                                               As pics_qty,
                        productComponent.*,
                        price_types.id                                                                         As pricetype_id,

                        price_types.price_name                                                      As price_name,
                        IFNULL(product_prices.product_price, 0)                                     As product_price,
                        IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                        IFNULL(inventories.quantity, 0)                                             AS stock,
                        IFNULL(inventories.quantity/product_masters.pics_qty, 0)                                               AS  stock_qtn,

                        IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                 IFNULL(  ( SELECT  product_prices.product_price FROM  product_prices 
                        LEFT JOIN price_types ON product_prices.price_id=price_types.id
                    WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id),0) AS tp_price




                FROM  product_masters 
                      LEFT JOIN 

                  (SELECT n.product_id,
                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                      FROM (

                              SELECT  product_components.product_id                                             As product_id,
                                      component_masters.component_id                                            As component_id,
                                      component_group_masters.group_name                                        As group_name,
                                      component_group_masters.id                                                As component_group_id,
                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                      component_masters.component_name                                          As component_name
                                FROM component_group_masters
                                INNER JOIN component_masters
                                  ON component_group_masters.id=component_masters.component_group_id
                                INNER JOIN product_components 
                                  ON product_components.component_id=component_masters.component_id) n
                                GROUP BY n.product_id 
                            ) AS productComponent

                          ON product_masters.product_id=productComponent.product_id
                        LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                        LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id and product_prices.price_id=1
                        LEFT JOIN price_types ON product_prices.price_id=price_types.id
                        LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                        LEFT JOIN inventories ON product_masters.product_id=inventories.product_id
                     
                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }
    $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery);

    $stockList[] = ['start_date' => '2020-01-01', 'end_date' => '2020-01-01', 'StockSummaryList' => $productsList];


    return response()->json($stockList);
  }




  public function getBitOutletInfo(Request $request)
  {



    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $baseQuery1 = " SELECT company_masters.name as distributor_name, bit_name,outlet_code, outlet_name, bn_outlet_name, category, outlet_type, g.name as division, dis.name as district, upozila.name as upozila FROM distributors_outlets 
      LEFT JOIN outlet_masters on distributors_outlets.outlet_id=outlet_masters.id
      LEFT JOIN bit_masters on bit_masters.id=distributors_outlets.bit_id
      LEFT JOIN company_masters on distributors_outlets.distributor_company_id=company_masters.id
      LEFT JOIN all_geo_code AS g   ON outlet_masters.division = g.id
      LEFT JOIN all_geo_code AS dis   ON outlet_masters.district = dis.id
       LEFT JOIN all_geo_code AS upozila   ON outlet_masters.district = upozila.id
       WHERE outlet_code is not NULL";




    $collections = DB::select($baseQuery1, [$startDate, $endDate]);

    $ledgerDetailList[] = ['BitOutletVwList' => $collections];


    return response()->json($ledgerDetailList);
  }





  public function getCollectionReportExcludingAdjustmentPrint(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "  SELECT company_masters.name as distributor_name, bank_masters.name as bank_name,cstomerBank.name as customer_bank_name, company_masters.code as distributor_code, employee_masters.name as area_name,party_ledger_masters.credit as amount,party_ledger_masters.particulars as mode, party_ledger_masters.* FROM party_ledger_masters
                            LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            LEFT JOIN distributor_masters ON company_masters.id= distributor_masters.company_id
                            LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                            LEFT JOIN bank_masters ON bank_masters.id=party_ledger_masters.bank_id
                            LEFT JOIN bank_masters as cstomerBank ON cstomerBank.id=party_ledger_masters.customer_bank_id
                            WHERE  party_ledger_masters.particular_id <> 3 and transaction_date BETWEEN ? AND ? ";




    $collections = DB::select($baseQuery1, [$startDate, $endDate]);

    $ledgerDetailList[] = ['collectionList' => $collections];


    return response()->json($ledgerDetailList);
  }




  public function getAdjustmentReport(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "  SELECT company_masters.name as distributor_name, bank_masters.name as bank_name,cstomerBank.name as customer_bank_name, company_masters.code as distributor_code, employee_masters.name as area_name,party_ledger_masters.credit as amount,party_ledger_masters.particulars as mode, party_ledger_masters.* FROM party_ledger_masters
                            LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            LEFT JOIN distributor_masters ON company_masters.id= distributor_masters.company_id
                            LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                            LEFT JOIN bank_masters ON bank_masters.id=party_ledger_masters.bank_id
                            LEFT JOIN bank_masters as cstomerBank ON cstomerBank.id=party_ledger_masters.customer_bank_id
                            WHERE  party_ledger_masters.particular_id = 3 and transaction_date BETWEEN ? AND ? ";




    $collections = DB::select($baseQuery1, [$startDate, $endDate]);

    $ledgerDetailList[] = ['collectionList' => $collections];


    return response()->json($ledgerDetailList);
  }





  public function GetChalanReceiveReportDetail(Request $request)
  {



    $subbrand_id = $request->get("subbrand_id");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);


    $baseQuery = " SELECT
       IFNULL(details.tp_price,0)*SUM(details.quantity_purchase) as total_tp,
       IFNULL(details.dp_price,0)*SUM(details.quantity_purchase) as total_dp,
       IFNULL(details.tp_price,0) as tp_price,
       IFNULL(details.dp_price,0) as dp_price, 
      SUM(details.quantity_purchase) AS quantity_purchase, 
      SUM(details.quantity_purchase)/pics_qty as ctn,
      details.name,
      details.product_id,
      productComponent.subbrand_name,
      productComponent.subbrand_id
     
     
      
      FROM
     (SELECT  product_masters.pics_qty, tp_price.product_price as tp_price, product_prices.product_price AS dp_price, product_masters.name, chalan_details.* , 
     
     chalan_masters.chalan_date
     
     
     
     
      FROM chalan_masters 
     
     LEFT JOIN chalan_details on chalan_masters.id=chalan_details.chalanmaster_id
     LEFT JOIN product_masters ON chalan_details.product_id=product_masters.product_id
      LEFT JOIN product_prices ON product_masters.product_id=product_prices.product_id  and product_prices.price_id=1
     -- LEFT JOIN price_types ON product_prices.price_id=price_types.id
     
      LEFT JOIN product_prices as tp_price ON product_masters.product_id=tp_price.product_id  and tp_price.price_id=2
     --  LEFT JOIN price_types as tp_type ON tp_price.price_id=tp_type.id
     
     where chalan_masters.chalan_type=1 
    --  AND price_types.id=2
    --   AND tp_type.id=1
     
     AND chalan_masters.chalan_date BETWEEN ? AND ?) as details
     
     LEFT JOIN
     
       (SELECT n.product_id,
                                   MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                             MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                   MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                             MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                   MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                             MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                   MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                             MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                   MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                             MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                             MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                             MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                              MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                             MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                              MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                             MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
     
                           FROM (
     
                                   SELECT  product_components.product_id                                             As product_id,
                                           component_masters.component_id                                            As component_id,
                                           component_group_masters.group_name                                        As group_name,
                                           component_group_masters.id                                                As component_group_id,
                                           component_group_masters.cgroup_code                                       As cgroup_code,
                                           component_masters.component_name                                          As component_name
                                     FROM component_group_masters
                                     INNER JOIN component_masters
                                       ON component_group_masters.id=component_masters.component_group_id
                                     INNER JOIN product_components 
                                       ON product_components.component_id=component_masters.component_id) n
                                     GROUP BY n.product_id 
                                 ) AS productComponent
     on productComponent.product_id=details.product_id

                  ";
    $dynamicSql = (array) null;






    if ($subbrand_id > 0) {
      $dynamicSql[] = "  productComponent.subbrand_id = '$subbrand_id' ";
    }



    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";
    $nrm = $baseQuery . '  GROUP BY details.product_id      ';
    $productsList = DB::select($nrm, [$startDate, $endDate]);

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }











  public function GetSalesReportDetail(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT  salesview.* ,productview.* FROM

                    ( SELECT company_masters.code as dealer_code, IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name,sales_masters.id as salesmaster_id, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                      sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price,
                      sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                        sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                      LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                      LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                      LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                      LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                      ) AS salesview  



                    INNER JOIN

                    (Select  product_masters.product_id                                                             As id,
                                            product_masters.barcode                                                                As barcode,
                                            product_masters.product_code                                                           As product_code,
                                            product_masters.name                                                                   As name,
                                            product_masters.bn_name                                                                As bn_name,
                                            product_masters.company_id                                                             As company_id, 
                                            product_masters.oldcode                                                                As oldcode, 
                                            product_masters.product_image_url                                                      As product_image_url,
                                            product_masters.status                                                                 As status,
                                            product_masters.unittype_id                                                            As unittype_id,

                                            product_masters.pics_qty                                                               As pics_qty,
                                            productComponent.*



                                    FROM  product_masters 
                                          LEFT JOIN 

                                      (SELECT n.product_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                             MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                             MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                            MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                          FROM (

                                                  SELECT  product_components.product_id                                             As product_id,
                                                          component_masters.component_id                                            As component_id,
                                                          component_group_masters.group_name                                        As group_name,
                                                          component_group_masters.id                                                As component_group_id,
                                                          component_group_masters.cgroup_code                                       As cgroup_code,
                                                          component_masters.component_name                                          As component_name
                                                    FROM component_group_masters
                                                    INNER JOIN component_masters
                                                      ON component_group_masters.id=component_masters.component_group_id
                                                    INNER JOIN product_components 
                                                      ON product_components.component_id=component_masters.component_id) n
                                                    GROUP BY n.product_id 
                                                ) AS productComponent

                                              ON product_masters.product_id=productComponent.product_id) AS productview

                      ON salesview.product_id=productview.product_id

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }



    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '   ORDER BY salesview.salesmaster_id ASC');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetSalesReportDetailNetSale(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " 
            
                        SELECT *FROM 

                        (SELECT  salesview.* ,productview.* FROM

                                            ( SELECT  distributor_masters.category, company_masters.code as dealer_code, IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name,sales_masters.id as salesmaster_id, company_masters.name as company_name,company_masters.id as company_id1, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                              sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price,
                                              sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                                sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                              LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                              LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                              LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                              LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                              ) AS salesview  



                                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As id,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON salesview.product_id=productview.product_id1

                          UNION ALL 


                          SELECT  salesview.* ,productview.* FROM

                                            ( SELECT  distributor_masters.category, company_masters.code as dealer_code, IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name,sales_return_masters.id as salesreturnhmaster_id, company_masters.name as company_name,company_masters.id as company_id, sales_return_masters.return_invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_return_masters.return_date, sales_return_details.product_id AS product_id2,
                                              sales_return_details.quantity*-1 as qty, sales_return_details.ctn_quantity*-1 as ctn,IFNULL( sales_return_details.unit_price,0) as unit_price_new,
                                              sales_return_details.totalamount*-1 as total_amount, sales_return_details.discount_amount*-1 as discount_amt, sales_return_details.netamount*-1 as net_amount  FROM sales_return_masters
                                                LEFT JOIN sales_return_details on sales_return_details.sales_return_master_id=sales_return_masters.id
                                                LEFT JOIN company_masters ON sales_return_masters.distribution_node_id=company_masters.id  
                                                LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                                LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                                LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                              ) AS salesview  



                                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As id,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON salesview.product_id2=productview.product_id1


                        ) AS netSale

                         

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }



    if ($company_id > 0) {
      $dynamicSql[] = " netSale.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " netSale.asm_id = '$asm_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " netSale.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '    order by netSale.sales_date ASC');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetSalesReportSecondaryDetail(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $sr_id = $request->get("sr_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT product_prices.product_price AS DP,distributor_masters.address_a as address ,tpPrice.product_price AS TP, SalesReport.invoice_no,SalesReport.name as product_name,SalesReport.subbrand_id, SalesReport.subgroup_name, SalesReport.subbrand_name,  SalesReport.sales_date, SalesReport.transaction_date, svr.id as supervisor_id, svr.name as supervisor_name,  asm.name as asm_name, asm.id as asm_id, SalesReport.asr_id, employee_masters.name as asr_name, company_masters.id as company_id, company_masters.name AS company_name, bit_masters.bit_name as bit_name,outlet_masters.outlet_name,  outlet_masters.category as category_type, outlet_masters.outlet_type,        outlet_masters.id as outlet_id, SUM( SalesReport.quantity) AS quantity, SUM(SalesReport.ctn_quantity) AS ctn_quantity, SUM(SalesReport.netamount) AS netamount, SUM(SalesReport.discount_amount) as discount_amount,  SUM(SalesReport.netamount)+SUM(SalesReport.discount_amount) as total_amount FROM

                        (SELECT salesVw.*, productview.* FROM


                        (SELECT secondary_sales_masters.invoice_no,secondary_sales_masters.owner_id, secondary_sales_masters.sales_date AS transaction_date,secondary_sales_masters.bit_id, secondary_sales_masters.asr_id, secondary_sales_masters.outlet_id, secondary_sales_details.* FROM secondary_sales_masters INNER JOIN secondary_sales_details
                          ON secondary_sales_masters.id=secondary_sales_details.salesmaster_id) AS salesVw

                          LEFT JOIN


                         (Select  product_masters.product_id                                                             As id1,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status1,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON salesVw.product_id=productview.product_id1) AS SalesReport

                          LEFT JOIN 

                          company_masters ON company_masters.id=SalesReport.owner_id
                          LEFT JOIN bit_masters ON bit_masters.id=SalesReport.bit_id
                          LEFT JOIN outlet_masters ON outlet_masters.id=SalesReport.outlet_id
                          LEFT JOIN users ON users.id=SalesReport.asr_id
                          LEFT JOIN employee_masters ON users.employee_id=employee_masters.id

                          LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters AS asm ON asm.id=distributor_masters.asm_id
                          LEFT JOIN employee_masters AS svr ON svr.id=distributor_masters.supervisor_id

                          LEFT JOIN product_prices ON product_prices.product_id=SalesReport.product_id AND product_prices.price_id=1

                          LEFT JOIN product_prices AS tpPrice ON tpPrice.product_id=SalesReport.product_id AND tpPrice.price_id=2

                      



                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " SalesReport.brand_id, = '$brand_id' ";
    }



    if ($company_id > 0) {
      $dynamicSql[] = " SalesReport.owner_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " SalesReport.asm_id = '$asm_id' ";
    }


    if ($sr_id > 0) {
      $dynamicSql[] = " SalesReport.asr_id = '$sr_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " SalesReport.category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " SalesReport.group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " SalesReport.variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " SalesReport.size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " SalesReport.packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " SalesReport.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    /* if (strlen($pname) != 0) {
          $dynamicSql[] = " name like '$product_name' ";
          } */
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '      GROUP BY SalesReport.product_id ,SalesReport.salesmaster_id    ORDER BY SalesReport.salesmaster_id DESC');
    // return response()->json($productsList);
    $salesList[] = ['company_name' => $productsList[0]->company_name, 'address' => $productsList[0]->address, 'start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function salesSummaryDetailNew(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT salesview.asm_name,salesview.area_name,productview.subbrand_name, salesview.company_name,productview.name , sum(salesview.quantity) as quantity, SUM(salesview.ctn_quantity) as ctn_quantity,  sum(salesview.netamount) as netamount  FROM

                    ( SELECT company_masters.code as dealer_code, IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name,sales_masters.id as salesmaster_id,distributor_masters.area_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                      sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0),
                      sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                        sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                      LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                      LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                      LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                      LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                      ) AS salesview  



                    INNER JOIN

                    (Select  product_masters.product_id                                                             As id,
                                            product_masters.barcode                                                                As barcode,
                                            product_masters.product_code                                                           As product_code,
                                            product_masters.name                                                                   As name,
                                            product_masters.bn_name                                                                As bn_name,
                                            product_masters.company_id                                                             As company_id, 
                                            product_masters.oldcode                                                                As oldcode, 
                                            product_masters.product_image_url                                                      As product_image_url,
                                            product_masters.status                                                                 As status,
                                            product_masters.unittype_id                                                            As unittype_id,

                                            product_masters.pics_qty                                                               As pics_qty,
                                            productComponent.*



                                    FROM  product_masters 
                                          LEFT JOIN 

                                      (SELECT n.product_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                             MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                             MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                            MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                          FROM (

                                                  SELECT  product_components.product_id                                             As product_id,
                                                          component_masters.component_id                                            As component_id,
                                                          component_group_masters.group_name                                        As group_name,
                                                          component_group_masters.id                                                As component_group_id,
                                                          component_group_masters.cgroup_code                                       As cgroup_code,
                                                          component_masters.component_name                                          As component_name
                                                    FROM component_group_masters
                                                    INNER JOIN component_masters
                                                      ON component_group_masters.id=component_masters.component_group_id
                                                    INNER JOIN product_components 
                                                      ON product_components.component_id=component_masters.component_id) n
                                                    GROUP BY n.product_id 
                                                ) AS productComponent

                                              ON product_masters.product_id=productComponent.product_id) AS productview

                      ON salesview.product_id=productview.product_id

  

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }



    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= '  WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . ' GROUP BY salesview.company_id,salesview.asm_id, productview.product_id  ORDER BY salesview.asm_name, salesview.company_name ASC');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetSalesReportDetailBrand(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT sum(salesview.quantity) as quantity, sum(salesview.ctn_quantity) as ctn_quantity, sum(salesview.netamount) as netamount ,productview.* FROM

                    (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                      sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0),
                      sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                        sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                      LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                      LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                      LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                      LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                      ) AS salesview  



                    INNER JOIN

                    (Select  product_masters.product_id                                                             As id,
                                            product_masters.barcode                                                                As barcode,
                                            product_masters.product_code                                                           As product_code,
                                            product_masters.name                                                                   As name,
                                            product_masters.bn_name                                                                As bn_name,
                                            product_masters.company_id                                                             As company_id, 
                                            product_masters.oldcode                                                                As oldcode, 
                                            product_masters.product_image_url                                                      As product_image_url,
                                            product_masters.status                                                                 As status,
                                            product_masters.unittype_id                                                            As unittype_id,

                                            product_masters.pics_qty                                                               As pics_qty,
                                            productComponent.*



                                    FROM  product_masters 
                                          LEFT JOIN 

                                      (SELECT n.product_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                            MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                             MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                            MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                             MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                            MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                          FROM (

                                                  SELECT  product_components.product_id                                             As product_id,
                                                          component_masters.component_id                                            As component_id,
                                                          component_group_masters.group_name                                        As group_name,
                                                          component_group_masters.id                                                As component_group_id,
                                                          component_group_masters.cgroup_code                                       As cgroup_code,
                                                          component_masters.component_name                                          As component_name
                                                    FROM component_group_masters
                                                    INNER JOIN component_masters
                                                      ON component_group_masters.id=component_masters.component_group_id
                                                    INNER JOIN product_components 
                                                      ON product_components.component_id=component_masters.component_id) n
                                                    GROUP BY n.product_id 
                                                ) AS productComponent

                                              ON product_masters.product_id=productComponent.product_id) AS productview

                      ON salesview.product_id=productview.product_id


                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }



    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '  GROUP BY salesview.product_id');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetNetSalesReportDetailBrand(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "";
    if ($asm_id > 0) {
      $baseQuery = " 


          SELECT SUM(netSale.quantity) AS quantity, SUM(netSale.ctn_quantity) AS ctn_quantity,sum(netSale.netamount) as netamount,netSale.sales_date, netSale.barcode,netSale.name, netSale.bn_name, netSale.oldcode, netSale.pics_qty, netSale.group_name, netSale.subgroup_name, netSale.brand_name, netSale.subbrand_name, netSale.category_name, netSale.packaging_name, netSale.size_name, netSale.size_id, netSale.subbrand_id, netSale.category_id FROM
           (SELECT sum(salesview.quantity) as quantity, sum(salesview.ctn_quantity) as ctn_quantity, sum(salesview.netamount) as netamount, salesview.sales_date ,productview.*,  salesview.asm_id  FROM
          
                              (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0),
                                sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                  sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id
          
                                ) AS salesview  
          
          
          
                              INNER JOIN
          
                              (Select  product_masters.product_id                                                             As id,
                                                      product_masters.barcode                                                                As barcode,
                                                      product_masters.product_code                                                           As product_code,
                                                      product_masters.name                                                                   As name,
                                                      product_masters.bn_name                                                                As bn_name,
                                                      product_masters.company_id                                                             As company_id, 
                                                      product_masters.oldcode                                                                As oldcode, 
                                                      product_masters.product_image_url                                                      As product_image_url,
                                                      product_masters.status                                                                 As status,
                                                      product_masters.unittype_id                                                            As unittype_id,
          
                                                      product_masters.pics_qty                                                               As pics_qty,
                                                      productComponent.*
          
          
          
                                              FROM  product_masters 
                                                    LEFT JOIN 
          
                                                (SELECT n.product_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
          
                                                    FROM (
          
                                                            SELECT  product_components.product_id                                             As product_id,
                                                                    component_masters.component_id                                            As component_id,
                                                                    component_group_masters.group_name                                        As group_name,
                                                                    component_group_masters.id                                                As component_group_id,
                                                                    component_group_masters.cgroup_code                                       As cgroup_code,
                                                                    component_masters.component_name                                          As component_name
                                                              FROM component_group_masters
                                                              INNER JOIN component_masters
                                                                ON component_group_masters.id=component_masters.component_group_id
                                                              INNER JOIN product_components 
                                                                ON product_components.component_id=component_masters.component_id) n
                                                              GROUP BY n.product_id 
                                                          ) AS productComponent
          
                                                        ON product_masters.product_id=productComponent.product_id) AS productview
          
                                ON salesview.product_id=productview.product_id
          
          
            WHERE salesview.sales_date BETWEEN '$startDate' and '$endDate'  and salesview.asm_id='$asm_id'
          
            GROUP BY salesview.product_id
          
          
          
            UNION ALL
          
          
             SELECT sum(salesview.quantity)*-1 as quantity, sum(salesview.ctn_quantity)*-1 as ctn_quantity, sum(salesview.netamount)*-1 as netamount ,salesview.return_date, productview.*, salesview.asm_id  FROM
          
                              (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_return_masters.return_invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_return_masters.return_date, sales_return_details.product_id,
                                sales_return_details.quantity, sales_return_details.ctn_quantity,IFNULL( sales_return_details.unit_price,0),
                                sales_return_details.totalamount, sales_return_details.discount_amount, sales_return_details.netamount 
                                FROM    sales_return_masters INNER JOIN sales_return_details
                                ON sales_return_details.sales_return_master_id= sales_return_masters.id   
                                LEFT JOIN company_masters ON sales_return_masters.distribution_node_id=company_masters.id  
                                LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id
          
                                ) AS salesview  
          
          
          
                              INNER JOIN
          
                              (Select  product_masters.product_id                                                             As id,
                                                      product_masters.barcode                                                                As barcode,
                                                      product_masters.product_code                                                           As product_code,
                                                      product_masters.name                                                                   As name,
                                                      product_masters.bn_name                                                                As bn_name,
                                                      product_masters.company_id                                                             As company_id, 
                                                      product_masters.oldcode                                                                As oldcode, 
                                                      product_masters.product_image_url                                                      As product_image_url,
                                                      product_masters.status                                                                 As status,
                                                      product_masters.unittype_id                                                            As unittype_id,
          
                                                      product_masters.pics_qty                                                               As pics_qty,
                                                      productComponent.*
          
          
          
                                              FROM  product_masters 
                                                    LEFT JOIN 
          
                                                (SELECT n.product_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
          
                                                    FROM (
          
                                                            SELECT  product_components.product_id                                             As product_id,
                                                                    component_masters.component_id                                            As component_id,
                                                                    component_group_masters.group_name                                        As group_name,
                                                                    component_group_masters.id                                                As component_group_id,
                                                                    component_group_masters.cgroup_code                                       As cgroup_code,
                                                                    component_masters.component_name                                          As component_name
                                                              FROM component_group_masters
                                                              INNER JOIN component_masters
                                                                ON component_group_masters.id=component_masters.component_group_id
                                                              INNER JOIN product_components 
                                                                ON product_components.component_id=component_masters.component_id) n
                                                              GROUP BY n.product_id 
                                                          ) AS productComponent
          
                                                        ON product_masters.product_id=productComponent.product_id) AS productview
          
                                ON salesview.product_id=productview.product_id
          
          
           WHERE salesview.return_date BETWEEN '$startDate' and '$endDate'  and salesview.asm_id='$asm_id'
            GROUP BY salesview.product_id) AS netSale
          
          
          
          
                              ";



      $dynamicSql = (array) null;

      if ($brand_id > 0) {
        $dynamicSql[] = " brand_id = '$brand_id' ";
      }



      if ($company_id > 0) {
        $dynamicSql[] = " netSale.company_id = '$company_id' ";
      }
      if ($asm_id > 0) {
        $dynamicSql[] = " netSale.asm_id = '$asm_id' ";
      }

      if ($category_id > 0) {
        $dynamicSql[] = " category_id = '$category_id' ";
      }

      if ($group_id > 0) {
        $dynamicSql[] = " group_id = '$group_id' ";
      }

      if ($subbrand_id > 0) {
        $dynamicSql[] = " netSale.subbrand_id = '$subbrand_id' ";
      }


      if ($variant_id > 0) {
        $dynamicSql[] = " variant_id = '$variant_id' ";
      }

      if ($size_id > 0) {
        $dynamicSql[] = " size_id = '$size_id' ";
      }

      if ($package_id > 0) {
        $dynamicSql[] = " packaging_id = '$package_id' ";
      }

      if ($request->get('start_date') && $request->get('end_date')) {


        // $startDate = $request->get('start_date') . " 00:00:00";
        // $endDate = $request->get('end_date') . " 23:59:59";
        //  $dynamicSql[] = " netSale.sales_date BETWEEN '$startDate' and '$endDate' ";
      }

      if (strlen($pname) != 0) {
        $dynamicSql[] = " name like '$product_name' ";
      }
      if (count($dynamicSql) != 0) {
        $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
      }


      // return response()->json($baseQuery);
      // $baseQuery .= " GROUP BY product_masters.product_id";

      $productsList = DB::select($baseQuery . '  GROUP BY netSale.product_id');

      $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

      return response()->json($salesList);
    } else {

      $baseQuery = " 


          SELECT SUM(netSale.quantity) AS quantity, SUM(netSale.ctn_quantity) AS ctn_quantity,sum(netSale.netamount) as netamount,netSale.sales_date, netSale.barcode,netSale.name, netSale.bn_name, netSale.oldcode, netSale.pics_qty, netSale.group_name, netSale.subgroup_name, netSale.brand_name, netSale.subbrand_name, netSale.category_name, netSale.packaging_name, netSale.size_name, netSale.size_id, netSale.subbrand_id, netSale.category_id FROM
           (SELECT sum(salesview.quantity) as quantity, sum(salesview.ctn_quantity) as ctn_quantity, sum(salesview.netamount) as netamount, salesview.sales_date ,productview.* FROM
          
                              (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0),
                                sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                  sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id
          
                                ) AS salesview  
          
          
          
                              INNER JOIN
          
                              (Select  product_masters.product_id                                                             As id,
                                                      product_masters.barcode                                                                As barcode,
                                                      product_masters.product_code                                                           As product_code,
                                                      product_masters.name                                                                   As name,
                                                      product_masters.bn_name                                                                As bn_name,
                                                      product_masters.company_id                                                             As company_id, 
                                                      product_masters.oldcode                                                                As oldcode, 
                                                      product_masters.product_image_url                                                      As product_image_url,
                                                      product_masters.status                                                                 As status,
                                                      product_masters.unittype_id                                                            As unittype_id,
          
                                                      product_masters.pics_qty                                                               As pics_qty,
                                                      productComponent.*
          
          
          
                                              FROM  product_masters 
                                                    LEFT JOIN 
          
                                                (SELECT n.product_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
          
                                                    FROM (
          
                                                            SELECT  product_components.product_id                                             As product_id,
                                                                    component_masters.component_id                                            As component_id,
                                                                    component_group_masters.group_name                                        As group_name,
                                                                    component_group_masters.id                                                As component_group_id,
                                                                    component_group_masters.cgroup_code                                       As cgroup_code,
                                                                    component_masters.component_name                                          As component_name
                                                              FROM component_group_masters
                                                              INNER JOIN component_masters
                                                                ON component_group_masters.id=component_masters.component_group_id
                                                              INNER JOIN product_components 
                                                                ON product_components.component_id=component_masters.component_id) n
                                                              GROUP BY n.product_id 
                                                          ) AS productComponent
          
                                                        ON product_masters.product_id=productComponent.product_id) AS productview
          
                                ON salesview.product_id=productview.product_id
          
          
            WHERE salesview.sales_date BETWEEN '$startDate' and '$endDate' 
          
            GROUP BY salesview.product_id
          
          
          
            UNION ALL
          
          
             SELECT sum(salesview.quantity)*-1 as quantity, sum(salesview.ctn_quantity)*-1 as ctn_quantity, sum(salesview.netamount)*-1 as netamount ,salesview.return_date, productview.* FROM
          
                              (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_return_masters.return_invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_return_masters.return_date, sales_return_details.product_id,
                                sales_return_details.quantity, sales_return_details.ctn_quantity,IFNULL( sales_return_details.unit_price,0),
                                sales_return_details.totalamount, sales_return_details.discount_amount, sales_return_details.netamount 
                                FROM    sales_return_masters INNER JOIN sales_return_details
                                ON sales_return_details.sales_return_master_id= sales_return_masters.id   
                                LEFT JOIN company_masters ON sales_return_masters.distribution_node_id=company_masters.id  
                                LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id
          
                                ) AS salesview  
          
          
          
                              INNER JOIN
          
                              (Select  product_masters.product_id                                                             As id,
                                                      product_masters.barcode                                                                As barcode,
                                                      product_masters.product_code                                                           As product_code,
                                                      product_masters.name                                                                   As name,
                                                      product_masters.bn_name                                                                As bn_name,
                                                      product_masters.company_id                                                             As company_id, 
                                                      product_masters.oldcode                                                                As oldcode, 
                                                      product_masters.product_image_url                                                      As product_image_url,
                                                      product_masters.status                                                                 As status,
                                                      product_masters.unittype_id                                                            As unittype_id,
          
                                                      product_masters.pics_qty                                                               As pics_qty,
                                                      productComponent.*
          
          
          
                                              FROM  product_masters 
                                                    LEFT JOIN 
          
                                                (SELECT n.product_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                            MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                            MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                       MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                      MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
          
                                                    FROM (
          
                                                            SELECT  product_components.product_id                                             As product_id,
                                                                    component_masters.component_id                                            As component_id,
                                                                    component_group_masters.group_name                                        As group_name,
                                                                    component_group_masters.id                                                As component_group_id,
                                                                    component_group_masters.cgroup_code                                       As cgroup_code,
                                                                    component_masters.component_name                                          As component_name
                                                              FROM component_group_masters
                                                              INNER JOIN component_masters
                                                                ON component_group_masters.id=component_masters.component_group_id
                                                              INNER JOIN product_components 
                                                                ON product_components.component_id=component_masters.component_id) n
                                                              GROUP BY n.product_id 
                                                          ) AS productComponent
          
                                                        ON product_masters.product_id=productComponent.product_id) AS productview
          
                                ON salesview.product_id=productview.product_id
          
          
           WHERE salesview.return_date BETWEEN '$startDate' and '$endDate' 
            GROUP BY salesview.product_id) AS netSale
          
          
          
          
                              ";



      $dynamicSql = (array) null;

      if ($brand_id > 0) {
        $dynamicSql[] = " brand_id = '$brand_id' ";
      }



      if ($company_id > 0) {
        $dynamicSql[] = " netSale.company_id = '$company_id' ";
      }
      if ($asm_id > 0) {
        $dynamicSql[] = " netSale.asm_id = '$asm_id' ";
      }

      if ($category_id > 0) {
        $dynamicSql[] = " category_id = '$category_id' ";
      }

      if ($group_id > 0) {
        $dynamicSql[] = " group_id = '$group_id' ";
      }

      if ($subbrand_id > 0) {
        $dynamicSql[] = " netSale.subbrand_id = '$subbrand_id' ";
      }


      if ($variant_id > 0) {
        $dynamicSql[] = " variant_id = '$variant_id' ";
      }

      if ($size_id > 0) {
        $dynamicSql[] = " size_id = '$size_id' ";
      }

      if ($package_id > 0) {
        $dynamicSql[] = " packaging_id = '$package_id' ";
      }

      if ($request->get('start_date') && $request->get('end_date')) {


        // $startDate = $request->get('start_date') . " 00:00:00";
        // $endDate = $request->get('end_date') . " 23:59:59";
        //  $dynamicSql[] = " netSale.sales_date BETWEEN '$startDate' and '$endDate' ";
      }

      if (strlen($pname) != 0) {
        $dynamicSql[] = " name like '$product_name' ";
      }
      if (count($dynamicSql) != 0) {
        $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
      }


      // return response()->json($baseQuery);
      // $baseQuery .= " GROUP BY product_masters.product_id";

      $productsList = DB::select($baseQuery . '  GROUP BY netSale.product_id');

      $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

      return response()->json($salesList);
    }
  }

  public function BrandWiseSaleSummary(Request $request)
  {

    $asm_id = $request->get("asm_id");
    // $asm_id=0;
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "   SELECT productview.subbrand_name as brand_name,SUM(salesview.quantity) as quantity, SUM(salesview.ctn_quantity) as ctn_quantity, SUM(salesview.totalamount) as totalamount, SUM(salesview.discount_amount) as discount_amount, SUM(salesview.netamount) as netamount  FROM

                                (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                  sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price ,
                                  sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                    sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                  LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                  LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                  LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                  ) AS salesview  



                                INNER JOIN

                                (Select  product_masters.product_id                                                             As id,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status,
                                                        product_masters.unittype_id                                                            As unittype_id,

                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*



                                                FROM  product_masters 
                                                      LEFT JOIN 

                                                  (SELECT n.product_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                      FROM (

                                                              SELECT  product_components.product_id                                             As product_id,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id 
                                                            ) AS productComponent

                                                          ON product_masters.product_id=productComponent.product_id) AS productview

                                  ON salesview.product_id=productview.product_id
           
                   

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }

    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }



    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '  GROUP by productview.subbrand_name ');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function BrandWiseSaleSummaryPivot(Request $request)
  {

    $asm_id = $request->get("asm_id");

    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "    SELECT salesview.company_name,salesview.asm_id,productview.subbrand_name as brand_name,SUM(salesview.quantity) as quantity, SUM(salesview.ctn_quantity) as ctn_quantity, SUM(salesview.totalamount) as totalamount, SUM(salesview.discount_amount) as discount_amount, SUM(salesview.netamount) as netamount  FROM

                                (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                  sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price ,
                                  sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                    sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                  LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                  LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                  LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                  ) AS salesview  



                                INNER JOIN

                                (Select  product_masters.product_id                                                             As id,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status,
                                                        product_masters.unittype_id                                                            As unittype_id,

                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*



                                                FROM  product_masters 
                                                      LEFT JOIN 

                                                  (SELECT n.product_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                      FROM (

                                                              SELECT  product_components.product_id                                             As product_id,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id 
                                                            ) AS productComponent

                                                          ON product_masters.product_id=productComponent.product_id) AS productview

                                  ON salesview.product_id=productview.product_id
                   

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }

    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }




    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }



    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '    GROUP by productview.subbrand_name, salesview.company_name ');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function ASMWiseBrandWiseSaleSummaryPivot(Request $request)
  {

    $asm_id = $request->get("asm_id");

    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "   SELECT employee_masters.name AS asm_name, employee_masters.id as asm_id,distributorWiseSale.brand_name, sum( distributorWiseSale.quantity) as quantity,sum( distributorWiseSale.ctn_quantity) as ctn_quantity, 
  sum( distributorWiseSale.totalamount) as totalamount, sum( distributorWiseSale.discount_amount) as discount_amount,  sum( distributorWiseSale.netamount) as netamount FROM

(SELECT salesview.company_name,salesview.company_id,salesview.sales_date, productview.subbrand_name as brand_name,SUM(salesview.quantity) as quantity, SUM(salesview.ctn_quantity) as ctn_quantity, SUM(salesview.totalamount) as totalamount, SUM(salesview.discount_amount) as discount_amount, SUM(salesview.netamount) as netamount  FROM

                                (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                  sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price ,
                                  sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                    sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                  LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                  LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                  LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                  ) AS salesview  



                                INNER JOIN

                                (Select  product_masters.product_id                                                             As id,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status,
                                                        product_masters.unittype_id                                                            As unittype_id,

                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*



                                                FROM  product_masters 
                                                      LEFT JOIN 

                                                  (SELECT n.product_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                      FROM (

                                                              SELECT  product_components.product_id                                             As product_id,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id 
                                                            ) AS productComponent

                                                          ON product_masters.product_id=productComponent.product_id) AS productview

                                  ON salesview.product_id=productview.product_id
                                      WHERE salesview.sales_date BETWEEN ? AND ?
  GROUP by productview.subbrand_name, salesview.company_id ) AS distributorWiseSale



  LEFT JOIN distributor_masters ON distributor_masters.company_id=distributorWiseSale.company_id
  LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id

                   

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " distributorWiseSale.brand_id = '$brand_id' ";
    }

    if ($company_id > 0) {
      $dynamicSql[] = " distributorWiseSale.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " distributorWiseSale.asm_id = '$asm_id' ";
    }



    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      // $dynamicSql[] = " distributorWiseSale.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      // $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }

    $startDate = $request->get('start_date') . " 00:00:00";
    $endDate = $request->get('end_date') . " 23:59:59";
    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";
    $qry = $baseQuery . '     GROUP BY asm_id, distributorWiseSale.brand_name ';
    // return response()->json($qry);

    $productsList = DB::select($qry, [$startDate, $endDate]);

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }




  public function BrandWiseSaleSummaryPivotNetSale(Request $request)
  {

    $asm_id = $request->get("asm_id");

    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "  
      

SELECT subbrand_id, asm_id, company_id, company_name, brand_name, sum(quantity) as quantity , sum(ctn_quantity) as ctn_quantity,sum(totalamount) as totalamount, sum(discount_amount) as discount_amount, SUM(netamount) as netamount FROM
(
SELECT productview.subbrand_id, salesview.asm_id, salesview.company_id, salesview.company_name,productview.subbrand_name as brand_name,SUM(salesview.quantity) as quantity, SUM(salesview.ctn_quantity) as ctn_quantity, SUM(salesview.totalamount) as totalamount, SUM(salesview.discount_amount) as discount_amount, SUM(salesview.netamount) as netamount  FROM

                                (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                  sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price ,
                                  sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                    sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                  LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                  LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                  LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

   WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'

                                  ) AS salesview  



                                INNER JOIN

                                (Select  product_masters.product_id                                                             As id,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status,
                                                        product_masters.unittype_id                                                            As unittype_id,

                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*



                                                FROM  product_masters 
                                                      LEFT JOIN 

                                                  (SELECT n.product_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                      FROM (

                                                              SELECT  product_components.product_id                                             As product_id,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id 
                                                            ) AS productComponent

                                                          ON product_masters.product_id=productComponent.product_id) AS productview

                                  ON salesview.product_id=productview.product_id
                              
 
 GROUP by productview.subbrand_name, salesview.company_name



UNION ALL

SELECT productview.subbrand_id, salesview.asm_id, salesview.company_id, salesview.company_name,productview.subbrand_name as brand_name,-1*SUM(salesview.quantity) as quantity, -1* SUM(salesview.ctn_quantity) as ctn_quantity,-1* SUM(salesview.totalamount) as totalamount, -1* SUM(salesview.discount_amount) as discount_amount,-1* SUM(salesview.netamount) as netamount  FROM

                                (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_return_masters.return_invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_return_masters.return_date, sales_return_details.product_id,
                                  sales_return_details.quantity, sales_return_details.ctn_quantity,IFNULL( sales_return_details.unit_price,0) as unit_price ,
                                  sales_return_details.totalamount, sales_return_details.discount_amount, sales_return_details.netamount  FROM
                                    sales_return_masters INNER JOIN sales_return_details ON sales_return_details.sales_return_master_id= sales_return_masters.id   
                                  LEFT JOIN company_masters ON sales_return_masters.distribution_node_id=company_masters.id  
                                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                  LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                  LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'

                                  ) AS salesview  



                                INNER JOIN

                                (Select  product_masters.product_id                                                             As id,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status,
                                                        product_masters.unittype_id                                                            As unittype_id,

                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*



                                                FROM  product_masters 
                                                      LEFT JOIN 

                                                  (SELECT n.product_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                      FROM (

                                                              SELECT  product_components.product_id                                             As product_id,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id 
                                                            ) AS productComponent

                                                          ON product_masters.product_id=productComponent.product_id) AS productview

                                  ON salesview.product_id=productview.product_id

 GROUP by productview.subbrand_name, salesview.company_name



) as Tbl






                 

                  ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }

    if ($company_id > 0) {
      $dynamicSql[] = " Tbl.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " Tbl.asm_id = '$asm_id' ";
    }



    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " Tbl.subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    // if ($request->get('start_date') && $request->get('end_date')) {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    // $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    // }

    if (strlen($pname) != 0) {
      // $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '    GROUP by Tbl.company_name, Tbl.brand_name ');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }









  public function DistributorWiseSummary(Request $request)
  {

    $asm_id = $request->get("asm_id");
    // return $asm_id;
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';



    $baseQuery = " 
SELECT  employee_masters.id as asm_id, employee_masters.name as asm_name, distributorSale.* FROM

(SELECT tbl1.*, tbl.balance as outstanding FROM

(SELECT tbl.company_name,tbl.company_id,sum(tbl.quantity) as quantity ,sum(tbl.ctn_quantity) as ctn_quantity,tbl.totalamount,sum(tbl.discount_amount) as discount_amount,sum(tbl.netamount) as netamount,sum(tbl.collection) as collection   from (SELECT *
  
  
                        FROM  (SELECT  company_masters.name as company_name,company_masters.id as company_id,sum(sales_details.quantity) as quantity, SUM(sales_details.ctn_quantity) as ctn_quantity,
                        SUM(sales_details.totalamount) AS totalamount,SUM(sales_details.discount_amount) AS discount_amount,SUM(sales_details.netamount) AS netamount, 0 as collection FROM sales_masters
                        INNER JOIN sales_details ON  sales_masters.id=sales_details.salesmaster_id
                        LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id
                        WHERE sales_masters.sales_date BETWEEN ? AND ?
                        GROUP BY sales_masters.sales_location_id) as Sale
                    UNION ALL
  
                        (SELECT company_masters.name AS company_name, distributor_id as company_id,0 as quantity,0 as qtn_quantity,0 as totalamount,0 as discount_amount,0 as netamount, SUM(credit) as collection FROM party_ledger_masters
                        LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            WHERE transaction_date BETWEEN  ? AND ?
                         GROUP BY distributor_id) ) as tbl
                        GROUP BY tbl.company_id) as tbl1


  LEFT JOIN


  (SELECT company.id as company_id, company.name, company.area_name,company.address_a, finalLedger.balance FROM 

(SELECT closingBl.company_id,sum(balance) as balance FROM

(SELECT company_masters.id as company_id , distributor_masters.opening_balance as balance  FROM company_masters INNER JOIN distributor_masters
  ON company_masters.id=distributor_masters.company_id


  UNION ALL

  SELECT ledger.company_id, ledger.balance FROM (SELECT partyledger.distributor_id as company_id, SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (
  SELECT party_ledger_masters.distributor_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE transaction_date  <?
                                  UNION ALL
                                SELECT claim_damage_collection_masters.distributor_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                FROM claim_damage_collection_masters
                                LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                               WHERE  transaction_date  <?
                                UNION ALL
                                SELECT sales_location_id as distributor_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE  sales_date<?
                                 UNION ALL

                                SELECT distribution_node_id as distributor_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                WHERE  return_date<?

                                ORDER BY transaction_date) as partyledger
                    GROUP BY partyledger.distributor_id) as ledger) as closingBl

  GROUP BY closingBl.company_id) AS finalLedger

    LEFT JOIN



                  (SELECT company_masters.id, distributor_masters.opening_balance, company_masters.name,distributor_masters.area_name, distributor_masters.address_a, company_masters.company_type FROM company_masters 
                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                WHERE company_type!=1) AS company

                  ON company.id=finalLedger.company_id
                  
 ORDER BY company.name ASC) as tbl

    ON tbl.company_id=tbl1.company_id) AS distributorSale
  LEFT JOIN distributor_masters ON distributor_masters.company_id=distributorSale.company_id

  LEFT JOIN employee_masters ON employee_masters.id=distributor_masters.asm_id";


    $dynamicSql = (array) null;

    if ($asm_id > 0) {
      $dynamicSql[] = "  employee_masters.id= '$asm_id' ";
    }



    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql) . '     ORDER BY distributorSale.company_name   ASC';
    } else {
      $baseQuery .= '    ORDER BY distributorSale.company_name ASC';
    }



    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery, [$startDate, $endDate, $startDate, $endDate, $endDate, $endDate, $endDate, $endDate]);

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function ASMWiseSummary(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';



    $baseQuery = " 
SELECT AsmOutstanding.asm_name as company_name, tbl99.quantity, tbl99.ctn_quantity,tbl99.totalamount,tbl99.discount_amount,tbl99.netamount,tbl99.collection,AsmOutstanding.outstanding as outstanding FROM

(SELECT collectionView.company_name,collectionView.company_id,sum(collectionView.quantity) as quantity ,sum(collectionView.ctn_quantity) as ctn_quantity ,sum(collectionView.totalamount) as totalamount,sum(collectionView.discount_amount) as discount_amount,sum( collectionView.netamount) as netamount ,sum(collectionView.collection) as collection, employee_masters.id AS asm_id FROM (SELECT tbl.company_name,tbl.company_id,sum(tbl.quantity) as quantity ,sum(tbl.ctn_quantity) as ctn_quantity,tbl.totalamount,sum(tbl.discount_amount) as discount_amount,sum(tbl.netamount) as netamount,sum(tbl.collection) as collection   from (SELECT *
  
  
                        FROM  (SELECT  company_masters.name as company_name,company_masters.id as company_id,sum(sales_details.quantity) as quantity, SUM(sales_details.ctn_quantity) as ctn_quantity,
                        SUM(sales_details.totalamount) AS totalamount,SUM(sales_details.discount_amount) AS discount_amount,SUM(sales_details.netamount) AS netamount, 0 as collection FROM sales_masters
                        INNER JOIN sales_details ON  sales_masters.id=sales_details.salesmaster_id
                        LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id
                        WHERE sales_masters.sales_date BETWEEN  ? AND ?
                        GROUP BY sales_masters.sales_location_id) as Sale
                    UNION ALL
  
                        (SELECT company_masters.name AS company_name, distributor_id as company_id,0 as quantity,0 as qtn_quantity,0 as totalamount,0 as discount_amount,0 as netamount, SUM(credit) as collection FROM party_ledger_masters
                        LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            WHERE transaction_date BETWEEN ? AND ?
                         GROUP BY distributor_id) ) as tbl
                        GROUP BY tbl.company_id) as collectionView

  LEFT JOIN distributor_masters ON collectionView.company_id=distributor_masters.company_id
  LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
  group by employee_masters.id) as tbl99


  LEFT JOIN 

  (SELECT employee_masters.id as asm_id, employee_masters.name as asm_name,finalOp.company_id, sum( finalOp.balance) as outstanding FROM

(SELECT company_masters.id as company_id, distributor_masters.opening_balance as balance  FROM company_masters 
  INNER JOIN distributor_masters
  ON company_masters.id=distributor_masters.company_id
  LEFT JOIN employee_masters ON employee_masters.id=distributor_masters.asm_id


  UNION ALL

  SELECT ledger.company_id, ledger.balance FROM (SELECT partyledger.distributor_id as company_id, SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (
  SELECT party_ledger_masters.distributor_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE transaction_date  <?
                                  UNION ALL
                                SELECT claim_damage_collection_masters.distributor_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                FROM claim_damage_collection_masters
                                LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                               WHERE  transaction_date  <?
                                UNION ALL
                                SELECT sales_location_id as distributor_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE  sales_date<?
                                 UNION ALL

                                SELECT distribution_node_id as distributor_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                WHERE  return_date<?

                                ORDER BY transaction_date) as partyledger
                    GROUP BY partyledger.distributor_id) as ledger) AS finalOp

  LEFT JOIN distributor_masters ON finalOp.company_id=distributor_masters.company_id
  LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
  GROUP BY asm_id) as AsmOutstanding

  ON tbl99.asm_id=AsmOutstanding.asm_id
   ORDER BY company_name
 ";









    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery, [$startDate, $endDate, $startDate, $endDate, $endDate, $endDate, $endDate, $endDate]);

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetDailySalesReportDetail(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = "  SELECT salesview.asm_name,salesview.supervisor_name,salesview.company_name,   salesview.invoice_no, salesview.sales_date,SUM(salesview.quantity) as quantity,salesview.unit_price, SUM(salesview.ctn_quantity) as ctn_quantity, SUM(salesview.totalamount) as totalamount, SUM(salesview.discount_amount) as discount_amount, SUM(salesview.netamount) as netamount  FROM

                                        (SELECT IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                                          sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price ,
                                          sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                                            sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                                          LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                                          LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                          LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                                          LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id

                                          ) AS salesview  



                                        INNER JOIN

                                        (Select  product_masters.product_id                                                             As id,
                                                                product_masters.barcode                                                                As barcode,
                                                                product_masters.product_code                                                           As product_code,
                                                                product_masters.name                                                                   As name,
                                                                product_masters.bn_name                                                                As bn_name,
                                                                product_masters.company_id                                                             As company_id, 
                                                                product_masters.oldcode                                                                As oldcode, 
                                                                product_masters.product_image_url                                                      As product_image_url,
                                                                product_masters.status                                                                 As status,
                                                                product_masters.unittype_id                                                            As unittype_id,

                                                                product_masters.pics_qty                                                               As pics_qty,
                                                                productComponent.*



                                                        FROM  product_masters 
                                                              LEFT JOIN 

                                                          (SELECT n.product_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                              FROM (

                                                                      SELECT  product_components.product_id                                             As product_id,
                                                                              component_masters.component_id                                            As component_id,
                                                                              component_group_masters.group_name                                        As group_name,
                                                                              component_group_masters.id                                                As component_group_id,
                                                                              component_group_masters.cgroup_code                                       As cgroup_code,
                                                                              component_masters.component_name                                          As component_name
                                                                        FROM component_group_masters
                                                                        INNER JOIN component_masters
                                                                          ON component_group_masters.id=component_masters.component_group_id
                                                                        INNER JOIN product_components 
                                                                          ON product_components.component_id=component_masters.component_id) n
                                                                        GROUP BY n.product_id 
                                                                    ) AS productComponent

                                                                  ON product_masters.product_id=productComponent.product_id) AS productview

                                          ON salesview.product_id=productview.product_id
                   

                    ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }

    if ($company_id > 0) {
      $dynamicSql[] = " salesview.company_id = '$company_id' ";
    }
    if ($asm_id > 0) {
      $dynamicSql[] = " salesview.asm_id = '$asm_id' ";
    }




    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {



      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '    GROUP by salesview.invoice_no ');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }

  public function GetClosingStockLedgerDetail(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";
    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';

    $baseQuery = " 
            

SELECT currentStock.product_id, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,
  
                      ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty ,
                      (( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0))/ IFNULL(currentStock.pics_qty,0) as ClosingQtn ,
  
  
                            IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                              IFNULL(sales.sale_quantity,0) AS sale_qty,
                               IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                            (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,

                            (( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) ) * currentStock.product_price  AS ClosingDp,
                            --  ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                            IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                            IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                            currentStock.* FROM








                            (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                  product_masters.barcode                                                                As barcode,
                                                  product_masters.product_code                                                           As product_code,
                                                  product_masters.name                                                                   As name,
                                                  product_masters.bn_name                                                                As bn_name,
                                                  product_masters.company_id                                                             As company_id, 
                                                  product_masters.oldcode                                                                As oldcode, 
                                                  product_masters.product_image_url                                                      As product_image_url,
                                                  product_masters.status                                                                 As status,
                                                  product_masters.unittype_id                                                            As unittype_id,
                                                  unit_types.unit_name                                                                   As unit_name,
                                                  product_masters.pics_qty                                                               As pics_qty,
                                                  productComponent.*,
                                                  price_types.id                                                                         As pricetype_id,

                                                  price_types.price_name                                                      As price_name,
                                                  IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                  IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                  IFNULL(inventories.quantity, 0)                                             AS stock,
                                                  CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                  IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                           ( SELECT  product_prices.product_price FROM  product_prices 
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                              WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                          FROM  product_masters 
                                                LEFT JOIN 

                                            (SELECT n.product_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                FROM (

                                                        SELECT  product_components.product_id                                             As product_id,
                                                                component_masters.component_id                                            As component_id,
                                                                component_group_masters.group_name                                        As group_name,
                                                                component_group_masters.id                                                As component_group_id,
                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                component_masters.component_name                                          As component_name
                                                          FROM component_group_masters
                                                          INNER JOIN component_masters
                                                            ON component_group_masters.id=component_masters.component_group_id
                                                          INNER JOIN product_components 
                                                            ON product_components.component_id=component_masters.component_id) n
                                                          GROUP BY n.product_id 
                                                      ) AS productComponent

                                                    ON product_masters.product_id=productComponent.product_id
                                                  LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                  LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                                  LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                  INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                     WHERE inventories.owner_id=1 AND product_prices.price_id=1
                            GROUP BY product_masters.product_id) AS currentStock


 
                    ";


    $baseQuery2 = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$endDate'
                              GROUP BY chalan_details.product_id ) AS receiveStock

                                ON currentStock.currentstock_product_id=receiveStock.product_id ";


    $baseQuery2n = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$current_dt'
                              GROUP BY chalan_details.product_id ) AS mreceiveStock

                                ON currentStock.currentstock_product_id=mreceiveStock.product_id ";


    $baseQuery3 = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate' 
                          GROUP BY sales_details.product_id) as sales
                        ON currentStock.currentstock_product_id= sales.product_id ";


    $baseQuery3n = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt' 
                          GROUP BY sales_details.product_id) as msales
                        ON currentStock.currentstock_product_id= msales.product_id ";


    $baseQuery4 = " LEFT JOIN  (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'
                              GROUP BY sales_return_details.product_id) AS saleReturn

                             ON currentStock.currentstock_product_id= saleReturn.product_id ";
    $baseQuery4n = "   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$current_dt' 
                              GROUP BY sales_return_details.product_id) AS msaleReturn

                             ON currentStock.currentstock_product_id= msaleReturn.product_id ";


    $finalQuery = $baseQuery . $baseQuery2 . $baseQuery2n . $baseQuery3 . $baseQuery3n . $baseQuery4 . $baseQuery4n;

    // return response()->json($finalQuery);
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }



    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $finalQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($finalQuery);

    $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];

    return response()->json($stockList);
  }



  public function GetClosingStockLedgerDetailBackup(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";
    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';

    $baseQuery = " 
          

SELECT currentStock.product_id, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,

                    ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty ,


                          IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                            IFNULL(sales.sale_quantity,0) AS sale_qty,
                             IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                          (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,

                          (( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) ) * currentStock.product_price  AS ClosingDp,
                          --  ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                          IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                          IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                          currentStock.* FROM








                          (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                product_masters.barcode                                                                As barcode,
                                                product_masters.product_code                                                           As product_code,
                                                product_masters.name                                                                   As name,
                                                product_masters.bn_name                                                                As bn_name,
                                                product_masters.company_id                                                             As company_id, 
                                                product_masters.oldcode                                                                As oldcode, 
                                                product_masters.product_image_url                                                      As product_image_url,
                                                product_masters.status                                                                 As status,
                                                product_masters.unittype_id                                                            As unittype_id,
                                                unit_types.unit_name                                                                   As unit_name,
                                                product_masters.pics_qty                                                               As pics_qty,
                                                productComponent.*,
                                                price_types.id                                                                         As pricetype_id,

                                                price_types.price_name                                                      As price_name,
                                                IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                IFNULL(inventories.quantity, 0)                                             AS stock,
                                                CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                         ( SELECT  product_prices.product_price FROM  product_prices 
                                                LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                            WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                        FROM  product_masters 
                                              LEFT JOIN 

                                          (SELECT n.product_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                 MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                 MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                              FROM (

                                                      SELECT  product_components.product_id                                             As product_id,
                                                              component_masters.component_id                                            As component_id,
                                                              component_group_masters.group_name                                        As group_name,
                                                              component_group_masters.id                                                As component_group_id,
                                                              component_group_masters.cgroup_code                                       As cgroup_code,
                                                              component_masters.component_name                                          As component_name
                                                        FROM component_group_masters
                                                        INNER JOIN component_masters
                                                          ON component_group_masters.id=component_masters.component_group_id
                                                        INNER JOIN product_components 
                                                          ON product_components.component_id=component_masters.component_id) n
                                                        GROUP BY n.product_id 
                                                    ) AS productComponent

                                                  ON product_masters.product_id=productComponent.product_id
                                                LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                                LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                   WHERE inventories.owner_id=1 AND product_prices.price_id=1
                          GROUP BY product_masters.product_id) AS currentStock



                  ";


    $baseQuery2 = "
                      LEFT JOIN
                      (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                            FROM chalan_details
                            INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                            WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$endDate'
                            GROUP BY chalan_details.product_id ) AS receiveStock

                              ON currentStock.currentstock_product_id=receiveStock.product_id ";


    $baseQuery2n = "
                      LEFT JOIN
                      (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                            FROM chalan_details
                            INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                            WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$current_dt'
                            GROUP BY chalan_details.product_id ) AS mreceiveStock

                              ON currentStock.currentstock_product_id=mreceiveStock.product_id ";


    $baseQuery3 = "  LEFT JOIN

                      (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                        INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                        WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate' and sales_masters.company_id=1
                        GROUP BY sales_details.product_id) as sales
                      ON currentStock.currentstock_product_id= sales.product_id ";


    $baseQuery3n = "  LEFT JOIN

                      (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                        INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                        WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt' and sales_masters.company_id=1
                        GROUP BY sales_details.product_id) as msales
                      ON currentStock.currentstock_product_id= msales.product_id ";


    $baseQuery4 = " LEFT JOIN  (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                            INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                            WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'
                            GROUP BY sales_return_details.product_id) AS saleReturn

                           ON currentStock.currentstock_product_id= saleReturn.product_id ";
    $baseQuery4n = "   LEFT JOIN
                          (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                            INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                            WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$current_dt' 
                            GROUP BY sales_return_details.product_id) AS msaleReturn

                           ON currentStock.currentstock_product_id= msaleReturn.product_id ";


    $finalQuery = $baseQuery . $baseQuery2 . $baseQuery2n . $baseQuery3 . $baseQuery3n . $baseQuery4 . $baseQuery4n;

    // return response()->json($finalQuery);
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }



    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $finalQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($finalQuery);

    $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];

    return response()->json($stockList);
  }












  public function GetClosingStockDetail(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);


    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';



    $baseQuery = "         SELECT currentStock.product_id, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,
  
                        ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0)) +IFNULL( receiveStock.quantity_purchase,0) - IFNULL(sales.sale_quantity,0) + IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty,
  
  
                            IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                              IFNULL(sales.sale_quantity,0) AS sale_qty,
                               IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                            (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,
                              ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                            IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                            IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                            currentStock.* FROM



                            (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                  product_masters.barcode                                                                As barcode,
                                                  product_masters.product_code                                                           As product_code,
                                                  product_masters.name                                                                   As name,
                                                  product_masters.bn_name                                                                As bn_name,
                                                  product_masters.company_id                                                             As company_id, 
                                                  product_masters.oldcode                                                                As oldcode, 
                                                  product_masters.product_image_url                                                      As product_image_url,
                                                  product_masters.status                                                                 As status,
                                                  product_masters.unittype_id                                                            As unittype_id,
                                                  unit_types.unit_name                                                                   As unit_name,
                                                  product_masters.pics_qty                                                               As pics_qty,
                                                  productComponent.*,
                                                  price_types.id                                                                         As pricetype_id,

                                                  price_types.price_name                                                      As price_name,
                                                  IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                  IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                  IFNULL(inventories.quantity, 0)                                             AS stock,
                                                  CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                  IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                           ( SELECT  product_prices.product_price FROM  product_prices 
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                              WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                          FROM  product_masters 
                                                LEFT JOIN 

                                            (SELECT n.product_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                FROM (

                                                        SELECT  product_components.product_id                                             As product_id,
                                                                component_masters.component_id                                            As component_id,
                                                                component_group_masters.group_name                                        As group_name,
                                                                component_group_masters.id                                                As component_group_id,
                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                component_masters.component_name                                          As component_name
                                                          FROM component_group_masters
                                                          INNER JOIN component_masters
                                                            ON component_group_masters.id=component_masters.component_group_id
                                                          INNER JOIN product_components 
                                                            ON product_components.component_id=component_masters.component_id) n
                                                          GROUP BY n.product_id 
                                                      ) AS productComponent

                                                    ON product_masters.product_id=productComponent.product_id
                                                  LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                  LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                  LEFT JOIN price_types ON product_prices.price_id=1
                                                  LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                  INNER JOIN inventories ON product_masters.product_id=inventories.product_id

                            GROUP BY product_masters.product_id) AS currentStock         ";
    $baseQuery2 = "
                        LEFT JOIN
                        ( SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1 AND chalan_date   BETWEEN '$startDate' and '$endDate'
                              GROUP BY chalan_details.product_id ) AS receiveStock

                                ON currentStock.currentstock_product_id=receiveStock.product_id ";

    $baseQuery2n = "
                        LEFT JOIN
                        ( SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1 AND chalan_date   BETWEEN '$startDate' and '$current_dt'
                              GROUP BY chalan_details.product_id ) AS mreceiveStock

                                ON currentStock.currentstock_product_id=mreceiveStock.product_id ";


    $baseQuery3 = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'
                          GROUP BY sales_details.product_id) as sales

                        ON currentStock.currentstock_product_id= sales.product_id ";

    $baseQuery3n = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt'
                          GROUP BY sales_details.product_id) as msales

                        ON currentStock.currentstock_product_id= msales.product_id ";


    $baseQuery4 = "   LEFT JOIN
                            (   SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'
                              GROUP BY sales_return_details.product_id) AS saleReturn

                             ON currentStock.currentstock_product_id= saleReturn.product_id ";

    $baseQuery4n = "   LEFT JOIN
                            ( SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$current_dt'
                              GROUP BY sales_return_details.product_id) AS msaleReturn

                             ON currentStock.currentstock_product_id= msaleReturn.product_id ";


    $finalQuery = $baseQuery . $baseQuery2 . $baseQuery2n . $baseQuery3 . $baseQuery3n . $baseQuery4 . $baseQuery4n;

    // return response()->json($finalQuery);
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }



    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $finalQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($finalQuery);

    // $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($productsList);
  }

  public function GetClosingStockSummaryBrandWiseBackup(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");


    //   $dating = $request->get('start_date');
    //  return response()->json($dating);


    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT   SUM(currentStock.stock)  - IFNULL(SUM(mreceiveStock.quantity_purchase),0)  + IFNULL(SUM(msales.sale_quantity),0) - IFNULL(SUM(msaleReturn.sale_return_quantity),0) AS OpeningQty,
  
                        ( SUM(currentStock.stock)  - IFNULL(SUM(mreceiveStock.quantity_purchase),0)  + IFNULL(SUM(msales.sale_quantity),0) - IFNULL(SUM(msaleReturn.sale_return_quantity),0))  +IFNULL(SUM(receiveStock.quantity_purchase),0) - IFNULL(SUM(sales.sale_quantity),0) + IFNULL(SUM(saleReturn.sale_return_quantity),0) as ClosingQty,
  
  
                           IFNULL(sum(receiveStock.quantity_purchase),0) AS receive_qty,

                             IFNULL(SUM(sales.sale_quantity),0) AS sale_qty,
                              IFNULL(sum(saleReturn.sale_return_quantity),0) AS sale_return_qty,
                           ( SUM(currentStock.stock)- IFNULL(sum( receiveStock.quantity_purchase),0) +IFNULL(SUM(sales.sale_quantity),0)-IFNULL( SUM(saleReturn.sale_return_quantity),0))+ (IFNULL(sum(receiveStock.quantity_purchase),0)+IFNULL(sum(saleReturn.sale_return_quantity),0))-    IFNULL(sum(sales.sale_quantity),0)  AS ClosingQty1,
                              (  ( SUM(currentStock.stock)  - IFNULL(SUM(mreceiveStock.quantity_purchase),0)  + IFNULL(SUM(msales.sale_quantity),0) - IFNULL(SUM(msaleReturn.sale_return_quantity),0))  +IFNULL(SUM(receiveStock.quantity_purchase),0) - IFNULL(SUM(sales.sale_quantity),0) + IFNULL(SUM(saleReturn.sale_return_quantity),0))* currentStock.product_price  AS ClosingDp,
                            IFNULL(sum(receiveStock.quantity_purchase),0) AS quantity_purchase, IFNULL(sum(receiveStock.ctn_quantity_purchase),0) AS ctn_quantity_purchase, 

                           IFNULL( sum(receiveStock.purchase_netamount),0) AS purchase_netamount ,

                           currentStock.subbrand_name FROM








                            (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                  product_masters.barcode                                                                As barcode,
                                                  product_masters.product_code                                                           As product_code,
                                                  product_masters.name                                                                   As name,
                                                  product_masters.bn_name                                                                As bn_name,
                                                  product_masters.company_id                                                             As company_id, 
                                                  product_masters.oldcode                                                                As oldcode, 
                                                  product_masters.product_image_url                                                      As product_image_url,
                                                  product_masters.status                                                                 As status,
                                                  product_masters.unittype_id                                                            As unittype_id,
                                                  unit_types.unit_name                                                                   As unit_name,
                                                  product_masters.pics_qty                                                               As pics_qty,
                                                  productComponent.*,
                                                  price_types.id                                                                         As pricetype_id,

                                                  price_types.price_name                                                      As price_name,
                                                  IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                  IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                  IFNULL(inventories.quantity, 0)                                             AS stock,
                                                  CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                  IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                           ( SELECT  product_prices.product_price FROM  product_prices 
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                              WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                          FROM  product_masters 
                                                LEFT JOIN 

                                            (SELECT n.product_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                FROM (

                                                        SELECT  product_components.product_id                                             As product_id,
                                                                component_masters.component_id                                            As component_id,
                                                                component_group_masters.group_name                                        As group_name,
                                                                component_group_masters.id                                                As component_group_id,
                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                component_masters.component_name                                          As component_name
                                                          FROM component_group_masters
                                                          INNER JOIN component_masters
                                                            ON component_group_masters.id=component_masters.component_group_id
                                                          INNER JOIN product_components 
                                                            ON product_components.component_id=component_masters.component_id) n
                                                          GROUP BY n.product_id 
                                                      ) AS productComponent

                                                    ON product_masters.product_id=productComponent.product_id
                                                  LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                  LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                                  LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                  INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                        WHERE inventories.owner_id=1 AND product_prices.price_id=1
                            GROUP BY product_masters.product_id) AS currentStock


 
                    ";


    $baseQuery2 = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1 AND chalan_masters.company_id=1 AND  chalan_date   BETWEEN '$startDate' and '$endDate'
                              GROUP BY chalan_details.product_id ) AS receiveStock

                                ON currentStock.currentstock_product_id=receiveStock.product_id ";


    $baseQuery2n = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1 AND chalan_masters.company_id=1 AND  chalan_date   BETWEEN '$startDate' and '$current_dt'
                              GROUP BY chalan_details.product_id ) AS mreceiveStock

                                ON currentStock.currentstock_product_id=mreceiveStock.product_id ";


    $baseQuery3 = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'  and sales_masters.company_id=1
                          GROUP BY sales_details.product_id) as sales

                        ON currentStock.currentstock_product_id= sales.product_id ";


    $baseQuery3n = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt'  and sales_masters.company_id=1
                          GROUP BY sales_details.product_id) as msales

                        ON currentStock.currentstock_product_id= msales.product_id ";


    $baseQuery4 = "   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_masters 
                              INNER JOIN sales_return_details ON sales_masters.id=sales_return_details.salesmaster_id
                              WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'  and sales_masters.company_id=1
                              GROUP BY sales_return_details.product_id) AS saleReturn

                             ON currentStock.currentstock_product_id= saleReturn.product_id ";


    $baseQuery4n = "   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_masters 
                              INNER JOIN sales_return_details ON sales_masters.id=sales_return_details.salesmaster_id
                              WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt'  and sales_masters.company_id=1
                              GROUP BY sales_return_details.product_id) AS msaleReturn

                             ON currentStock.currentstock_product_id= msaleReturn.product_id ";



    $finalQuery = $baseQuery . $baseQuery2 . $baseQuery2n . $baseQuery3 . $baseQuery3n . $baseQuery4 . $baseQuery4n;


    // return response()->json($finalQuery);
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " brand_id = '$brand_id' ";
    }
    if ($category_id > 0) {
      $dynamicSql[] = " category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " packaging_id = '$package_id' ";
    }



    if (strlen($pname) != 0) {
      $dynamicSql[] = " name like '$product_name' ";
    }
    if (count($dynamicSql) != 0) {
      $finalQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($finalQuery . " GROUP by currentStock.subbrand_name");

    $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];

    return response()->json($stockList);
  }



  public function GetClosingStockSummaryBrandWise(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");


    //   $dating = $request->get('start_date');
    //  return response()->json($dating);


    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';

    $baseQuery = " 
          
SELECT Sumarry.subbrand_name,Sumarry.subbrand_id, SUM(Sumarry.OpeningQty) as OpeningQty, SUM(Sumarry.receive_qty) as receive_qty, sum(Sumarry.sale_qty) as sale_qty, sum(Sumarry.sale_return_qty) as sale_return_qty, sum(Sumarry.ClosingQty) as ClosingQty,  SUM(Sumarry.ClosingDp) as ClosingDp FROM

(SELECT currentStock.productid3 as product_id, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,
  
                      ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty ,
                      (( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0))/ IFNULL(currentStock.pics_qty,0) as ClosingQtn ,
  
  
                            IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                              IFNULL(sales.sale_quantity,0) AS sale_qty,
                               IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                            (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,

                            (( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) ) * currentStock.product_price  AS ClosingDp,
                            --  ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                            IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                            IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                            currentStock.* FROM








                            (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                  product_masters.barcode                                                                As barcode,
                                                  product_masters.product_code                                                           As product_code,
                                                  product_masters.name                                                                   As name,
                                                  product_masters.bn_name                                                                As bn_name,
                                                  product_masters.company_id                                                             As company_id, 
                                                  product_masters.oldcode                                                                As oldcode, 
                                                  product_masters.product_image_url                                                      As product_image_url,
                                                  product_masters.status                                                                 As status,
                                                  product_masters.unittype_id                                                            As unittype_id,
                                                  unit_types.unit_name                                                                   As unit_name,
                                                  product_masters.pics_qty                                                               As pics_qty,
                                                  productComponent.*,
                                                  price_types.id                                                                         As pricetype_id,

                                                  price_types.price_name                                                      As price_name,
                                                  IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                  IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                  IFNULL(inventories.quantity, 0)                                             AS stock,
                                                  CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                  IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                           ( SELECT  product_prices.product_price FROM  product_prices 
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                              WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                          FROM  product_masters 
                                                LEFT JOIN 

                                            (SELECT n.product_id2 as productid3,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                FROM (

                                                        SELECT  product_components.product_id                                             As product_id2,
                                                                component_masters.component_id                                            As component_id,
                                                                component_group_masters.group_name                                        As group_name,
                                                                component_group_masters.id                                                As component_group_id,
                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                component_masters.component_name                                          As component_name
                                                          FROM component_group_masters
                                                          INNER JOIN component_masters
                                                            ON component_group_masters.id=component_masters.component_group_id
                                                          INNER JOIN product_components 
                                                            ON product_components.component_id=component_masters.component_id) n
                                                          GROUP BY n.product_id2 
                                                      ) AS productComponent

                                                    ON product_masters.product_id=productComponent.productid3
                                                  LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                  LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                                  LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                  INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                     WHERE inventories.owner_id=1 AND product_prices.price_id=1
                            GROUP BY product_masters.product_id) AS currentStock


 
            


      
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$endDate' 
                              GROUP BY chalan_details.product_id ) AS receiveStock

                                ON currentStock.currentstock_product_id=receiveStock.product_id 


  
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$current_dt' 
                              GROUP BY chalan_details.product_id ) AS mreceiveStock

                                ON currentStock.currentstock_product_id=mreceiveStock.product_id 


    LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'
                          GROUP BY sales_details.product_id) as sales
                        ON currentStock.currentstock_product_id= sales.product_id 


     LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt'  
                          GROUP BY sales_details.product_id) as msales
                        ON currentStock.currentstock_product_id= msales.product_id 


    LEFT JOIN  (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'
                              GROUP BY sales_return_details.product_id) AS saleReturn

                             ON currentStock.currentstock_product_id= saleReturn.product_id 
   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                              INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                              WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$current_dt'
                              GROUP BY sales_return_details.product_id) AS msaleReturn

                             ON currentStock.currentstock_product_id= msaleReturn.product_id ) as Sumarry


GROUP BY Sumarry.subbrand_name


 
                    ";


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery);

    $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];

    return response()->json($stockList);
  }



  public function GetClosingStockSummaryBrandWiseBackupR(Request $request)
  {


    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");


    //   $dating = $request->get('start_date');
    //  return response()->json($dating);


    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    $product_name = '%' . $pname . '%';

    $baseQuery = " 
          SELECT  op.subbrand_name,op.subbrand_id,sum(op.ClosingQty) as ClosingQty ,sum(op.OpeningQty) as OpeningQty,sum(op.receive_qty) as receive_qty,sum(op.sale_qty) as sale_qty,sum(op.sale_return_qty) as sale_return_qty,  sum(op.ClosingDp) as ClosingDp FROM ( SELECT currentStock.product_id12, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,

                    ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty ,


                          IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                            IFNULL(sales.sale_quantity,0) AS sale_qty,
                             IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                          (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,
                            ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                          IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                          IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                          currentStock.subbrand_name,currentStock.subbrand_id FROM







                          (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                product_masters.barcode                                                                As barcode,
                                                product_masters.product_code                                                           As product_code,
                                                product_masters.name                                                                   As name,
                                                product_masters.bn_name                                                                As bn_name,
                                                product_masters.company_id                                                             As company_id, 
                                                product_masters.oldcode                                                                As oldcode, 
                                                product_masters.product_image_url                                                      As product_image_url,
                                                product_masters.status                                                                 As status,
                                                product_masters.unittype_id                                                            As unittype_id,
                                                unit_types.unit_name                                                                   As unit_name,
                                                product_masters.pics_qty                                                               As pics_qty,
                                                productComponent.*,
                                                price_types.id                                                                         As pricetype_id,

                                                price_types.price_name                                                      As price_name,
                                                IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                IFNULL(inventories.quantity, 0)                                             AS stock,
                                                CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                         ( SELECT  product_prices.product_price FROM  product_prices 
                                                LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                            WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                        FROM  product_masters 
                                              LEFT JOIN 

                                          (SELECT n.product_id12,
                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                 MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                 MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                              FROM (

                                                      SELECT  product_components.product_id                                             As product_id12,
                                                              component_masters.component_id                                            As component_id,
                                                              component_group_masters.group_name                                        As group_name,
                                                              component_group_masters.id                                                As component_group_id,
                                                              component_group_masters.cgroup_code                                       As cgroup_code,
                                                              component_masters.component_name                                          As component_name
                                                        FROM component_group_masters
                                                        INNER JOIN component_masters
                                                          ON component_group_masters.id=component_masters.component_group_id
                                                        INNER JOIN product_components 
                                                          ON product_components.component_id=component_masters.component_id) n
                                                        GROUP BY n.product_id12 
                                                    ) AS productComponent

                                                  ON product_masters.product_id=productComponent.product_id12
                                                LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                LEFT JOIN price_types ON product_prices.price_id=1
                                                LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                      WHERE inventories.owner_id=1 
                          GROUP BY product_masters.product_id) AS currentStock



              



                      LEFT JOIN
                      (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                            FROM chalan_details
                            INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                            WHERE chalan_masters.chalan_type=1 AND chalan_masters.company_id=1 AND  chalan_date   BETWEEN '$startDate' and '$endDate'
                            GROUP BY chalan_details.product_id ) AS receiveStock

                              ON currentStock.currentstock_product_id=receiveStock.product_id 


                      LEFT JOIN
                      (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                            FROM chalan_details
                            INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                            WHERE chalan_masters.chalan_type=1 AND chalan_masters.company_id=1 AND  chalan_date   BETWEEN '$startDate' and '$current_dt'
                            GROUP BY chalan_details.product_id ) AS mreceiveStock

                              ON currentStock.currentstock_product_id=mreceiveStock.product_id 


    LEFT JOIN

                      (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                        INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                        WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate'  and sales_masters.company_id=1
                        GROUP BY sales_details.product_id) as sales

                      ON currentStock.currentstock_product_id= sales.product_id 


      LEFT JOIN

                      (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                        INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                        WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt'  and sales_masters.company_id=1
                        GROUP BY sales_details.product_id) as msales

                      ON currentStock.currentstock_product_id= msales.product_id 


    LEFT JOIN
                          (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                            INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                            WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$endDate'  and sales_return_masters.company_id=1
                            GROUP BY sales_return_details.product_id) AS saleReturn

                           ON currentStock.currentstock_product_id= saleReturn.product_id 


   LEFT JOIN
                          (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_return_masters 
                            INNER JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
                            WHERE sales_return_masters.return_date BETWEEN '$startDate' and '$current_dt'  and sales_return_masters.company_id=1
                            GROUP BY sales_return_details.product_id) AS msaleReturn

                           ON currentStock.currentstock_product_id= msaleReturn.product_id ) as op

          GROUP BY op.subbrand_name




                  ";


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery);

    $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];

    return response()->json($stockList);
  }






  public function getParticularTypeAhend($query)
  {

    $distributor = '%' . $query . '%';
    $data = DB::select("SELECT *FROM particulars_masters WHERE particular_name LIKE ? ", [$distributor]);

    return response()->json($data);
  }

  public function getVatParticularTypeAhend($query)
  {

    $name = '%' . $query . '%';
    $data = DB::select("SELECT *FROM vat_particulars_masters WHERE particular_name LIKE ? ", [$name]);

    return response()->json($data);
  }

  public function getTargetAchivementSales(Request $request)
  {

    $year = $request->get("year");
    $month = $request->get("month");


    $query = "
SELECT targetView.*,  IFNULL(tempAsmSale.sale,0) AS Sale,IFNULL( (tempAsmSale.sale/targetView.target)*100,0) as Achivement FROM (SELECT employee_masters.name as asm_name,employee_masters.id as asmi_id,  component_masters.component_name as subbrand_name, brand_id, year,IFNULL(month,0) as month, sum(IFNULL(target,0)) as target 
                          FROM target_setup_masters


                          LEFT JOIN company_masters ON target_setup_masters.distributor_id=company_masters.id
                          LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                          LEFT JOIN component_masters ON component_masters.component_id=target_setup_masters.brand_id
  
                        --  LEFT JOIN 
  WHERE year= ? and month= ?
  GROUP BY asmi_id,brand_id) as targetView


  LEFT JOIN (SELECT employee_masters.name AS asm_namesale, employee_masters.id as asm_id,tempSale.subbrand_id, tempSale.subbrand_name,IFNULL( SUM(tempSale.Sale),0) as sale FROM
(SELECT sales_masters.sales_location_id, productview.subbrand_name,productview.subbrand_id, SUM(sales_details.netamount) as Sale FROM sales_details
                          INNER JOIN sales_masters ON sales_masters.id=salesmaster_id
                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As pid,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON sales_details.product_id=productview.product_id1
 WHERE  YEAR(sales_masters.sales_date)= ? and month(sales_masters.sales_date)= ? 
                          GROUP BY productview.subbrand_id,sales_location_id) as tempSale

  LEFT JOIN company_masters ON tempSale.sales_location_id=company_masters.id
            LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
  GROUP by asm_id,tempSale.subbrand_id) as tempAsmSale
  ON tempAsmSale.asm_id=targetView.asmi_id and tempAsmSale.subbrand_id=targetView.brand_id


";







    $data = DB::select($query, [$year, $month, $year, $month]);

    $targetAchivement[] = ['targetachivementlist' => $data];
    return response()->json($targetAchivement);
  }

  public function getTargetAchivementSalesASM(Request $request)
  {

    $year = $request->get("year");
    $month = $request->get("month");

    $query = "
            
SELECT finalTarget.asm_namesale as asm_name, finalTarget.asm_id, finalTarget.subbrand_name, sum(finalTarget.sale) as Sale, sum(finalTarget.target) as target,IFNULL( ((sum(finalTarget.sale) / sum(finalTarget.target))*100),0) AS Achivement  FROM 





(SELECT employee_masters.name AS asm_namesale, employee_masters.id as asm_id,tempSale.subbrand_id, tempSale.subbrand_name,IFNULL( SUM(tempSale.Sale),0) as sale, 0 as target FROM
                (SELECT sales_masters.sales_location_id, productview.subbrand_name,productview.subbrand_id, SUM(sales_details.netamount) as Sale FROM sales_details
                          INNER JOIN sales_masters ON sales_masters.id=salesmaster_id
                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As pid,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON sales_details.product_id=productview.product_id1
            WHERE month(sales_masters.sales_date)=? and YEAR(sales_masters.sales_date)=?
                          GROUP BY productview.subbrand_id,sales_location_id) as tempSale

            LEFT JOIN company_masters ON tempSale.sales_location_id=company_masters.id
            LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
            GROUP by asm_id,tempSale.subbrand_id

  UNION ALL








SELECT employee_masters.name as asm_namesale, employee_masters.id  as asm_id  , target_setup_masters.brand_id as subbrand_id, component_masters.component_name as subbrand_name,0 as sale, target
                          FROM target_setup_masters


                          LEFT JOIN company_masters ON target_setup_masters.distributor_id=company_masters.id
                          LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                          LEFT JOIN component_masters ON component_masters.component_id=target_setup_masters.brand_id
                         
  
                        --  LEFT JOIN 
                WHERE   month=? and year=?)


  AS finalTarget

  GROUP BY finalTarget.asm_id,finalTarget.subbrand_name


            ";


    $data = DB::select($query, [$month, $year, $month, $year]);
    $targetAchivement[] = ['targetachivementlist' => $data];
    return response()->json($targetAchivement);
  }

  public function getTargetAchivementSalesASMBackUp(Request $request)
  {

    $year = $request->get("year");
    $month = $request->get("month");

    $query = "SELECT targetView.*,  IFNULL(tempAsmSale.sale,0) AS Sale,IFNULL( (tempAsmSale.sale/targetView.target)*100,0) as Achivement FROM (SELECT employee_masters.name as asm_name,employee_masters.id as asmi_id,  component_masters.component_name as subbrand_name, brand_id, year,IFNULL(month,0) as month, sum(IFNULL(target,0)) as target 
                          FROM target_setup_masters


                          LEFT JOIN company_masters ON target_setup_masters.distributor_id=company_masters.id
                          LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                          LEFT JOIN component_masters ON component_masters.component_id=target_setup_masters.brand_id
  
                        --  LEFT JOIN 
                WHERE   month=? and year=?
                GROUP BY asmi_id,brand_id) as targetView


                LEFT JOIN (SELECT employee_masters.name AS asm_namesale, employee_masters.id as asm_id,tempSale.subbrand_id, tempSale.subbrand_name,IFNULL( SUM(tempSale.Sale),0) as sale FROM
                (SELECT sales_masters.sales_location_id, productview.subbrand_name,productview.subbrand_id, SUM(sales_details.netamount) as Sale FROM sales_details
                          INNER JOIN sales_masters ON sales_masters.id=salesmaster_id
                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As pid,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON sales_details.product_id=productview.product_id1
            WHERE month(sales_masters.sales_date)=? and YEAR(sales_masters.sales_date)=?
                          GROUP BY productview.subbrand_id,sales_location_id) as tempSale

            LEFT JOIN company_masters ON tempSale.sales_location_id=company_masters.id
            LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
            GROUP by asm_id,tempSale.subbrand_id) as tempAsmSale
            ON tempAsmSale.asm_id=targetView.asmi_id and tempAsmSale.subbrand_id=targetView.brand_id
            ";


    $data = DB::select($query, [$month, $year, $month, $year]);
    $targetAchivement[] = ['targetachivementlist' => $data];
    return response()->json($targetAchivement);
  }

  public function getTargetAchivementSalesASMSummary(Request $request)
  {

    $year = $request->get("year");
    $month = $request->get("month");

    $query = "SELECT targetView.*,  IFNULL(tempAsmSale.sale,0) AS Sale,IFNULL( (tempAsmSale.sale/targetView.target)*100,0) as Achivement FROM (SELECT employee_masters.name as asm_name,employee_masters.id as asmi_id,  component_masters.component_name as subbrand_name, brand_id, year,IFNULL(month,0) as month, sum(IFNULL(target,0)) as target 
                          FROM target_setup_masters


                          LEFT JOIN company_masters ON target_setup_masters.distributor_id=company_masters.id
                          LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                          LEFT JOIN component_masters ON component_masters.component_id=target_setup_masters.brand_id
  
                        --  LEFT JOIN 
                WHERE   month=? and year=?
                GROUP BY asmi_id,brand_id) as targetView


                LEFT JOIN (SELECT employee_masters.name AS asm_namesale, employee_masters.id as asm_id,tempSale.subbrand_id, tempSale.subbrand_name,IFNULL( SUM(tempSale.Sale),0) as sale FROM
                (SELECT sales_masters.sales_location_id, productview.subbrand_name,productview.subbrand_id, SUM(sales_details.netamount) as Sale FROM sales_details
                          INNER JOIN sales_masters ON sales_masters.id=salesmaster_id
                            INNER JOIN

                                            (Select  product_masters.product_id                                                             As pid,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status,
                                                                    product_masters.unittype_id                                                            As unittype_id,

                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*



                                                            FROM  product_masters 
                                                                  LEFT JOIN 

                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                  FROM (

                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent

                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                                              ON sales_details.product_id=productview.product_id1
            WHERE month(sales_masters.sales_date)=? and YEAR(sales_masters.sales_date)=?
                          GROUP BY productview.subbrand_id,sales_location_id) as tempSale

            LEFT JOIN company_masters ON tempSale.sales_location_id=company_masters.id
            LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                          LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
            GROUP by asm_id,tempSale.subbrand_id) as tempAsmSale
            ON tempAsmSale.asm_id=targetView.asmi_id and tempAsmSale.subbrand_id=targetView.brand_id";


    $data = DB::select($query, [$month, $year, $month, $year]);
    $targetAchivement[] = ['targetachivementlist' => $data];
    return response()->json($targetAchivement);
  }

  public function getPartyLedgerList(Request $request)
  {

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "SELECT  SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (SELECT party_ledger_masters.company_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE party_ledger_masters.distributor_id=? AND (transaction_date  < ? )
                                  UNION ALL
                                SELECT claim_damage_collection_masters.company_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                FROM claim_damage_collection_masters
                                LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                               WHERE claim_damage_collection_masters.distributor_id=? AND (transaction_date  < ? )
                                UNION ALL
                                SELECT sales_location_id as company_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE sales_location_id=? and sales_date< ?
                             
                                UNION ALL
                                              SELECT distribution_node_id as company_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                WHERE distribution_node_id=? and return_date<  ?
                                ORDER BY transaction_date


) as partyledger";

    $baseQuery2 = "SELECT party_ledger_masters.company_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.tracking_no as reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                              LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE distributor_id=?
                               AND (transaction_date BETWEEN   ? AND  ? )

                               UNION ALL SELECT claim_damage_collection_masters.company_id,
                               claim_damage_collection_masters.particulars,
                               claim_damage_collection_masters.remarks,
                               claim_damage_collection_masters.reference,
                               claim_damage_collection_masters.transaction_date,
                               claim_damage_collection_masters.debit,
                               claim_damage_collection_masters.credit 
                               FROM claim_damage_collection_masters
                                 LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id

                                              WHERE claim_damage_collection_masters.distributor_id=?
                               AND (transaction_date BETWEEN   ? AND  ? )

                                UNION ALL

                                SELECT sales_location_id as company_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters

                                WHERE sales_location_id=?
                                AND (sales_date BETWEEN  ? AND  ? )
                              
                                
                                 UNION ALL
                                SELECT distribution_node_id as company_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount  as credit  FROM sales_return_masters

                                WHERE distribution_node_id=?
                                AND (return_date BETWEEN    ? AND   ? )

                                ORDER BY transaction_date

";


    $baseQuery3 = " SELECT company_masters.*,distributor_masters.area_name FROM company_masters LEFT JOIN
                        distributor_masters ON company_masters.id=distributor_masters.company_id
                        WHERE company_masters.id=?";
    $baseQuery4 = "SELECT  distributor_masters.opening_balance 
                                    FROM distributor_masters LEFT JOIN company_masters ON company_masters.id=distributor_masters.company_id
                                    WHERE company_id= ?";




    $opening_balance = DB::select($baseQuery1, [$company_id, $startDate, $company_id, $startDate, $company_id, $startDate, $company_id, $startDate]);
    $partyLedgerList = DB::select($baseQuery2, [$company_id, $startDate, $endDate, $company_id, $startDate, $endDate, $company_id, $startDate, $endDate, $company_id, $startDate, $endDate]);
    $company_info = DB::select($baseQuery3, [$company_id]);
    $openingBalance = DB::select($baseQuery4, [$company_id]);
    $finalBalance = (isset($opening_balance[0]->balance) ? $opening_balance[0]->balance : 0) + (isset($openingBalance[0]->opening_balance) ? $openingBalance[0]->opening_balance : 0);

    $ledgerDetailList[] = ['opening_balance' => $finalBalance, 'customer_code' => $company_info[0]->code, 'customer_name' => $company_info[0]->name . ', ' . $company_info[0]->area_name, 'start_date' => $startDate, 'end_date' => $endDate, 'ledgerList' => $partyLedgerList];

    return response()->json($ledgerDetailList);
  }

  public function product_pricelist(Request $request)
  {

    $indentList = array();

    $query = "SELECT product_masters.name AS product_name, price_types.price_name,IFNULL( product_prices.product_price,0) as product_price FROM product_masters 
                    LEFT JOIN product_prices ON product_masters.product_id=product_prices.product_id
                    LEFT JOIN price_types ON product_prices.price_id=price_types.id
                    WHERE product_prices.price_id<>22
                    ";

    $invoiceDetails = DB::select($query);
    // $saleMaster = SalesMaster::where('invoice_no', $invoice_no)->first();
    $invoiceList[] = ['priceList' => $invoiceDetails];

    return response()->json($invoiceList);
  }

  public function getCurrentBalance(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $company_id = $request->get("company_id");

    // return response()->json($request->all());
    $baseQuery1 = "SELECT  SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (SELECT party_ledger_masters.company_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.company_id= company_masters.id
                                WHERE company_id=?
                                UNION ALL
                                SELECT sales_location_id as company_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE sales_location_id=?
                                ORDER BY transaction_date) as partyledger";




    $baseQuery4 = "SELECT  distributor_masters.opening_balance ,distributor_masters.credit_limit
                                    FROM distributor_masters LEFT JOIN company_masters ON company_masters.id=distributor_masters.company_id
                                    WHERE company_id= ?";




    // $opening_balance = DB::select($baseQuery1, [$company_id, $company_id]);

    $openingBalance = DB::select($baseQuery4, [$company_id]);

    // $currentBalance = $opening_balance[0]->balance ?: 0 + $openingBalance[0]->opening_balance ?: 0;
    //   $balance = $openingBalance[0]->credit_limit - $currentBalance;






    $query = "SELECT partyledger.distributor_id as company_id, SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (
                            SELECT party_ledger_masters.distributor_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE transaction_date  <? and party_ledger_masters.distributor_id=?
                                  UNION ALL
                                SELECT claim_damage_collection_masters.distributor_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                FROM claim_damage_collection_masters
                                LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                               WHERE  transaction_date  <? and claim_damage_collection_masters.distributor_id=?
                                UNION ALL
                                SELECT sales_location_id as distributor_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE  sales_date<? and sales_location_id=?
                                 UNION ALL

                                SELECT distribution_node_id as distributor_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                WHERE  return_date<? and distribution_node_id=?

                                ORDER BY transaction_date) as partyledger
                    GROUP BY partyledger.distributor_id
                ";
    $location_id = $company_id;
    // $netamount = $invoiceDetails[0]->total_netamount;

    $current_dts = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $endDate = $current_dts->format("Y/m/d H:i") . " 23:59:59";

    $data = DB::select($query, [$endDate, $location_id, $endDate, $location_id, $endDate, $location_id, $endDate, $location_id]);








    $party_balance = (isset($openingBalance[0]->opening_balance) ? $openingBalance[0]->opening_balance : 0) + (isset($data[0]->balance) ? $data[0]->balance : 0);















    return response()->json($party_balance);
  }

  public function getCollectionReport(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT company_masters.name as distributor_name, bank_masters.name as bank_name,cstomerBank.name as customer_bank_name, company_masters.code as distributor_code, employee_masters.name as area_name,party_ledger_masters.credit as amount,party_ledger_masters.particulars as mode, party_ledger_masters.* FROM party_ledger_masters
                            LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            LEFT JOIN distributor_masters ON company_masters.id= distributor_masters.company_id
                            LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                            LEFT JOIN bank_masters ON bank_masters.id=party_ledger_masters.bank_id
                            LEFT JOIN bank_masters as cstomerBank ON cstomerBank.id=party_ledger_masters.customer_bank_id
                            WHERE transaction_date BETWEEN ? AND ?";









    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }

  public function getCollectionReportPrint(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "  SELECT company_masters.name as distributor_name, bank_masters.name as bank_name,cstomerBank.name as customer_bank_name, company_masters.code as distributor_code, employee_masters.name as area_name,party_ledger_masters.credit as amount,party_ledger_masters.particulars as mode, party_ledger_masters.* FROM party_ledger_masters
                            LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            LEFT JOIN distributor_masters ON company_masters.id= distributor_masters.company_id
                            LEFT JOIN employee_masters ON distributor_masters.asm_id=employee_masters.id
                            LEFT JOIN bank_masters ON bank_masters.id=party_ledger_masters.bank_id
                            LEFT JOIN bank_masters as cstomerBank ON cstomerBank.id=party_ledger_masters.customer_bank_id
                            WHERE transaction_date BETWEEN ? AND ?";




    $collections = DB::select($baseQuery1, [$startDate, $endDate]);

    $ledgerDetailList[] = ['collectionList' => $collections];


    return response()->json($ledgerDetailList);
  }








  public function GetSalesReportSecondaryDetailAll(Request $request)
  {


    try {


      $asm_id = $request->get("asm_id");
      $sr_id = $request->get("sr_id");
      $company_id = $request->get("company_id");
      $brand_id = $request->get("brand_id");
      $category_id = $request->get("category_id");
      $group_id = $request->get("group_id");
      $subbrand_id = $request->get("subbrand_id");
      $variant_id = $request->get("variant_id");
      $size_id = $request->get("size_id");
      $package_id = $request->get("package_id");
      $pname = $request->get("product_name");
      $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
      $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

      //   $dating = $request->get('start_date');
      //  return response()->json($dating);
      $product_name = '%' . $pname . '%';

      $baseQuery = "    
        
       
        SELECT SalesView.DP , asr_name, address_a as address, area_name,dealer_code, SalesView.outlet_code, SalesView.asm_name,productview.barcode, productview.subbrand_id, productview.subbrand_name,  SalesView.supervisor_name, SalesView.bit_name, SalesView.outlet_name, SalesView.category as category_type,SalesView.outlet_type,   SalesView.company_name, productview.brand_name, productview.name as product_name,  productview.subgroup_name, SalesView.asm_name, SalesView.invoice_no, SalesView.TP, SalesView.sales_date, SalesView.transaction_date, SalesView.bit_id, SalesView.asr_id, SalesView.outlet_id, sum(SalesView.quantity) as quantity, sum(SalesView.ctn_quantity) ctn_quantity, sum(SalesView.discount_amount) as discount_amount, sum(SalesView.unit_price) as unit_price, SUM(SalesView.totalamount) as totalamount, SUM(SalesView.netamount) as netamount,SUM(SalesView.netamount)+SUM(SalesView.discount_amount) as total_amount FROM

        (    SELECT  employee_masters.name as asr_name,asm_id, distributor_masters.address_a , distributor_masters.area_name, company_masters.code as dealer_code  ,   product_prices.product_price AS DP,  company_masters.name AS company_name, bit_masters.bit_name as bit_name,outlet_masters.outlet_name,outlet_masters.outlet_code, outlet_masters.outlet_type, outlet_masters.category, svr.name as supervisor_name,  asm.name as asm_name, secondary_sales_masters.invoice_no, secondary_sales_details.unit_price as TP, secondary_sales_masters.owner_id, secondary_sales_masters.sales_date AS transaction_date,secondary_sales_masters.bit_id, secondary_sales_masters.asr_id, secondary_sales_masters.outlet_id, secondary_sales_details.* FROM secondary_sales_masters INNER JOIN secondary_sales_details
              ON secondary_sales_masters.id=secondary_sales_details.salesmaster_id
        
              LEFT JOIN 
        
              company_masters ON company_masters.id=secondary_sales_masters.owner_id
        
        LEFT JOIN bit_masters ON bit_masters.id=secondary_sales_masters.bit_id
        
        LEFT JOIN outlet_masters ON outlet_masters.id=secondary_sales_masters.outlet_id
        LEFT JOIN users ON users.id=secondary_sales_masters.asr_id
        LEFT JOIN employee_masters ON users.employee_id=employee_masters.id
        
        LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
        LEFT JOIN employee_masters AS asm ON asm.id=distributor_masters.asm_id
              LEFT JOIN employee_masters AS svr ON svr.id=distributor_masters.supervisor_id
        
        LEFT JOIN product_prices ON product_prices.product_id=secondary_sales_details.product_id AND product_prices.price_id=1
        
        
        WHERE secondary_sales_masters.sales_date BETWEEN ? and ? ) as SalesView
        
        LEFT JOIN
        
        
             (Select  product_masters.product_id                                                             As id1,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id, 
                                                        product_masters.oldcode                                                                As oldcode, 
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status1,
                                                        product_masters.unittype_id                                                            As unittype_id,
        
                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*
        
        
        
                                                FROM  product_masters 
                                                      LEFT JOIN 
        
                                                  (SELECT n.product_id1,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
        
                                                      FROM (
        
                                                              SELECT  product_components.product_id                                             As product_id1,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components 
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id1 
                                                            ) AS productComponent
        
                                                          ON product_masters.product_id=productComponent.product_id1) AS productview
        
                                  ON SalesView.product_id =productview.product_id1


        
        
                    ";
      $dynamicSql = (array) null;

      if ($brand_id > 0) {
        $dynamicSql[] = " SalesView.brand_id, = '$brand_id' ";
      }




      if ($asm_id > 0) {
        $dynamicSql[] = " SalesView.asm_id = '$asm_id' ";
      }


      if ($sr_id > 0) {
        $dynamicSql[] = " SalesView.asr_id = '$sr_id' ";
      }

      if ($category_id > 0) {
        $dynamicSql[] = " productview.category_id = '$category_id' ";
      }

      if ($group_id > 0) {
        $dynamicSql[] = " productview.group_id = '$group_id' ";
      }

      if ($subbrand_id > 0) {
        $dynamicSql[] = " productview.subbrand_id = '$subbrand_id' ";
      }


      if ($variant_id > 0) {
        $dynamicSql[] = " productview.variant_id = '$variant_id' ";
      }

      if ($size_id > 0) {
        $dynamicSql[] = " productview.size_id = '$size_id' ";
      }

      if ($package_id > 0) {
        $dynamicSql[] = " productview.packaging_id = '$package_id' ";
      }

      /* if ($request->get('start_date') && $request->get('end_date')) {


            // $startDate = $request->get('start_date') . " 00:00:00";
            // $endDate = $request->get('end_date') . " 23:59:59";
            $dynamicSql[] = " SalesReport.sales_date BETWEEN '$startDate' and '$endDate' ";
        }*/

      /* if (strlen($pname) != 0) {
          $dynamicSql[] = " name like '$product_name' ";
          } */
      if (count($dynamicSql) != 0) {
        $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
      }


      // return response()->json($baseQuery);
      // $baseQuery .= " GROUP BY product_masters.product_id";

      $productsList = DB::select($baseQuery . '      GROUP BY SalesView.salesmaster_id, SalesView.owner_id, SalesView.product_id

        ORDER BY SalesView.owner_id, SalesView.product_id DESC', [$startDate, $endDate]);
      // return response()->json($productsList);
      $salesList[] = ['company_name' => $productsList[0]->company_name, 'address' => $productsList[0]->address, 'start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];
      // return response()->json("SUCCESS!");
      return response()->json($salesList);
    } catch (\Exception $e) {

      return response()->json("ERRORMY" . $e->getMessage());
    }
  }







  public function GetSalesReportSecondaryDetailAllNew(Request $request)
  {


    try {


      $asm_id = $request->get("asm_id");
      $sr_id = $request->get("sr_id");
      $company_id = $request->get("company_id");
      $brand_id = $request->get("brand_id");
      $category_id = $request->get("category_id");
      $group_id = $request->get("group_id");
      $subbrand_id = $request->get("subbrand_id");
      $variant_id = $request->get("variant_id");
      $size_id = $request->get("size_id");
      $package_id = $request->get("package_id");
      $pname = $request->get("product_name");
      $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
      $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

      //   $dating = $request->get('start_date');
      //  return response()->json($dating);
      $product_name = '%' . $pname . '%';

      $baseQuery = "    
        
    
        SELECT tbl.*, IFNULL(tr.DP,0) as DP,IFNULL(tr.invoice_no,'') AS invoice_no, IFNULL( tr.quantity,0) as quantity, IFNULL(tr.ctn_quantity,0) as ctn_quantity,

      IFNULL(tr.sales_date,'') as sales_date,
      IFNULL(tr.totalamount,0) AS total_amount,
      IFNULL(tr.netamount,0) AS netamount,
      IFNULL(tr.discount_amount,0) AS discount_amount,
      IFNULL(tr.unit_price,0) AS TP
        
        FROM
        
        (SELECT 
         
         
           secondary_chalan_details.product_id,
                secondary_chalan_masters.tracking_no,
                secondary_chalan_masters.id as chalanmaster_id,
                company_masters.name as company_name,
              bit_masters.bit_name as bit_name,
              productview.barcode as barcode,
              productview.name as product_name,
              outlet_masters.outlet_name as outlet_name,
              outlet_masters.outlet_code,
                   asm.name as asm_name,
                   supervisor.name as supervisor_name,
                sr.name as asr_name,
                DATE(secondary_chalan_masters.indent_date)  as indent_date,
                secondary_chalan_masters.created_at as sync_datetime,
                outlet_masters.category as category_type,
                outlet_masters.outlet_type as outlet_type,
                DATE_FORMAT(secondary_chalan_masters.indent_date,'%l.%i %p') as indent_time,
                sum(secondary_chalan_details.quantity_indent) as quantity_indent,
                productview.subbrand_name as brand_name,
          
              sum(secondary_chalan_details.discount_amount_indent) as discount_amount_indent,
              sum(secondary_chalan_details.totalamount_indent) as netamount_indent,
             IFNULL(sum(quantity_salesorder),0) as quantity_salesorder,
             IFNULL(sum(totalamount_salesorder),0) as netamount_salesorder
          FROM secondary_chalan_masters 
        LEFT JOIN secondary_chalan_details on secondary_chalan_masters.id=secondary_chalan_details.chalanmaster_id
        
        LEFT JOIN company_masters on company_masters.id=secondary_chalan_masters.origin_location_id
        
        LEFT JOIN distributor_masters on distributor_masters.company_id=company_masters.id
        
        LEFT JOIN employee_masters as asm on asm.id=distributor_masters.asm_id
         LEFT JOIN bit_masters ON bit_masters.id=secondary_chalan_masters.bit_id
                
                LEFT JOIN outlet_masters ON outlet_masters.id=secondary_chalan_masters.outlet_id
        
        
        LEFT JOIN users on users.id=secondary_chalan_masters.asr_id
        
        LEFT JOIN employee_masters as sr on sr.id=users.employee_id
        
        LEFT JOIN employee_masters as supervisor on supervisor.id=distributor_masters.supervisor_id




        LEFT JOIN
                
                
                     (Select  product_masters.product_id                                                             As id1,
                                                                product_masters.barcode                                                                As barcode,
                                                                product_masters.product_code                                                           As product_code,
                                                                product_masters.name                                                                   As name,
                                                                product_masters.bn_name                                                                As bn_name,
                                                                product_masters.company_id                                                             As company_id, 
                                                                product_masters.oldcode                                                                As oldcode, 
                                                                product_masters.product_image_url                                                      As product_image_url,
                                                                product_masters.status                                                                 As status1,
                                                                product_masters.unittype_id                                                            As unittype_id,
                
                                                                product_masters.pics_qty                                                               As pics_qty,
                                                                productComponent.*
                
                
                
                                                        FROM  product_masters 
                                                              LEFT JOIN 
                
                                                          (SELECT n.product_id1,
                                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
                
                                                              FROM (
                
                                                                      SELECT  product_components.product_id                                             As product_id1,
                                                                              component_masters.component_id                                            As component_id,
                                                                              component_group_masters.group_name                                        As group_name,
                                                                              component_group_masters.id                                                As component_group_id,
                                                                              component_group_masters.cgroup_code                                       As cgroup_code,
                                                                              component_masters.component_name                                          As component_name
                                                                        FROM component_group_masters
                                                                        INNER JOIN component_masters
                                                                          ON component_group_masters.id=component_masters.component_group_id
                                                                        INNER JOIN product_components 
                                                                          ON product_components.component_id=component_masters.component_id) n
                                                                        GROUP BY n.product_id1 
                                                                    ) AS productComponent
                
                                                                  ON product_masters.product_id=productComponent.product_id1) AS productview
                
                                          ON secondary_chalan_details.product_id =productview.product_id1






        
        WHERE secondary_chalan_masters.indent_date  BETWEEN ? and ? AND secondary_chalan_masters.chalan_type=21
        
        GROUP BY chalanmaster_id, secondary_chalan_details.product_id) as tbl
        
        LEFT JOIN 
        
        
          (  SELECT 
                SalesView.product_id,
                SalesView.tracking_no,
                SalesView.chalanmaster_id,
        
                SalesView.DP , 
                asr_name, 
                address_a as address, 
                area_name,
                dealer_code, 
                SalesView.outlet_code, 
           
                productview.barcode, 
                productview.subbrand_id,
                productview.subbrand_name,  
                SalesView.supervisor_name, 
                SalesView.bit_name, 
                SalesView.outlet_name, 
                SalesView.category as category_type,
                SalesView.outlet_type,   
                SalesView.company_name, 
                productview.brand_name, 
                productview.name as product_name,  
                productview.subgroup_name, 
                SalesView.asm_name, 
                SalesView.invoice_no, 
                SalesView.TP, 
                SalesView.sales_date, 
                SalesView.transaction_date, 
                SalesView.bit_id, 
                SalesView.asr_id, 
                SalesView.outlet_id, 
                sum(SalesView.quantity) as quantity, 
                sum(SalesView.ctn_quantity) ctn_quantity, 
                sum(SalesView.discount_amount) as discount_amount, 
                sum(SalesView.unit_price) as unit_price, 
                SUM(SalesView.totalamount) as totalamount, 
                SUM(SalesView.netamount) as netamount,
                SUM(SalesView.netamount)+SUM(SalesView.discount_amount) as total_amount 
                FROM
        
                (    SELECT secondary_chalan_masters.tracking_no, secondary_sales_masters.chalanmaster_id,  employee_masters.name as asr_name,asm_id,asm.name AS asm_name, distributor_masters.address_a , distributor_masters.area_name, company_masters.code as dealer_code  ,   product_prices.product_price AS DP,  company_masters.name AS company_name, bit_masters.bit_name as bit_name,outlet_masters.outlet_name,outlet_masters.outlet_code, outlet_masters.outlet_type, outlet_masters.category, svr.name as supervisor_name, secondary_sales_masters.invoice_no, secondary_sales_details.unit_price as TP, secondary_sales_masters.owner_id, secondary_sales_masters.sales_date AS transaction_date,secondary_sales_masters.bit_id, secondary_sales_masters.asr_id, secondary_sales_masters.outlet_id, secondary_sales_details.* FROM secondary_sales_masters INNER JOIN secondary_sales_details
                      ON secondary_sales_masters.id=secondary_sales_details.salesmaster_id
                
                      LEFT JOIN 
                
                      company_masters ON company_masters.id=secondary_sales_masters.owner_id
        
        LEFT JOIN secondary_chalan_masters ON secondary_sales_masters.chalanmaster_id=secondary_chalan_masters.id
                
                LEFT JOIN bit_masters ON bit_masters.id=secondary_sales_masters.bit_id
                
                LEFT JOIN outlet_masters ON outlet_masters.id=secondary_sales_masters.outlet_id
                LEFT JOIN users ON users.id=secondary_sales_masters.asr_id
                LEFT JOIN employee_masters ON users.employee_id=employee_masters.id
                
                LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                LEFT JOIN employee_masters AS asm ON asm.id=distributor_masters.asm_id
                      LEFT JOIN employee_masters AS svr ON svr.id=distributor_masters.supervisor_id
                
                LEFT JOIN product_prices ON product_prices.product_id=secondary_sales_details.product_id AND product_prices.price_id=1
                
                
                WHERE secondary_sales_masters.sales_date BETWEEN ? and ? ) as SalesView
                
                LEFT JOIN
                
                
                     (Select  product_masters.product_id                                                             As id1,
                                                                product_masters.barcode                                                                As barcode,
                                                                product_masters.product_code                                                           As product_code,
                                                                product_masters.name                                                                   As name,
                                                                product_masters.bn_name                                                                As bn_name,
                                                                product_masters.company_id                                                             As company_id, 
                                                                product_masters.oldcode                                                                As oldcode, 
                                                                product_masters.product_image_url                                                      As product_image_url,
                                                                product_masters.status                                                                 As status1,
                                                                product_masters.unittype_id                                                            As unittype_id,
                
                                                                product_masters.pics_qty                                                               As pics_qty,
                                                                productComponent.*
                
                
                
                                                        FROM  product_masters 
                                                              LEFT JOIN 
                
                                                          (SELECT n.product_id1,
                                                                      MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                      MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                      MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                 MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
                
                                                              FROM (
                
                                                                      SELECT  product_components.product_id                                             As product_id1,
                                                                              component_masters.component_id                                            As component_id,
                                                                              component_group_masters.group_name                                        As group_name,
                                                                              component_group_masters.id                                                As component_group_id,
                                                                              component_group_masters.cgroup_code                                       As cgroup_code,
                                                                              component_masters.component_name                                          As component_name
                                                                        FROM component_group_masters
                                                                        INNER JOIN component_masters
                                                                          ON component_group_masters.id=component_masters.component_group_id
                                                                        INNER JOIN product_components 
                                                                          ON product_components.component_id=component_masters.component_id) n
                                                                        GROUP BY n.product_id1 
                                                                    ) AS productComponent
                
                                                                  ON product_masters.product_id=productComponent.product_id1) AS productview
                
                                          ON SalesView.product_id =productview.product_id1
        
         GROUP BY SalesView.salesmaster_id, SalesView.owner_id, SalesView.product_id
        
                ORDER BY SalesView.owner_id, SalesView.product_id DESC
        ) AS tr
        
        on tbl.chalanmaster_id=tr.chalanmaster_id and tbl.product_id=tr.product_id
                                             
        
        
                    ";
      $dynamicSql = (array) null;

      if ($brand_id > 0) {
        $dynamicSql[] = " SalesView.brand_id, = '$brand_id' ";
      }




      if ($asm_id > 0) {
        $dynamicSql[] = " SalesView.asm_id = '$asm_id' ";
      }


      if ($sr_id > 0) {
        $dynamicSql[] = " SalesView.asr_id = '$sr_id' ";
      }

      if ($category_id > 0) {
        $dynamicSql[] = " productview.category_id = '$category_id' ";
      }

      if ($group_id > 0) {
        $dynamicSql[] = " productview.group_id = '$group_id' ";
      }

      if ($subbrand_id > 0) {
        $dynamicSql[] = " productview.subbrand_id = '$subbrand_id' ";
      }


      if ($variant_id > 0) {
        $dynamicSql[] = " productview.variant_id = '$variant_id' ";
      }

      if ($size_id > 0) {
        $dynamicSql[] = " productview.size_id = '$size_id' ";
      }

      if ($package_id > 0) {
        $dynamicSql[] = " productview.packaging_id = '$package_id' ";
      }

      /* if ($request->get('start_date') && $request->get('end_date')) {


            // $startDate = $request->get('start_date') . " 00:00:00";
            // $endDate = $request->get('end_date') . " 23:59:59";
            $dynamicSql[] = " SalesReport.sales_date BETWEEN '$startDate' and '$endDate' ";
        }*/

      /* if (strlen($pname) != 0) {
          $dynamicSql[] = " name like '$product_name' ";
          } */
      /*   if (count($dynamicSql) != 0) {
           $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
        }
*/

      // return response()->json($baseQuery);
      // $baseQuery .= " GROUP BY product_masters.product_id";

      $productsList = DB::select($baseQuery, [$startDate, $endDate, $startDate, $endDate]);
      // return response()->json($productsList);
      $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];
      // return response()->json("SUCCESS!");
      return response()->json($salesList);
    } catch (\Exception $e) {

      return response()->json("ERRORMY" . $e->getMessage());
    }
  }
















  public function GetSalesReportSecondaryDetailAllbackup(Request $request)
  {

    $asm_id = $request->get("asm_id");
    $sr_id = $request->get("sr_id");
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';

    $baseQuery = " SELECT product_prices.product_price AS DP,distributor_masters.address_a as address ,tpPrice.product_price AS TPs,SalesReport.unit_price as TP , SalesReport.invoice_no,SalesReport.name as product_name,SalesReport.subbrand_id, SalesReport.subgroup_name, SalesReport.subbrand_name,  SalesReport.sales_date, SalesReport.transaction_date, svr.id as supervisor_id, svr.name as supervisor_name,  asm.name as asm_name, asm.id as asm_id, SalesReport.asr_id, employee_masters.name as asr_name, company_masters.id as company_id, company_masters.name AS company_name, bit_masters.bit_name as bit_name,outlet_masters.outlet_name, outlet_masters.id as outlet_id, SUM( SalesReport.quantity) AS quantity, SUM(SalesReport.ctn_quantity) AS ctn_quantity, SUM(SalesReport.netamount) AS netamount, SUM(SalesReport.discount_amount) as discount_amount FROM

                      (SELECT salesVw.*, productview.* FROM


                      (SELECT secondary_sales_masters.invoice_no,secondary_sales_masters.owner_id, secondary_sales_masters.sales_date AS transaction_date,secondary_sales_masters.bit_id, secondary_sales_masters.asr_id, secondary_sales_masters.outlet_id, secondary_sales_details.* FROM secondary_sales_masters INNER JOIN secondary_sales_details
                        ON secondary_sales_masters.id=secondary_sales_details.salesmaster_id) AS salesVw

                        LEFT JOIN


                       (Select  product_masters.product_id                                                             As id1,
                                                                  product_masters.barcode                                                                As barcode,
                                                                  product_masters.product_code                                                           As product_code,
                                                                  product_masters.name                                                                   As name,
                                                                  product_masters.bn_name                                                                As bn_name,
                                                                  product_masters.company_id                                                             As company_id, 
                                                                  product_masters.oldcode                                                                As oldcode, 
                                                                  product_masters.product_image_url                                                      As product_image_url,
                                                                  product_masters.status                                                                 As status1,
                                                                  product_masters.unittype_id                                                            As unittype_id,

                                                                  product_masters.pics_qty                                                               As pics_qty,
                                                                  productComponent.*



                                                          FROM  product_masters 
                                                                LEFT JOIN 

                                                            (SELECT n.product_id1,
                                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                                FROM (

                                                                        SELECT  product_components.product_id                                             As product_id1,
                                                                                component_masters.component_id                                            As component_id,
                                                                                component_group_masters.group_name                                        As group_name,
                                                                                component_group_masters.id                                                As component_group_id,
                                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                component_masters.component_name                                          As component_name
                                                                          FROM component_group_masters
                                                                          INNER JOIN component_masters
                                                                            ON component_group_masters.id=component_masters.component_group_id
                                                                          INNER JOIN product_components 
                                                                            ON product_components.component_id=component_masters.component_id) n
                                                                          GROUP BY n.product_id1 
                                                                      ) AS productComponent

                                                                    ON product_masters.product_id=productComponent.product_id1) AS productview

                                            ON salesVw.product_id=productview.product_id1) AS SalesReport

                        LEFT JOIN 

                        company_masters ON company_masters.id=SalesReport.owner_id
                        LEFT JOIN bit_masters ON bit_masters.id=SalesReport.bit_id
                        LEFT JOIN outlet_masters ON outlet_masters.id=SalesReport.outlet_id
                        LEFT JOIN users ON users.id=SalesReport.asr_id
                        LEFT JOIN employee_masters ON users.employee_id=employee_masters.id

                        LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                        LEFT JOIN employee_masters AS asm ON asm.id=distributor_masters.asm_id
                        LEFT JOIN employee_masters AS svr ON svr.id=distributor_masters.supervisor_id

                        LEFT JOIN product_prices ON product_prices.product_id=SalesReport.product_id AND product_prices.price_id=1

                        LEFT JOIN product_prices AS tpPrice ON tpPrice.product_id=SalesReport.product_id AND tpPrice.price_id=2


                  ";
    $dynamicSql = (array) null;

    if ($brand_id > 0) {
      $dynamicSql[] = " SalesReport.brand_id, = '$brand_id' ";
    }




    if ($asm_id > 0) {
      $dynamicSql[] = " asm_id = '$asm_id' ";
    }


    if ($sr_id > 0) {
      $dynamicSql[] = " SalesReport.asr_id = '$sr_id' ";
    }

    if ($category_id > 0) {
      $dynamicSql[] = " SalesReport.category_id = '$category_id' ";
    }

    if ($group_id > 0) {
      $dynamicSql[] = " SalesReport.group_id = '$group_id' ";
    }

    if ($subbrand_id > 0) {
      $dynamicSql[] = " subbrand_id = '$subbrand_id' ";
    }


    if ($variant_id > 0) {
      $dynamicSql[] = " SalesReport.variant_id = '$variant_id' ";
    }

    if ($size_id > 0) {
      $dynamicSql[] = " SalesReport.size_id = '$size_id' ";
    }

    if ($package_id > 0) {
      $dynamicSql[] = " SalesReport.packaging_id = '$package_id' ";
    }

    if ($request->get('start_date') && $request->get('end_date')) {


      // $startDate = $request->get('start_date') . " 00:00:00";
      // $endDate = $request->get('end_date') . " 23:59:59";
      $dynamicSql[] = " SalesReport.sales_date BETWEEN '$startDate' and '$endDate' ";
    }

    /* if (strlen($pname) != 0) {
        $dynamicSql[] = " name like '$product_name' ";
        } */
    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }


    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '       GROUP BY SalesReport.salesmaster_id ,  company_id, SalesReport.product_id    ORDER BY SalesReport.company_id, SalesReport.product_id DESC');
    // return response()->json($productsList);
    $salesList[] = ['company_name' => $productsList[0]->company_name, 'address' => $productsList[0]->address, 'start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }










  public function getOrderCollectionReport(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    $asr_id = $request->get("asr_id");
    // return response()->json($request->all());
    $baseQuery1 = "  SELECT 

    tracking_no,
     chalan_date,
       DATE(indent_date) as indent_date,
     DATE_FORMAT(indent_date,'%l.%i %p') as indent_time,
     secondary_chalan_details.product_unit_price,
     secondary_chalan_details.quantity_indent,
     secondary_chalan_details.netamount_indent,
     asr_id,
      company_masters.name as company_name,
                  bit_masters.bit_name as bit_name,
                  productview.barcode as barcode,
                  productview.name as product_name,
                  outlet_masters.outlet_name as outlet_name,
                  outlet_masters.outlet_code,
                       asm.name as asm_name,
                       supervisor.name as supervisor_name,
                    sr.name as asr_name
    
    
    FROM secondary_chalan_masters
    LEFT JOIN secondary_chalan_details on secondary_chalan_masters.id=secondary_chalan_details.chalanmaster_id
    
      LEFT JOIN company_masters on company_masters.id=secondary_chalan_masters.origin_location_id
            
            LEFT JOIN distributor_masters on distributor_masters.company_id=company_masters.id
            
            LEFT JOIN employee_masters as asm on asm.id=distributor_masters.asm_id
             LEFT JOIN bit_masters ON bit_masters.id=secondary_chalan_masters.bit_id
                    
                    LEFT JOIN outlet_masters ON outlet_masters.id=secondary_chalan_masters.outlet_id
            
            
            LEFT JOIN users on users.id=secondary_chalan_masters.asr_id
            
            LEFT JOIN employee_masters as sr on sr.id=users.employee_id
            
            LEFT JOIN employee_masters as supervisor on supervisor.id=distributor_masters.supervisor_id
    
    
       LEFT JOIN
                    
                    
                         (Select  product_masters.product_id                                                             As id1,
                                                                    product_masters.barcode                                                                As barcode,
                                                                    product_masters.product_code                                                           As product_code,
                                                                    product_masters.name                                                                   As name,
                                                                    product_masters.bn_name                                                                As bn_name,
                                                                    product_masters.company_id                                                             As company_id, 
                                                                    product_masters.oldcode                                                                As oldcode, 
                                                                    product_masters.product_image_url                                                      As product_image_url,
                                                                    product_masters.status                                                                 As status1,
                                                                    product_masters.unittype_id                                                            As unittype_id,
                    
                                                                    product_masters.pics_qty                                                               As pics_qty,
                                                                    productComponent.*
                    
                    
                    
                                                            FROM  product_masters 
                                                                  LEFT JOIN 
                    
                                                              (SELECT n.product_id1,
                                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
                    
                                                                  FROM (
                    
                                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                                  component_masters.component_id                                            As component_id,
                                                                                  component_group_masters.group_name                                        As group_name,
                                                                                  component_group_masters.id                                                As component_group_id,
                                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                                  component_masters.component_name                                          As component_name
                                                                            FROM component_group_masters
                                                                            INNER JOIN component_masters
                                                                              ON component_group_masters.id=component_masters.component_group_id
                                                                            INNER JOIN product_components 
                                                                              ON product_components.component_id=component_masters.component_id) n
                                                                            GROUP BY n.product_id1 
                                                                        ) AS productComponent
                    
                                                                      ON product_masters.product_id=productComponent.product_id1) AS productview
                    
                                              ON secondary_chalan_details.product_id =productview.product_id1
    
    
    where indent_date BETWEEN ? and ? AND asr_id=?";

    $collections = DB::select($baseQuery1, [$startDate, $endDate, $asr_id]);




    $ledgerDetailList[] = ['start_date' => $startDate, 'orderCollectionList' => $collections];

    return response()->json($ledgerDetailList[0]);






    return response()->json($collections);
  }









  public function GetSalesPrimaryJP(Request $request)
  {

    $type = $request->get("type");


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
 
    $baseQuery = " 
  SELECT  salesview.dealer_code, salesview.asm_name, salesview.supervisor_name, salesview.company_name,
  salesview.invoice_no, salesview.sales_date, productview.barcode, salesview.quantity, 
  salesview.unit_price,
  salesview.netamount as totalamount,
  productview.name AS product_name,
  
  productview.group_name,
  productview.category_name,
  productview.packaging_name,
  productview.size_name,
  productview.brand_name, 
  productview.subbrand_name,
  productview.variant_name
  
   FROM
  
                      ( SELECT company_masters.sub_company_type, company_masters.code as dealer_code, IFNULL(e1.name,'') as asm_name,IFNULL(e2.name,'')  as supervisor_name,sales_masters.id as salesmaster_id, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
                        sales_details.quantity, sales_details.ctn_quantity,IFNULL( sales_details.unit_price,0) as unit_price,
                        sales_details.totalamount, sales_details.discount_amount, sales_details.netamount  FROM
                          sales_masters INNER JOIN sales_details ON sales_details.salesmaster_id= sales_masters.id   
                        LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id  
                        LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                        LEFT JOIN employee_masters e1 ON distributor_masters.asm_id= e1.id
                        LEFT JOIN employee_masters e2 ON distributor_masters.supervisor_id= e2.id
  
                        ) AS salesview  
  
  
  
                      INNER JOIN
  
                      (Select  product_masters.product_id                                                             As id,
                                              product_masters.barcode                                                                As barcode,
                                              product_masters.product_code                                                           As product_code,
                                              product_masters.name                                                                   As name,
                                              product_masters.bn_name                                                                As bn_name,
                                              product_masters.company_id                                                             As company_id, 
                                              product_masters.oldcode                                                                As oldcode, 
                                              product_masters.product_image_url                                                      As product_image_url,
                                              product_masters.status                                                                 As status,
                                              product_masters.unittype_id                                                            As unittype_id,
  
                                              product_masters.pics_qty                                                               As pics_qty,
                                              productComponent.*
  
  
  
                                      FROM  product_masters 
                                            LEFT JOIN 
  
                                        (SELECT n.product_id,
                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                              MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                              MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                               MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                              MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                               MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                              MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
  
                                            FROM (
  
                                                    SELECT  product_components.product_id                                             As product_id,
                                                            component_masters.component_id                                            As component_id,
                                                            component_group_masters.group_name                                        As group_name,
                                                            component_group_masters.id                                                As component_group_id,
                                                            component_group_masters.cgroup_code                                       As cgroup_code,
                                                            component_masters.component_name                                          As component_name
                                                      FROM component_group_masters
                                                      INNER JOIN component_masters
                                                        ON component_group_masters.id=component_masters.component_group_id
                                                      INNER JOIN product_components 
                                                        ON product_components.component_id=component_masters.component_id) n
                                                      GROUP BY n.product_id 
                                                  ) AS productComponent
  
                                                ON product_masters.product_id=productComponent.product_id) AS productview
  
                        ON salesview.product_id=productview.product_id
          
              ";
    $dynamicSql = (array) null;

    



    if ($request->get('start_date') && $request->get('end_date')) {



      $dynamicSql[] = " salesview.sales_date BETWEEN '$startDate' and '$endDate' and productview.brand_name='Jet' ";
    }
    if ($type > 0) {
      $dynamicSql[] = " salesview.sub_company_type = '$type' ";
    }

    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql);
    }

   // return response()->json($baseQuery);
    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery . '    ORDER BY salesview.salesmaster_id ASC ');

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }



  

  public function GetSalesSecondaryJP(Request $request)
  {

    $type = $request->get("type");


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
 
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT

    SalesView.asm_name,
    asr_name,
    SalesView.supervisor_name,
    dealer_code,
    SalesView.company_name as distributor_name,
    SalesView.bit_name,
    SalesView.outlet_name,
    SalesView.outlet_type,
    SalesView.category as category_type,
    area_name,
    SalesView.outlet_code,
    SalesView.invoice_no,
    SalesView.sales_date,
    productview.barcode,
    productview.name as product_name,
    productview.brand_name,
    productview.subbrand_name,
    productview.group_name,
    productview.category_name,
    productview.packaging_name,
    productview.size_name,
    SalesView.TP,
    sum(SalesView.quantity) as quantity,
    sum(SalesView.ctn_quantity) ctn_quantity,
    
    sum(SalesView.unit_price) as unit_price,
    SUM(SalesView.totalamount) as totalamount,
    sum(SalesView.discount_amount) as discount_amount,
    SUM(SalesView.netamount) as netamount
 
    
    FROM
    
    
        (    SELECT  employee_masters.name as asr_name,asm_id, distributor_masters.address_a , distributor_masters.area_name, company_masters.code as dealer_code  ,   product_prices.product_price AS DP,  company_masters.name AS company_name, bit_masters.bit_name as bit_name,outlet_masters.outlet_name,outlet_masters.outlet_code, outlet_masters.outlet_type, outlet_masters.category, svr.name as supervisor_name,  asm.name as asm_name, secondary_sales_masters.invoice_no, secondary_sales_details.unit_price as TP, secondary_sales_masters.owner_id, secondary_sales_masters.sales_date AS transaction_date,secondary_sales_masters.bit_id, secondary_sales_masters.asr_id, secondary_sales_masters.outlet_id, secondary_sales_details.* FROM secondary_sales_masters INNER JOIN secondary_sales_details
              ON secondary_sales_masters.id=secondary_sales_details.salesmaster_id
    
              LEFT JOIN
    
              company_masters ON company_masters.id=secondary_sales_masters.owner_id
    
        LEFT JOIN bit_masters ON bit_masters.id=secondary_sales_masters.bit_id
    
        LEFT JOIN outlet_masters ON outlet_masters.id=secondary_sales_masters.outlet_id
        LEFT JOIN users ON users.id=secondary_sales_masters.asr_id
        LEFT JOIN employee_masters ON users.employee_id=employee_masters.id
    
        LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
        LEFT JOIN employee_masters AS asm ON asm.id=distributor_masters.asm_id
              LEFT JOIN employee_masters AS svr ON svr.id=distributor_masters.supervisor_id
    
        LEFT JOIN product_prices ON product_prices.product_id=secondary_sales_details.product_id AND product_prices.price_id=1
    
        WHERE secondary_sales_masters.sales_date BETWEEN ? and ? ) as SalesView
    
        LEFT JOIN
    
             (Select  product_masters.product_id                                                             As id1,
                                                        product_masters.barcode                                                                As barcode,
                                                        product_masters.product_code                                                           As product_code,
                                                        product_masters.name                                                                   As name,
                                                        product_masters.bn_name                                                                As bn_name,
                                                        product_masters.company_id                                                             As company_id,
                                                        product_masters.oldcode                                                                As oldcode,
                                                        product_masters.product_image_url                                                      As product_image_url,
                                                        product_masters.status                                                                 As status1,
                                                        product_masters.unittype_id                                                            As unittype_id,
    
                                                        product_masters.pics_qty                                                               As pics_qty,
                                                        productComponent.*
    
                                                FROM  product_masters
                                                      LEFT JOIN
    
                                                  (SELECT n.product_id1,
                                                              MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                              MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                         MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                        MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id
    
                                                      FROM (
    
                                                              SELECT  product_components.product_id                                             As product_id1,
                                                                      component_masters.component_id                                            As component_id,
                                                                      component_group_masters.group_name                                        As group_name,
                                                                      component_group_masters.id                                                As component_group_id,
                                                                      component_group_masters.cgroup_code                                       As cgroup_code,
                                                                      component_masters.component_name                                          As component_name
                                                                FROM component_group_masters
                                                                INNER JOIN component_masters
                                                                  ON component_group_masters.id=component_masters.component_group_id
                                                                INNER JOIN product_components
                                                                  ON product_components.component_id=component_masters.component_id) n
                                                                GROUP BY n.product_id1
                                                            ) AS productComponent
    
                                                          ON product_masters.product_id=productComponent.product_id1) AS productview
    
                                  ON SalesView.product_id =productview.product_id1
    
    
    
    WHERE productview.brand_name='Jet'
    
    
    
    GROUP BY SalesView.salesmaster_id, SalesView.owner_id, SalesView.product_id
    
    
        ORDER BY SalesView.owner_id, SalesView.product_id DESC
    ";









    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    //return response()->json($collections);
    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $collections];

    return response()->json($salesList);
  }







  public function GetPurchaseJP(Request $request)
  {

  


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
 
  
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " 

SELECT 

chalan_masters.tracking_no,
chalan_date,
productview.group_name,
productview.category_name,
productview.subbrand_name,
productview.name as product_name,
productview.packaging_name,
productview.size_name,
chalan_details.quantity_purchase,
chalan_details.purchase_unit_price, 
chalan_details.purchase_netamount as purchase_total_amount,
chalan_details.purchase_rebate_amount,
chalan_details.purchase_total_amount as purchase_net_amount




FROM chalan_masters LEFT JOIN chalan_details on chalan_masters.id=chalan_details.chalanmaster_id


  LEFT JOIN

         (Select  product_masters.product_id                                                             As id1,
                                                    product_masters.barcode                                                                As barcode,
                                                    product_masters.product_code                                                           As product_code,
                                                    product_masters.name                                                                   As name,
                                                    product_masters.bn_name                                                                As bn_name,
                                                    product_masters.company_id                                                             As company_id,
                                                    product_masters.oldcode                                                                As oldcode,
                                                    product_masters.product_image_url                                                      As product_image_url,
                                                    product_masters.status                                                                 As status1,
                                                    product_masters.unittype_id                                                            As unittype_id,

                                                    product_masters.pics_qty                                                               As pics_qty,
                                                    productComponent.*

                                            FROM  product_masters
                                                  LEFT JOIN

                                              (SELECT n.product_id1,
                                                          MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id,
                                                          MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                          MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                          MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                          MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                     MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                     MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                    MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                  FROM (

                                                          SELECT  product_components.product_id                                             As product_id1,
                                                                  component_masters.component_id                                            As component_id,
                                                                  component_group_masters.group_name                                        As group_name,
                                                                  component_group_masters.id                                                As component_group_id,
                                                                  component_group_masters.cgroup_code                                       As cgroup_code,
                                                                  component_masters.component_name                                          As component_name
                                                            FROM component_group_masters
                                                            INNER JOIN component_masters
                                                              ON component_group_masters.id=component_masters.component_group_id
                                                            INNER JOIN product_components
                                                              ON product_components.component_id=component_masters.component_id) n
                                                            GROUP BY n.product_id1
                                                        ) AS productComponent

                                                      ON product_masters.product_id=productComponent.product_id1) AS productview

                              ON chalan_details.product_id =productview.product_id1


where chalan_masters.chalan_date BETWEEN ? and ? AND productview.brand_name='Jet'
and chalan_masters.chalan_type=1
    ";









    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    //return response()->json($collections);
    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $collections];

    return response()->json($salesList);
  }






  public function SubForm_k(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT pm.name AS prduct_description, pm.name AS prduct_name, pm.sh_code,SUM((sd.netamount- sd.netamount*(15/115))) AS netamount, SUM(sd.vat_amount) as vat_amount FROM sales_masters sm LEFT JOIN sales_details sd ON sm.id = sd.salesmaster_id 
    LEFT JOIN product_masters pm ON sd.product_id=pm.product_id
    WHERE sm.sales_date BETWEEN ? AND ?
    
    GROUP BY prduct_name";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }




  public function SubForm_k_Note_14(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT 0 AS Id, product_masters.name AS prduct_description, product_masters.name AS item_name, product_masters.sh_code,SUM(chalan_details.purchase_netamount) AS price,
    0 AS sd, 
    SUM(chalan_details.purchase_rebate_amount) AS vat 
    
      FROM chalan_masters LEFT JOIN chalan_details ON chalan_masters.id = chalan_details.chalanmaster_id
    
    LEFT JOIN product_masters  ON chalan_details.product_id=product_masters.product_id
    
    WHERE chalan_masters.chalan_date BETWEEN ? AND ? AND chalan_masters.chalan_type=1 AND purchase_rebate_percent=15
    
    GROUP BY chalan_details.product_id";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }


  public function SubForm_k_Note_14Lakh(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT 0 AS Id, chalan_masters.tracking_no, chalan_masters.chalan_date,supplier_masters.name AS bikreta, supplier_masters.address,supplier_masters.vat_reg_no, chalan_masters.supplier_id, chalan_masters.total_amount_purchase AS price,
    0 AS sd, 
   chalan_masters.purchase_rebate_amount_total AS vat 
    
      FROM chalan_masters
    
    LEFT JOIN supplier_masters ON chalan_masters.supplier_id=supplier_masters.id
    
    WHERE chalan_masters.chalan_date BETWEEN ? AND ? AND chalan_masters.chalan_type=1 
    
    
     AND chalan_masters.total_amount_purchase>=200000
    ";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }





  public function MushakSalesReturn(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT id AS note_id , return_invoice_no AS note_no FROM sales_return_masters WHERE return_date BETWEEN  ? AND ? ";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }



  public function MushakSalesReturnMushak6(Request $request)
  {


    $invoice_no = $request->get('invoice_no');
  
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " 
   
    SELECT

    sales_masters.invoice_no,
    Returndata.address_a,
    sales_masters.sales_date,
     SUM(sales_details.quantity) AS sale_qty,
    SUM(sales_details.totalamount) AS sales_netamount,
    SUM(sales_details.vat_amount ) AS sales_vatamount,
     Returndata.* FROM
    (SELECT
    sales_return_masters.ref_invoice_no,
    company_masters.name AS kreata_name,
    company_masters.bin,
    
    sales_return_masters.return_date,
    sales_return_masters.distribution_node_id,
     sales_return_masters.return_invoice_no,
    
    SUM(sales_return_details.quantity) AS return_qty, 
    
    SUM(sales_return_details.netamount) AS return_netamount,
    
    SUM(sales_return_details.vat_amount) AS return_vatamount,
    distributor_masters.address_a
     FROM sales_return_masters
    LEFT JOIN sales_return_details  ON sales_return_details.sales_return_master_id=sales_return_masters.id
    
    
    LEFT JOIN company_masters ON sales_return_masters.distribution_node_id=company_masters.id
    
    LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
    
    
     WHERE
    
     sales_return_masters.return_invoice_no=?
    
    GROUP BY sales_return_masters.id) AS Returndata
    
    LEFT JOIN sales_masters ON Returndata.ref_invoice_no=sales_masters.invoice_no
    LEFT JOIN sales_details ON sales_masters.id=sales_details.salesmaster_id
    GROUP BY Returndata.ref_invoice_no
    
    ";
    $collections = DB::select($baseQuery1, [$invoice_no]);


    return response()->json($collections);
  }




  public function SubForm_k_Note_14SalesLakh(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT 
    0 AS Id,
    invoice_no,
    company_masters.name AS kreta_name,
    sales_masters.sales_date AS issue_date,
    sales_masters.total_netamount AS price,
    distributor_masters.address_a AS address,
    distributor_masters.vat_reg_no
    FROM sales_masters 
    LEFT JOIN company_masters  ON sales_masters.sales_location_id = company_masters.id
    LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
    
    
    WHERE sales_masters.sales_date BETWEEN ? AND ?
    AND sales_masters.total_netamount>200000";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }

  
  public function Subform_Note_31CreditNoteReturn(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = " SELECT sales_return_masters.return_invoice_no, return_date, ref_invoice_no, SUM(sales_return_details.quantity) AS return_qty,'sales return' AS remarks,  SUM(sales_return_details.netamount) AS netamount, SUM(sales_return_details.vat_amount) AS vat_amount 
    FROM sales_return_masters LEFT JOIN sales_return_details ON sales_return_masters.id=sales_return_details.sales_return_master_id
    
    WHERE sales_return_masters.return_date BETWEEN ? AND ?
    GROUP BY sales_return_masters.id";
    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }

    
  public function gerProductList(Request $request)
  {


    
    $baseQuery1 = " SELECT product_id, name FROM product_masters ";
    $collections = DB::select($baseQuery1);


    return response()->json($collections);
  }


  public function isProductExist(Request $request)
  {

    $product_name = $request->get('name');
    
    $baseQuery1 = " SELECT product_id, name FROM product_masters WHERE name=? ";
    //$collections = DB::select($baseQuery1);

    $collections = DB::select($baseQuery1, [$product_name]);
    return response()->json($collections);
  }

  

  public function getDamageCollectionReport(Request $request)
  {


    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //$company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "  SELECT collection_masters.tracking_no,company_masters.name as company_name, distributor_masters.address_a, distributor_masters.area_name,
  collection_masters.entry_date as transaction_dates,
  claim_damage_collection_masters.particulars as particular_name, component_masters.component_name as brand_name, claim_damage_collection_masters.* FROM collection_masters 
  INNER JOIN claim_damage_collection_masters ON collection_masters.id=claim_damage_collection_masters.collection_id
  
  LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id=company_masters.id
  LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
  LEFT JOIN component_masters ON component_masters.component_id=claim_damage_collection_masters.brand_id
  WHERE collection_masters.entry_date BETWEEN ? and ?";









    $collections = DB::select($baseQuery1, [$startDate, $endDate]);


    return response()->json($collections);
  }

  public function getPartyLedgerListVat(Request $request)
  {


    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    // $company_id = $request->get("company_id");
    // return response()->json($request->all());
    $baseQuery1 = "SELECT sum(ledger.opening) + sum(ledger.adjustment) + SUM(ledger.treasury)+ SUM(ledger.reyat) -SUM(ledger.payable) as opening_balance FROM 

                                (select  particulars , transaction_date,reference,treasury,reyat,adjustment,payable,opening, remarks from vat_ledger_masters
                                WHERE 
                                 (transaction_date < ? ) and particulars<>'Adjustment Payable'
                                    UNION ALL


                                 select  particulars , transaction_date,reference,treasury,reyat,-1*adjustment,payable,opening, remarks from vat_ledger_masters
                                    WHERE 
                                 (transaction_date < ? ) and particulars='Adjustment Payable'

                            

                                UNION ALL

                                SELECT 'Sales' as particulars,sales_date as transaction_date, invoice_no as reference, 0 as treasury,0 as reyat, 0 as adjustment,total_vat as payable, 0 as opening,'' as remarks  FROM sales_masters

                                WHERE 
                                 (sales_date < ? )    
           
               UNION ALL
   
            SELECT 'Return' as particulars,sales_return_masters.return_date as transaction_date, return_invoice_no  as reference, 0 as treasury,0 as reyat, IFNULL( SUM(sales_return_details.vat_amount),0)  as adjustment,0 as payable, 0 as opening,'' as remarks  FROM 
                               sales_return_masters INNER JOIN sales_return_details
                               ON sales_return_masters.id=sales_return_details.sales_return_master_id
                                  WHERE (sales_return_masters.return_date < ? )
                               HAVING COUNT(sales_return_details.product_id)>0       
                             
                                ORDER BY transaction_date) as ledger";

    $baseQuery2 = "select  particulars , transaction_date,reference,treasury,reyat,adjustment,payable,opening, remarks,users_entry_date from vat_ledger_masters
                        WHERE 
                                 (transaction_date BETWEEN  ? AND  ? ) and particulars<>'Adjustment Payable'
                                 UNION ALL


                                select  particulars , transaction_date,reference,treasury,reyat,-1*adjustment,payable,opening, remarks,users_entry_date from vat_ledger_masters
                                WHERE 
                                 (transaction_date BETWEEN  ? AND  ? ) and particulars='Adjustment Payable'

                            

                                UNION ALL

                                SELECT 'Sales' as particulars,sales_date as transaction_date, invoice_no as reference, 0 as treasury,0 as reyat, 0 as adjustment,total_vat as payable, 0 as opening,'' as remarks,sales_date as users_entry_date  FROM sales_masters

                                WHERE  (sales_date BETWEEN ? AND  ? )
    
                               
                            UNION ALL
   
                                    SELECT 'Adjustment(Rebate)' as particulars,sales_return_masters.return_date as transaction_date, return_invoice_no  as reference, 0 as treasury,0  as reyat, IFNULL( SUM(sales_return_details.vat_amount),0) as adjustment,0 as payable, 0 as opening,'Sale Return' as remarks,sales_return_masters.return_date as users_entry_date   FROM 
                                            sales_return_masters INNER JOIN sales_return_details
                                            ON sales_return_masters.id=sales_return_details.sales_return_master_id
                                               WHERE sales_return_masters.return_date BETWEEN ? AND  ?
                                                 GROUP BY sales_return_masters.return_invoice_no
                                            HAVING COUNT(sales_return_details.product_id)>0


                            ORDER BY transaction_date,remarks ASC";


    $baseQuery3 = "SELECT SUM(ledger.treasury) AS  treasury, SUM(ledger.adjustment_received) as adjustment_received ,SUM(ledger.adjustment_payabole) as adjustment_payable , SUM(ledger.reyat) as reyat, SUM(ledger.payable) as payable  FROM

                        (select  treasury,reyat,adjustment as adjustment_received,0 as adjustment_payabole,payable,opening, remarks from vat_ledger_masters
                          WHERE 
                                                         (vat_ledger_masters.transaction_date BETWEEN  ? AND  ? ) and particulars<>'Adjustment Payable'
                              UNION ALL


                               select  treasury,reyat,0 as adjustment_received,adjustment as adjustment_payabole,payable,opening, remarks from vat_ledger_masters
                               WHERE 
                                                         (vat_ledger_masters.transaction_date BETWEEN  ? AND  ? ) and particulars='Adjustment Payable'



                                                        UNION ALL

                                                        SELECT  0 as treasury,0 as reyat, 0 as adjustment_received,0 as adjustment_payabole,total_vat as payable, 0 as opening,'' as remarks  FROM sales_masters

                                                        WHERE 
                                                         (sales_masters.sales_date BETWEEN  ? AND  ? )
  

                               
  UNION ALL
   
            SELECT  return_invoice_no  as reference, 0 as treasury,0  as reyat, IFNULL( SUM(sales_return_details.vat_amount),0) as adjustment,0 as payable, 0 as opening,'' as remarks  FROM 
                               sales_return_masters INNER JOIN sales_return_details
                               ON sales_return_masters.id=sales_return_details.sales_return_master_id
                                WHERE sales_return_masters.return_date BETWEEN ? AND  ?
                               HAVING COUNT(sales_return_details.product_id)>0)
  

  as ledger ";




    $opening_balance = DB::select($baseQuery1, [$startDate, $startDate, $startDate, $startDate]);
    $partyLedgerList = DB::select($baseQuery2, [$startDate, $endDate, $startDate, $endDate, $startDate, $endDate, $startDate, $endDate]);
    $result = DB::select($baseQuery3, [$startDate, $endDate, $startDate, $endDate, $startDate, $endDate, $startDate, $endDate]);


    $ledgerDetailList[] = ['opening_balance' => $opening_balance[0]->opening_balance ?: 0, 'treasury' => $result[0]->treasury, 'adjustment_received' => $result[0]->adjustment_received, 'adjustment_payable' => $result[0]->adjustment_payable, 'reyat' => $result[0]->reyat, 'payable' => $result[0]->payable, 'ledgerList' => $partyLedgerList];

    return response()->json($ledgerDetailList);
  }

  public function getmushoksixone(Request $request)
  {
    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    $product_id = $request->get('product_id');





    $current_dt = new \DateTime('now', new \DateTimezone('Asia/Dhaka'));
    $current_dt = Carbon::parse($current_dt)->format('Y/m/d') . " 23:59:59";
    // $startDate = $request->get('start_date') . " 00:00:00";
    // $endDate = $request->get('end_date') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";

    // $product_name = '%' . $pname . '%';

    $baseQuery = " 
            

SELECT currentStock.product_id, currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0) AS OpeningQty,
  
                      ( currentStock.stock- IFNULL( mreceiveStock.quantity_purchase,0) +IFNULL(msales.sale_quantity,0) - IFNULL(msaleReturn.sale_return_quantity,0))+IFNULL( receiveStock.quantity_purchase,0)-IFNULL(sales.sale_quantity,0)+IFNULL(saleReturn.sale_return_quantity,0) as ClosingQty ,
  
  
                            IFNULL(receiveStock.quantity_purchase,0) AS receive_qty,

                              IFNULL(sales.sale_quantity,0) AS sale_qty,
                               IFNULL(saleReturn.sale_return_quantity,0) AS sale_return_qty,
                            (currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0)  AS ClosingQty1,
                              ((currentStock.stock- IFNULL( receiveStock.quantity_purchase,0) +IFNULL(sales.sale_quantity,0)- IFNULL(saleReturn.sale_return_quantity,0))+ (IFNULL(receiveStock.quantity_purchase,0)+IFNULL(saleReturn.sale_return_quantity,0))-    IFNULL(sales.sale_quantity,0))* currentStock.product_price  AS ClosingDp,
                            IFNULL( receiveStock.quantity_purchase,0) AS quantity_purchase, IFNULL(receiveStock.ctn_quantity_purchase,0) AS ctn_quantity_purchase, 

                            IFNULL(receiveStock.purchase_netamount,0) AS purchase_netamount ,

                            currentStock.* FROM








                            (Select  product_masters.product_id                                                                As currentstock_product_id,
                                                  product_masters.barcode                                                                As barcode,
                                                  product_masters.product_code                                                           As product_code,
                                                  product_masters.name                                                                   As name,
                                                  product_masters.bn_name                                                                As bn_name,
                                                  product_masters.company_id                                                             As company_id, 
                                                  product_masters.oldcode                                                                As oldcode, 
                                                  product_masters.product_image_url                                                      As product_image_url,
                                                  product_masters.status                                                                 As status,
                                                  product_masters.unittype_id                                                            As unittype_id,
                                                  unit_types.unit_name                                                                   As unit_name,
                                                  product_masters.pics_qty                                                               As pics_qty,
                                                  productComponent.*,
                                                  price_types.id                                                                         As pricetype_id,

                                                  price_types.price_name                                                      As price_name,
                                                  IFNULL(product_prices.product_price, 0)                                     As product_price,
                                                  IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
                                                  IFNULL(inventories.quantity, 0)                                             AS stock,
                                                  CAST(IFNULL(inventories.quantity/product_masters.pics_qty, 0) as decimal(5,2))                                               AS  stock_qtn,

                                                  IFNULL(inventories.virtual_quantity, 0)                                     AS available_stock,

                                           ( SELECT  product_prices.product_price FROM  product_prices 
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                              WHERE price_types.price_code='TP' and product_prices.product_id=product_masters.product_id) AS tp_price




                                          FROM  product_masters 
                                                LEFT JOIN 

                                            (SELECT n.product_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_name END)                    As group_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'grouping'  THEN n.component_id END)                      As group_id, 
                                                        MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_name END)                    As subgroup_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subgroup'  THEN n.component_id END)                      As subgroup_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_name END)                    As brand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'brand'     THEN n.component_id END)                      As brand_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_name END)                    AS category_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'category'  THEN n.component_id END)                      AS category_id,
                                                        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_name END)                    As packaging_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.component_id END)                        As packaging_id,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_id END)                        As size_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_name END)                    As subbrand_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'subbrand'     THEN n.component_id END)                      As subbrand_id,
                                                   MAX(CASE WHEN n.cgroup_code = 'variant'     THEN n.component_name END)                    As variant_name,
                                                  MAX(CASE WHEN n.cgroup_code = 'Variant'     THEN n.component_id END)                      As variant_id

                                                FROM (

                                                        SELECT  product_components.product_id                                             As product_id,
                                                                component_masters.component_id                                            As component_id,
                                                                component_group_masters.group_name                                        As group_name,
                                                                component_group_masters.id                                                As component_group_id,
                                                                component_group_masters.cgroup_code                                       As cgroup_code,
                                                                component_masters.component_name                                          As component_name
                                                          FROM component_group_masters
                                                          INNER JOIN component_masters
                                                            ON component_group_masters.id=component_masters.component_group_id
                                                          INNER JOIN product_components 
                                                            ON product_components.component_id=component_masters.component_id) n
                                                          GROUP BY n.product_id 
                                                      ) AS productComponent

                                                    ON product_masters.product_id=productComponent.product_id
                                                  LEFT JOIN unit_types on product_masters.unittype_id=unit_types.id
                                                  LEFT JOIN product_prices  ON product_masters.product_id= product_prices.product_id
                                                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
                                                  LEFT JOIN products_discounts ON product_masters.product_id=products_discounts.product_id
                                                  INNER JOIN inventories ON product_masters.product_id=inventories.product_id
                                     WHERE inventories.owner_id=1 AND product_prices.price_id=1 and inventories.product_id= '$product_id'
                            GROUP BY product_masters.product_id) AS currentStock


 
                    ";


    $baseQuery2 = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$endDate'
                              GROUP BY chalan_details.product_id ) AS receiveStock

                                ON currentStock.currentstock_product_id=receiveStock.product_id ";


    $baseQuery2n = "
                        LEFT JOIN
                        (SELECT chalan_details.product_id,sum(chalan_details.quantity_purchase) as quantity_purchase,sum(ctn_quantity_purchase) as ctn_quantity_purchase,sum(purchase_netamount) as purchase_netamount
                              FROM chalan_details
                              INNER JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                              WHERE chalan_masters.chalan_type=1  AND chalan_masters.company_id=1 AND chalan_date   BETWEEN '$startDate' and '$current_dt'
                              GROUP BY chalan_details.product_id ) AS mreceiveStock

                                ON currentStock.currentstock_product_id=mreceiveStock.product_id ";


    $baseQuery3 = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate' and sales_masters.company_id=1
                          GROUP BY sales_details.product_id) as sales
                        ON currentStock.currentstock_product_id= sales.product_id ";


    $baseQuery3n = "  LEFT JOIN

                        (SELECT sales_details.product_id, SUM( sales_details.quantity) AS sale_quantity, sales_details.ctn_quantity as ctn_quantiy_sale FROM  sales_details 
                          INNER JOIN sales_masters ON sales_masters.id=sales_details.salesmaster_id
                          WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt' and sales_masters.company_id=1
                          GROUP BY sales_details.product_id) as msales
                        ON currentStock.currentstock_product_id= msales.product_id ";


    $baseQuery4 = "   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_masters 
                              INNER JOIN sales_return_details ON sales_masters.id=sales_return_details.salesmaster_id
                              WHERE sales_masters.sales_date BETWEEN '$startDate' and '$endDate' 
                              GROUP BY sales_return_details.product_id) AS saleReturn

                             ON currentStock.currentstock_product_id= saleReturn.product_id ";
    $baseQuery4n = "   LEFT JOIN
                            (SELECT sales_return_details.product_id, sum( sales_return_details.quantity) AS sale_return_quantity,ROUND( sales_return_details.ctn_quantity, 2) as ctn_quantiy_sale_return FROM  sales_masters 
                              INNER JOIN sales_return_details ON sales_masters.id=sales_return_details.salesmaster_id
                              WHERE sales_masters.sales_date BETWEEN '$startDate' and '$current_dt' 
                              GROUP BY sales_return_details.product_id) AS msaleReturn

                             ON currentStock.currentstock_product_id= msaleReturn.product_id ";


    $finalQuery = $baseQuery . $baseQuery2 . $baseQuery2n . $baseQuery3 . $baseQuery3n . $baseQuery4 . $baseQuery4n;

    // return response()->json($finalQuery);
    $dynamicSql = (array) null;



    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($finalQuery);
    $opening_qty = $productsList[0]->OpeningQty;

    //  $stockList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'StockSummaryList' => $productsList];
    // return $startDate."sdfsdf ".$endDate;
    // $indentType = $request->get('requisition_type');
    // $indentList = null;
    $query = "SELECT        product_masters.name                                            AS product_name,
              product_masters.product_id                                      As product_id,
              sales_masters.sales_date                                        As transaction_date,
              ''                                                              AS supplier_name,
              ''                                                              As supplier_address,
              ''                                                              AS supplier_vat_reg_no,
              ''                                                              AS purchase_date,
              ''                                                              AS remarks,
              ''                                                              AS reference_number,
              0                                                               AS  quantity_purchase,
              0                                                               AS  ctn_quantity_purchase,
              0                                                               AS  purchase_netamount,
              0                                                               AS  purchase_total_amount,
              0                                                               AS  purchase_unit_price,
              0                                                               AS  purchase_rebate_percent,
              0                                                               AS  purchase_rebate_amount,
              ''                                                              AS  tracking_no,
              sales_masters.invoice_no                                        As invoice_no,
              sales_masters.sales_date                                        As  sale_date,
              product_masters.name                                            As product_name_biboron,
            
              company_masters.name                                            AS distributor_name,
              distributor_masters.address_a                                   As distributor_address, 
              sales_details.quantity                                          As sale_quantity,
              distributor_masters.vat_reg_no                                  As distributor_reg_number,
       
              sales_details.netamount                                         As sale_amount,
                IFNULL( sales_details.netamount-sales_details.vat_amount,0)                As net_amount_without_mushok,
                IFNULL( sales_details.vat_amount ,0)                                       As vat_amount,
      'sale'                                                      As Operationtype
            
              FROM sales_details INNER JOIN sales_masters
              ON sales_details.salesmaster_id=sales_masters.id
              LEFT JOIN product_masters ON product_masters.product_id=sales_details.product_id
              LEFT JOIN company_masters ON   company_masters.id=sales_location_id
              LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
  WHERE product_masters.product_id= ?
 and sales_masters.sales_date BETWEEN ? and ?

  UNION ALL

  SELECT          product_masters.name                                                                AS product_name,
                product_masters.product_id                                                          As product_id,
                chalan_masters.chalan_date                                                          AS transaction_date,
                  supplier_masters.name                                                             AS supplier_name,
               
                 supplier_masters.address                                                           AS supplier_address,
                supplier_masters.vat_reg_no                                                         AS supplier_vat_reg_no,
                  chalan_masters.chalan_date                                                        AS purchase_date,
                     chalan_masters.remarks                                                         AS remarks,
               
                  
                     chalan_masters.reference_number                                                AS reference_number,
                  chalan_details.quantity_purchase                                                  AS  quantity_purchase,
                  chalan_details.ctn_quantity_purchase                                              AS  ctn_quantity_purchase,
               
                  IFNULL( chalan_details.purchase_netamount,0)                                      AS  purchase_netamount,
                  IFNULL( chalan_details.purchase_total_amount,0)                                   AS  purchase_total_amount,
                  IFNULL( chalan_details.purchase_unit_price,0)                                     AS  purchase_unit_price,
                  IFNULL( chalan_details.purchase_rebate_percent ,0)                                AS  purchase_rebate_percent,
                  IFNULL( chalan_details.purchase_rebate_amount,0)                                  AS  purchase_rebate_amount,
              
              
                  chalan_masters.tracking_no                                                        AS  tracking_no,
                  ''                                                                                As invoice_no,
                  ''                                                                                AS sale_date,
                  ''                                                                                As product_name_biboron,
                  ''                                                                                As distributor_name,
                  ''                                                                                As distributor_address,
                  0                                                                                 As sale_quantity,
                  ''                                                                                As distributor_reg_number,
                  0                                                                                 As sale_amount,
                  0                                                                                 As net_amount_without_mushok,
                  0                                                                                 As vat_amount,
                  'receive'                                                      As Operationtype
               
                
           
                  
                                    FROM chalan_details
                             
                                    LEFT JOIN chalan_masters ON chalan_masters.id=chalan_details.chalanmaster_id
                                    LEFT JOIN product_masters ON product_masters.product_id=chalan_details.product_id
                                    LEFT JOIN supplier_masters ON chalan_masters.supplier_id=supplier_masters.id
                                   -- LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
                                 --   LEFT JOIN employee_masters  as ASM ON ASM.id=distributor_masters.asm_id
                                  --  LEFT JOIN employee_masters  as supervisor ON supervisor.id=distributor_masters.supervisor_id
                                  --  LEFT JOIN employee_masters AS requestedBy ON requestedBy.id=chalan_masters.entry_user_id
               WHERE      chalan_masters.chalan_type= 1
   and chalan_details.product_id= ?
           and chalan_masters.chalan_date BETWEEN ? AND ? 


            UNION ALL


            SELECT        product_masters.name                                            AS product_name,
              product_masters.product_id                                      As product_id,
              sales_return_masters.return_date                                As transaction_date,
              ''                                                              AS supplier_name,
              ''                                                              As supplier_address,
              ''                                                              AS supplier_vat_reg_no,
              ''                                                              AS purchase_date,
              ''                                                              AS remarks,
              ''                                                              AS reference_number,
              0                                                               AS  quantity_purchase,
              0                                                               AS  ctn_quantity_purchase,
              0                                                               AS  purchase_netamount,
              0                                                               AS  purchase_total_amount,
              0                                                               AS  purchase_unit_price,
              0                                                               AS  purchase_rebate_percent,
              0                                                               AS  purchase_rebate_amount,
              ''                                                              AS  tracking_no,
              sales_return_masters.return_invoice_no                          As invoice_no,
              sales_return_masters.return_date                                As  sale_date,
              product_masters.name                                            As product_name_biboron,
            
              company_masters.name                                            AS distributor_name,
              distributor_masters.address_a                                   As distributor_address, 
              sales_return_details.quantity                                          As sale_quantity,
              distributor_masters.vat_reg_no                                  As distributor_reg_number,
       
              sales_return_details.netamount                                         As sale_amount,
              sales_return_details.netamount                                As net_amount_without_mushok,
              0                                                             As vat_amount,
              'return'                                                      As Operationtype
            
              FROM sales_return_details INNER JOIN sales_return_masters
              ON sales_return_details.sales_return_master_id=sales_return_masters.id
              LEFT JOIN product_masters ON product_masters.product_id=sales_return_details.product_id
              LEFT JOIN company_masters ON   company_masters.id=sales_return_masters.distribution_node_id
              LEFT JOIN distributor_masters ON distributor_masters.company_id=company_masters.id
  WHERE product_masters.product_id=?
  and sales_return_masters.return_date BETWEEN ? and ?
   ORDER BY transaction_date
 ";


    $purchaseList = DB::select($query, [$product_id, $startDate, $endDate, $product_id, $startDate, $endDate, $product_id, $startDate, $endDate]);
    //return $purchaseList;
    $vatList[] = ['opening_balance' => $opening_qty, 'vatList' => $purchaseList];

    return response()->json($vatList);
  }

  public function DistributorWiseSummaryTypeNew(Request $request)
  {

    $asm_id = $request->get("asm_id");
    // return $asm_id;
    $company_id = $request->get("company_id");
    $brand_id = $request->get("brand_id");
    $category_id = $request->get("category_id");
    $group_id = $request->get("group_id");
    $subbrand_id = $request->get("subbrand_id");
    $variant_id = $request->get("variant_id");
    $size_id = $request->get("size_id");
    $package_id = $request->get("package_id");
    $pname = $request->get("product_name");

    $startDate = Carbon::parse($request->get('start_date'))->format('Y/m/d') . " 00:00:00";
    $endDate = Carbon::parse($request->get('end_date'))->format('Y/m/d') . " 23:59:59";
    //   $dating = $request->get('start_date');
    //  return response()->json($dating);
    $product_name = '%' . $pname . '%';



    $baseQuery = " 
SELECT SummarySaleReport.*,finalOutstanding.balance AS outstanding FROM


(SELECT
  
  
  (
                                CASE WHEN company_masters.sub_company_type=1
                                        THEN  'Dealer '
                                   WHEN company_masters.sub_company_type=2
                                        THEN  'Institute '
                                   WHEN company_masters.sub_company_type=3
                                        THEN  'Modern Trade '
                                    ELSE ''
                                    END
                             ) as company_name, 
  
  
  
  
  sum(summary.netamount) as netamount, sum(summary.collection) as collection,
  
company_masters.sub_company_type
    
    FROM (SELECT  employee_masters.id as asm_id, employee_masters.name as asm_name, distributorSale.* FROM

(SELECT tbl1.*, tbl.balance as outstanding FROM

(SELECT tbl.company_name,tbl.company_id,sum(tbl.quantity) as quantity ,sum(tbl.ctn_quantity) as ctn_quantity,tbl.totalamount,sum(tbl.discount_amount) as discount_amount,sum(tbl.netamount) as netamount,sum(tbl.collection) as collection   from (SELECT *
  
  
                        FROM  (SELECT  company_masters.name as company_name,company_masters.id as company_id,sum(sales_details.quantity) as quantity, SUM(sales_details.ctn_quantity) as ctn_quantity,
                        SUM(sales_details.totalamount) AS totalamount,SUM(sales_details.discount_amount) AS discount_amount,SUM(sales_details.netamount) AS netamount, 0 as collection FROM sales_masters
                        INNER JOIN sales_details ON  sales_masters.id=sales_details.salesmaster_id
                        LEFT JOIN company_masters ON sales_masters.sales_location_id=company_masters.id
                        WHERE sales_masters.sales_date BETWEEN ? AND ? 
                        GROUP BY sales_masters.sales_location_id) as Sale
                    UNION ALL
  
                        (SELECT company_masters.name AS company_name, distributor_id as company_id,0 as quantity,0 as qtn_quantity,0 as totalamount,0 as discount_amount,0 as netamount, SUM(credit) as collection FROM party_ledger_masters
                        LEFT JOIN company_masters ON party_ledger_masters.distributor_id=company_masters.id
                            WHERE transaction_date BETWEEN ? AND ? 
                         GROUP BY distributor_id) ) as tbl
                        GROUP BY tbl.company_id) as tbl1


  LEFT JOIN


  (SELECT company.id as company_id, company.name, company.area_name,company.address_a, finalLedger.balance FROM 

(SELECT closingBl.company_id,sum(balance) as balance FROM

(SELECT company_masters.id as company_id , distributor_masters.opening_balance as balance  FROM company_masters INNER JOIN distributor_masters
  ON company_masters.id=distributor_masters.company_id


  UNION ALL

  SELECT ledger.company_id, ledger.balance FROM (SELECT partyledger.distributor_id as company_id, SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (
  SELECT party_ledger_masters.distributor_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                WHERE transaction_date  <?
                                  UNION ALL
                                SELECT claim_damage_collection_masters.distributor_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                FROM claim_damage_collection_masters
                                LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                               WHERE  transaction_date  <?
                                UNION ALL
                                SELECT sales_location_id as distributor_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                WHERE  sales_date<?
                                 UNION ALL

                                SELECT distribution_node_id as distributor_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                WHERE  return_date<?

                                ORDER BY transaction_date) as partyledger
                    GROUP BY partyledger.distributor_id) as ledger) as closingBl

  GROUP BY closingBl.company_id) AS finalLedger

    LEFT JOIN



                  (SELECT company_masters.id, distributor_masters.opening_balance, company_masters.name,distributor_masters.area_name, distributor_masters.address_a, company_masters.company_type FROM company_masters 
                  LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                WHERE company_type!=1) AS company

                  ON company.id=finalLedger.company_id
                  
 ORDER BY company.name ASC) as tbl

    ON tbl.company_id=tbl1.company_id) AS distributorSale
  LEFT JOIN distributor_masters ON distributor_masters.company_id=distributorSale.company_id

  LEFT JOIN employee_masters ON employee_masters.id=distributor_masters.asm_id
  ) AS  summary

  LEFT JOIN company_masters on summary.company_id=company_masters.id

  GROUP BY company_masters.sub_company_type) AS SummarySaleReport


  LEFT JOIN 


  (SELECT outstandingSummary.sub_company_type, sum( outstandingSummary.balance) as balance FROM
(SELECT company.name,company.sub_company_type, company.asm_name, company.area_name,company.address_a, finalLedger.balance FROM 

                    (SELECT closingBl.company_id,sum(balance) as balance FROM

                    (SELECT company_masters.id as company_id , distributor_masters.opening_balance as balance  FROM company_masters INNER JOIN distributor_masters
                      ON company_masters.id=distributor_masters.company_id


                      UNION ALL

                      SELECT ledger.company_id, ledger.balance FROM (SELECT partyledger.distributor_id as company_id, SUM(partyledger.debit)-SUM(partyledger.credit) as balance FROM (
                      SELECT party_ledger_masters.distributor_id,party_ledger_masters.particulars, party_ledger_masters.remarks, party_ledger_masters.reference,party_ledger_masters.transaction_date, party_ledger_masters.debit, party_ledger_masters.credit  FROM party_ledger_masters
                                                    LEFT JOIN company_masters ON party_ledger_masters.distributor_id= company_masters.id
                                                    WHERE transaction_date  <?
                                                      UNION ALL
                                                    SELECT claim_damage_collection_masters.distributor_id,claim_damage_collection_masters.particulars, claim_damage_collection_masters.remarks, claim_damage_collection_masters.reference,claim_damage_collection_masters.transaction_date, claim_damage_collection_masters.debit, claim_damage_collection_masters.credit  
                                                    FROM claim_damage_collection_masters
                                                    LEFT JOIN company_masters ON claim_damage_collection_masters.distributor_id= company_masters.id
                                                   WHERE  transaction_date  <?
                                                    UNION ALL
                                                    SELECT sales_location_id as distributor_id,'Sales' as particulars,'' as remarks, invoice_no as reference, sales_date as transaction_date, total_netamount as debit, 0 as credit  FROM sales_masters
                                                    WHERE  sales_date<?
                                                     UNION ALL

                                                    SELECT distribution_node_id as distributor_id,'Return' as particulars,'' as remarks, return_invoice_no as reference, return_date as transaction_date,0  as debit, total_netamount as credit  FROM sales_return_masters
                                                    WHERE  return_date<?

                                                    ORDER BY transaction_date) as partyledger
                                        GROUP BY partyledger.distributor_id) as ledger) as closingBl

                      GROUP BY closingBl.company_id) AS finalLedger

                        LEFT JOIN



                                      (SELECT company_masters.sub_company_type, company_masters.id,employee_masters.name as asm_name,employee_masters.id as asm_id, distributor_masters.opening_balance, company_masters.name,distributor_masters.area_name, distributor_masters.address_a, company_masters.company_type FROM company_masters 
                                      LEFT JOIN distributor_masters ON company_masters.id=distributor_masters.company_id
                                        LEFT JOIN employee_masters ON employee_masters.id=distributor_masters.asm_id
                                    WHERE company_type!=1) AS company

                                      ON company.id=finalLedger.company_id) AS outstandingSummary

  Group BY outstandingSummary.sub_company_type) AS finalOutstanding
on finalOutstanding.sub_company_type= SummarySaleReport.sub_company_type";


    $dynamicSql = (array) null;

    if ($asm_id > 0) {
      $dynamicSql[] = "  employee_masters.id= '$asm_id' ";
    }



    if (count($dynamicSql) != 0) {
      $baseQuery .= ' WHERE ' . implode(' AND ', $dynamicSql) . '     ORDER BY distributorSale.company_name   ASC';
    } else {
      $baseQuery;
    }



    // return response()->json($baseQuery);
    // $baseQuery .= " GROUP BY product_masters.product_id";

    $productsList = DB::select($baseQuery, [$startDate, $endDate, $startDate, $endDate, $endDate, $endDate, $endDate, $endDate, $endDate, $endDate, $endDate, $endDate]);

    $salesList[] = ['start_date' => $request->get('start_date'), 'end_date' => $request->get('end_date'), 'salesView' => $productsList];

    return response()->json($salesList);
  }
}
