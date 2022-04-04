/****** Script for SelectTopNRows command from SSMS  ******/
use TEST

go

SELECT *
  FROM [TEST].[dbo].[MATCHES]


CREATE TABLE #TEMP
(	
	TEAM_NAME VARCHAR (10),
	POINTS INT
)


DECLARE @LoopCounter int, @MaxMatchesID INT, @HOST_GOAL INT, @GUEST_GOAL INT, @HOST_POINTS INT, @GUEST_POINTS INT
,@HOST_TEAM_NAME VARCHAR(10),@GUEST_TEAM_NAME VARCHAR(10)

SELECT @LoopCounter = MIN(MATCH_ID), @MaxMatchesID = MAX(MATCH_ID) FROM MATCHES
WHILE (@LoopCounter IS NOT NULL AND @LoopCounter <= @MaxMatchesID)
	BEGIN
			SELECT @HOST_GOAL = HOST_GOALS, @HOST_TEAM_NAME = HOST_TEAM, @GUEST_TEAM_NAME =GUEST_TEAM,  @GUEST_GOAL = GUEST_GOALS FROM MATCHES WHERE MATCH_ID = @LoopCounter
			PRINT 'HOST_GOAL -> ' + CAST(@HOST_GOAL AS VARCHAR)
			PRINT 'GUEST_GOAL -> ' +CAST(@GUEST_GOAL AS VARCHAR)
		IF(@HOST_GOAL > @GUEST_GOAL) /*host team win*/
			BEGIN
				SET @HOST_POINTS = 3;
				SET @GUEST_POINTS = 0
			END
		ELSE IF (@HOST_GOAL < @GUEST_GOAL) /*guest team win*/
			BEGIN
				SET @HOST_POINTS = 0;
				SET @GUEST_POINTS = 3
		END
		ELSE
			BEGIN
				SET @HOST_POINTS = 1; /*draw*/
				SET @GUEST_POINTS = 1
		END
	
	 PRINT 'HOST_POINTS: ' +CAST(@HOST_POINTS AS VARCHAR)
	 PRINT 'GUEST_POINTS: ' +CAST(@GUEST_POINTS AS VARCHAR)
	 PRINT 'HOST_TEAM_NAME: ' + @HOST_TEAM_NAME
	 PRINT 'GUEST_TEAM_NAME: ' + @GUEST_TEAM_NAME

	 PRINT '-------'
		set @LoopCounter = @LoopCounter + 1;
	
	INSERT INTO #TEMP VALUES (@HOST_TEAM_NAME,@HOST_POINTS)
	INSERT INTO #TEMP VALUES (@GUEST_TEAM_NAME,@GUEST_POINTS)

	END
	    
		
		SELECT DISTINCT TM.TEAM_ID AS TEAM_ID, TM.TEAM_NAME,SUM(T.POINTS) OVER (PARTITION BY TM.TEAM_NAME) AS NUM_POINT FROM #TEMP T
	    RIGHT JOIN TEAMS TM ON T.TEAM_NAME = TM.TEAM_ID
	    GROUP BY TM.TEAM_NAME,TM.TEAM_ID,T.POINTS
	    ORDER BY NUM_POINT DESC

	DROP TABLE #TEMP
