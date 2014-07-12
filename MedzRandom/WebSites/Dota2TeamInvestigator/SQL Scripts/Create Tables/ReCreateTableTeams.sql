SELECT * INTO #Teams FROM dbo.Teams

DROP TABLE Teams

CREATE TABLE [dbo].[Teams]
(
[ID] [int] NOT NULL,
[TeamName] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Tag] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TimeCreated] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Rating] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Logo] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LogoSponsor] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CountryCode] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[URL] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GamesPlayed] [int] NULL,
[AdminAccount] [int] NULL,
LastUpdated DATETIME NOT NULL CONSTRAINT DF_Teams_LastUpdated DEFAULT GETDATE()
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Teams] ADD CONSTRAINT [PK_Teams_ID] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO

INSERT INTO dbo.Teams
        ( ID ,
          TeamName ,
          Tag ,
          TimeCreated ,
          Rating ,
          Logo ,
          LogoSponsor ,
          CountryCode ,
          URL ,
          GamesPlayed ,
          AdminAccount,
		  LastUpdated
        )
		SELECT  ID ,
		        TeamName ,
		        Tag ,
		        TimeCreated ,
		        Rating ,
		        Logo ,
		        LogoSponsor ,
		        CountryCode ,
		        URL ,
		        GamesPlayed ,
		        AdminAccount,
				DATEADD(DAY,-1,GETDATE()) FROM #Teams