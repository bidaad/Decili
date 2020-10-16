
Declare @KeywordCode int
DECLARE keyword_cursor CURSOR FOR 
    SELECT Code
    FROM Keywords
    WHERE Name like N'%دیدم%'

    OPEN keyword_cursor
    FETCH NEXT FROM keyword_cursor INTO @KeywordCode

    WHILE @@FETCH_STATUS = 0
    BEGIN

        --PRINT @KeywordCode
        exec spDelKeyword @KeywordCode
        FETCH NEXT FROM keyword_cursor INTO @KeywordCode
        END

    CLOSE keyword_cursor
    DEALLOCATE keyword_cursor