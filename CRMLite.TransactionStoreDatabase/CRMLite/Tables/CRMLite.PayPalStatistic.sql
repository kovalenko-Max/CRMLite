CREATE TABLE [CRMLite].[PayPalStatistic]
(
	[ID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [LeadID] UNIQUEIDENTIFIER NOT NULL, 
    [first_name] NVARCHAR(50) NOT NULL,
    [last_name] NVARCHAR(50) NOT NULL,
    [email] NVARCHAR(50) NOT NULL,
    [total] NVARCHAR(50) NOT NULL,
    [currency] NVARCHAR(50) NOT NULL,
    [city] NVARCHAR(50) NOT NULL,
    [state] NVARCHAR(50) NOT NULL,
    [postal_code] NVARCHAR(50) NOT NULL,
    [country_code] NVARCHAR(50) NOT NULL,
    [intent] NVARCHAR(50) NOT NULL,
    [create_time] DATETIME NOT NULL,
    [payment_mode] NVARCHAR(50) NOT NULL,
    [recipient_name] NVARCHAR(50) NOT NULL
)
