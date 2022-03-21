

WITH cte AS (
   SELECT *, sum(salary) OVER (order BY EmployeeId, Position) AS total
   FROM   EmployeeWage   
group by EmployeeID, Position, Salary
--ORDER BY CASE WHEN position='Senior' then 1
--end
   )
SELECT distinct  position ,count(position) over (partition by Position) as Total
FROM   cte
WHERE  total <= 50000
----ORDER  BY position

CREATE TABLE #temp
(
	
	salary int

)

INSERT INTO EmployeeWage VALUES ('Senior','5000')







--WITH CTE AS	( SELECT *, sum(salary) OVER (ORDER BY salary) AS total FROM EmployeeWage where Position= 'Senior')
--SELECT * FROM CTE WHERE  total < 50000

DECLARE @BUDGET INT= 50000;
DECLARE @COUNTER INT= 0;
		DECLARE @CURSOR INT= 0;
		DECLARE @ROWCOUNT BIGINT = 0;
		DECLARE @TOTAL_SALARY INT = 0 ;

		CREATE TABLE #temp
(
	EmployeeID  int identity(1,1) primary key,
	position varchar(10),
	salary int

)

	   WITH CTE AS ( SELECT *, sum(salary) OVER (ORDER BY salary) AS total FROM EmployeeWage where Position= 'Senior' )
       SELECT Position, Salary into #temp FROM CTE WHERE total < 50000 order by total desc

	   select * from #temp
	   drop table #temp
	 
IF (@TOTAL_SALARY <= @BUDGET)
BEGIN
		
	   PRINT 'BUDGET ' + CAST(@BUDGET AS VARCHAR);
	   PRINT 'SALARY ' + CAST(@TOTAL_SALARY AS VARCHAR);



		 SET @CURSOR += 1
		 PRINT 'SALARY ' + CAST(@TOTAL_SALARY AS VARCHAR)
		 SET @BUDGET = @BUDGET - @TOTAL_SALARY	
		 SET @COUNTER += 1
		 PRINT 'BUDGET ' + CAST(@BUDGET AS VARCHAR)
		 PRINT @COUNTER		 
	END



  


  