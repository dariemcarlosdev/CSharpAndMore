	CREATE TABLE #temp
(
	ID  int identity(1,1) primary key,
	position varchar(10),
	salary int,
	total int)

	GO
	DECLARE @TOTAL_SENIOR_SALARY INT = 0 ;
	DECLARE @BUDGET INT = 45000;
	DECLARE @COUNT INT;
	   
	   WITH CTE_SENIOR AS ( SELECT *, sum(salary) OVER (ORDER BY SALARY) AS total FROM EmployeeWage where Position= 'Senior' )
       INSERT INTO #temp SELECT Position, Salary,total  FROM CTE_SENIOR WHERE total <= @BUDGET order by total desc
	   
	   SET @TOTAL_SENIOR_SALARY = (SELECT  MAX(total) FROM #temp );
	   --PRINT 'TOTAL_SENIOR_SALARY: ' + CAST(@TOTAL_SENIOR_SALARY AS VARCHAR);

	   WITH CTE_JUNIOR AS ( SELECT *, sum(salary) OVER (ORDER BY SALARY) AS total FROM EmployeeWage where Position= 'Junior' )
       INSERT INTO #temp SELECT Position, Salary,total  FROM CTE_JUNIOR WHERE total <= @BUDGET - @TOTAL_SENIOR_SALARY order by total desc;

	  with cte as (
	  SELECT  position
	   FROM #temp 
	  )
	  SELECT
	  --Replacing Null values with 0 Output Pivot
	  isnull([Senior],0) AS Senior,
      isnull([Junior],0) AS Junior
	  FROM( 
	    select *, count(position) as Numb		
		from cte group by position
	    ) SourceTable	
		PIVOT
		(
		MAX(Numb)
        FOR position in ([Senior],[Junior])
		) AS PIVOT_RESULT

		--select * from #Seniortemp
		--select * from #temp
		drop table #temp
