	USE EmployeeDB
	/*Create new TEST TABLE EMPLOYEEWAGE_TEST*/
	--CREATE TABLE EMPLOYEEWAGE_TEST
	--(
	--ID  int identity(1,1) primary key,
	--POSITION varchar(10),
	--SALARY int
	--)

	--INSERT INTO EMPLOYEEWAGE_TEST (POSITION,SALARY)
	--VALUES 
	--('Junior', 3000),
	--('Junior', 2000),
	--('Senior', 3000)

	CREATE TABLE #TEMP
	(
	ID  int identity(1,1) primary key,
	POSITION varchar(10),
	SALARY int,
	SUM_SALARY int
	)

	GO
	DECLARE @TOTAL_SENIOR_SALARY INT = 0 ; --To store the sum of Seniors Salaries
	DECLARE @BUDGET INT = 50000;
	--DECLARE @COUNT INT;
	   
	   WITH CTE_SENIOR AS
	   ( 
	   SELECT *, sum(SALARY) OVER (ORDER BY SALARY) AS Sum_Serior_Salary FROM EMPLOYEEWAGE where POSITION= 'Senior' 
	   )       
	   INSERT INTO #TEMP SELECT POSITION, SALARY,Sum_Serior_Salary  FROM CTE_SENIOR WHERE Sum_Serior_Salary <= @BUDGET order by Sum_Serior_Salary desc
   
	   SET @TOTAL_SENIOR_SALARY = (SELECT  MAX(SUM_SALARY) FROM #TEMP );
	   
	   PRINT 'TOTAL_SENIOR_SALARY: ' + CAST(@TOTAL_SENIOR_SALARY AS VARCHAR);
	   
	   WITH CTE_JUNIOR AS
	   ( 
	   SELECT Position,Salary, sum(SALARY) OVER (ORDER BY SALARY) AS Sum_Junior_Salary FROM EMPLOYEEWAGE where Position= 'Junior'
	   )
       INSERT INTO #TEMP SELECT Position, Salary,Sum_Junior_Salary  FROM CTE_JUNIOR WHERE Salary <= (@BUDGET - @TOTAL_SENIOR_SALARY) order by Sum_Junior_Salary desc;

	  WITH CTE_POSITION_AUX AS (
	  SELECT  position
	   FROM #TEMP
	  )
	  SELECT 
	  --Replacing Null values with 0 Output Pivot just in case POSITION_COUNTER = NULL over PIVOT converting rows to columns.
	  isnull([Senior],0) AS Senior,
      isnull([Junior],0) AS Junior
	  FROM( 
	    select *, COUNT(position) as POSITION_COUNTER		
		from CTE_POSITION_AUX group by position
	    ) SourceTable	
		PIVOT
		(
		MAX(POSITION_COUNTER)
        FOR position in ([Senior],[Junior])
		) AS PIVOT_RESULT

		--select * from #Seniortemp
		select * from #TEMP
		drop table #TEMP
