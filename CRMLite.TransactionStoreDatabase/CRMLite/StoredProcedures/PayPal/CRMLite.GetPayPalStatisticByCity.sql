CREATE PROCEDURE [CRMLite].[GetPayPalStatisticByCity] @city NVARCHAR(50)
AS
SELECT city,
	first_name,
	last_name,
	total,
	currency create_time
FROM [CRMLite].PayPalStatistic
