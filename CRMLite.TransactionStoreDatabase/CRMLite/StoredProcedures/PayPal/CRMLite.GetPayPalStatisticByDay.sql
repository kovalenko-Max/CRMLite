CREATE PROCEDURE [CRMLite].[GetPayPalStatisticByDay] @create_time DATETIME
AS
SELECT create_time,
	first_name,
	last_name,
	recipient_name,
	city,
	email,
	total,
	currency
FROM [CRMLite].[PayPalStatistic]
WHERE create_time BETWEEN '2021-08-23'
		AND @create_time
