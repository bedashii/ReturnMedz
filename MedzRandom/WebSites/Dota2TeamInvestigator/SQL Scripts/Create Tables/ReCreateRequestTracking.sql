SELECT  ID ,
        Request ,
        Date
		INTO #RequestTracking
		FROM dbo.RequestTracking

		DROP TABLE dbo.RequestTracking

CREATE TABLE [dbo].[RequestTracking]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Request] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Date] [datetime] NOT NULL CONSTRAINT [DF_RequestTracking_Date] DEFAULT (getdate()),
Ignored BIT CONSTRAINT DF_RequestTracking_Ignored DEFAULT 0
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[RequestTracking] ADD CONSTRAINT [PK_RequestTracking_ID] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO

SET IDENTITY_INSERT dbo.RequestTracking ON
INSERT INTO dbo.RequestTracking
        ( ID,Request, Date )
SELECT  ID ,
        Request ,
        Date FROM #RequestTracking
SET IDENTITY_INSERT dbo.RequestTracking OFF