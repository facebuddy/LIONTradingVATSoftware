SELECT      productview.* ,
            price_types.id                                                              As pricetype_id, 
            price_types.price_name                                                      As price_name,
            IFNULL(product_prices.product_price, 0)                                     As product_price,
            IFNULL(products_discounts.discount_amount_primary, 0)                       AS discount_amount_primary,      
            IFNULL(inventories.quantity, 0)                                             AS stock
  FROM productview
  LEFT JOIN   product_prices ON productview.product_id= product_prices.product_id
  LEFT JOIN price_types ON product_prices.price_id=price_types.id
  LEFT JOIN products_discounts ON productview.product_id=products_discounts.product_id
  LEFT JOIN inventories ON productview.product_id=inventories.product_id

 -- WHERE name LIKE ?

  GROUP BY product_prices.product_id
                                  