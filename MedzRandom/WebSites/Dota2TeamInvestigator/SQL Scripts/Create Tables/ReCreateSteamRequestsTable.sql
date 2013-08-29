SELECT * INTO #SteamRequests FROM dbo.SteamRequests

DROP TABLE dbo.SteamRequests

CREATE TABLE [dbo].[SteamRequests]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[RequestNumber] [int] NOT NULL,
[Date] [datetime] NULL,
LastUpdated DATETIME NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SteamRequests] ADD CONSTRAINT [PK__SteamReq__3214EC2758CAFE05] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO

INSERT INTO dbo.SteamRequests
        ( RequestNumber, Date,LastUpdated )
SELECT  RequestNumber ,
        Date,GETDATE() FROM dbo.#SteamRequests