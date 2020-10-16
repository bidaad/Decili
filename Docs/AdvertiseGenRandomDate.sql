Declare @AdsCode int
DECLARE product_cursor CURSOR FOR 
    SELECT  [Code]
  FROM [Parset].[dbo].[Advertises]
  where 
  CreateDate >= '2015-12-27 21:25:54.653'
  and CreateDate <= '2015-12-28 21:25:54.653'

    OPEN product_cursor
    FETCH NEXT FROM product_cursor INTO @AdsCode

    WHILE @@FETCH_STATUS = 0
    BEGIN

Declare @RandDateTime datetime
DECLARE @FromDate DATETIME = DATEADD(DAY, -200, GETDATE())
DECLARE @ToDate   DATETIME = DATEADD(DAY, -30, GETDATE())

DECLARE @Seconds INT = DATEDIFF(SECOND, @FromDate, @ToDate)
DECLARE @Random INT = ROUND(((@Seconds-1) * RAND()), 0)
DECLARE @Milliseconds int = ROUND((999 * RAND()), 0)

SELECT @RandDateTime = DATEADD(MILLISECOND, @Milliseconds, DATEADD(SECOND, @Random, @FromDate))

        PRINT @RandDateTime
        
        Update Advertises Set CreateDate = @RandDateTime where Code = @AdsCode
        FETCH NEXT FROM product_cursor INTO @AdsCode
        END

    CLOSE product_cursor
    DEALLOCATE product_cursor