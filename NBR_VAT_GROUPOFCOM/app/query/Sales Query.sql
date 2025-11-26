
SELECT salesview.* ,productview.* FROM





(SELECT e1.name as asm_name, e2.name as supervisor_name, company_masters.name as company_name,company_masters.id as company_id, sales_masters.invoice_no,distributor_masters.asm_id, distributor_masters.supervisor_id, sales_masters.sales_date, sales_details.product_id,
  sales_details.quantity, sales_details.ctn_quantity, sales_details.unit_price,
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

  WHERE sales_date BETWEEN '2020-01-22' and '2020-02-30' 



