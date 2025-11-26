Select  product_masters.barcode                                                                As barcode,
        product_masters.product_id                                                                   AS product_id,
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
        MAX(CASE WHEN n.cgroup_code = 'packaging' THEN n.product_id END)                        As packaging_id,
        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.component_name END)                    As size_name,
        MAX(CASE WHEN n.cgroup_code = 'size_code' THEN n.product_id END)                        As size_id

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

     
  