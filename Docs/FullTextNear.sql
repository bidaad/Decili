SELECT FT_TBL.Code,
   FT_TBL.Description, 
   KEY_TBL.RANK
FROM Advertises AS FT_TBL 

INNER JOIN
   CONTAINSTABLE (Advertises,
      Description, 
      '(تور NEAR ارزان) OR
      (ارزان NEAR ترکیه)',
      5
   ) AS KEY_TBL
   ON FT_TBL.Code = KEY_TBL.[KEY]
