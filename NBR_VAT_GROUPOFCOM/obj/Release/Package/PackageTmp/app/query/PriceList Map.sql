
SELECT 
       price.product_id,                                                                          
       MAX(CASE WHEN price.price_code = 'TP'  THEN price.product_price END)                                   AS tp_price,
       MAX(CASE WHEN price.price_code = 'TP'  THEN price.pricetype_id END)                                    AS tp_price_id,
       MAX(CASE WHEN price.price_code = 'DP'  THEN price.product_price END)                                   AS dp_price,
       MAX(CASE WHEN price.price_code = 'DP'  THEN price.pricetype_id END)                                    AS dp_price_id,
       MAX(CASE WHEN price.price_code = 'MRP'  THEN price.product_price END)                                  AS mrp_price,
       MAX(CASE WHEN price.price_code = 'MRP'  THEN price.pricetype_id END)                                   AS mrp_price_id,
       MAX(CASE WHEN price.price_code = 'PP'  THEN price.product_price END)                                   AS purchase_price,
       MAX(CASE WHEN price.price_code = 'PP'  THEN price.pricetype_id END)                                    AS purchase_price_id,
       MAX(CASE WHEN price.price_code = 'MT'  THEN price.product_price END)                                   AS moderntrade_price,
       MAX(CASE WHEN price.price_code = 'MT'  THEN price.pricetype_id END)                                    AS moderntrade_price_id,
       MAX(CASE WHEN price.price_code = 'OT'  THEN price.product_price END)                                   AS other_price,
       MAX(CASE WHEN price.price_code = 'OT'  THEN price.pricetype_id END)                                    AS other_price_id
FROM

          (
            SELECT  product_prices.product_id                                                                 As product_id,
                    price_types.id                                                                            As pricetype_id,
                    price_types.price_name                                                                    As price_name,
                    price_types.price_code                                                                    As price_code,
                    product_prices.product_price                                                              As product_price
            
            
            FROM    product_prices 
                  LEFT JOIN price_types ON product_prices.price_id=price_types.id
           ) AS price
           GROUP BY price.product_id 