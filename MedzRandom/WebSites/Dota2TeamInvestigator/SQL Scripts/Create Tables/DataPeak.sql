SELECT COUNT(*) 'Total Teams' FROM dbo.Teams
SELECT COUNT(*) 'Total Players' FROM dbo.Players
SELECT COUNT(*) TeamPlayers FROM dbo.TeamPlayers

SELECT COUNT(*) BrokenPlayers FROM dbo.Players
WHERE LastUpdated > GETDATE()

SELECT SCKey,MAX(SCValue) FROM dbo.SystemConfig
GROUP BY SCKey
ORDER BY MAX(SCValue)

SELECT * FROM dbo.SteamRequests
ORDER BY ID DESC

--Monitor duplicate requests per day
SELECT Request,COUNT(Request) FROM dbo.RequestTracking
WHERE Date >= CONVERT(DATE,GETDATE())
AND Ignored = 0
GROUP BY Request
HAVING COUNT(Request) > 1
ORDER BY COUNT(Request) DESC

-- Monitor Last Updated teams per day
SELECT CONVERT(DATE,LastUpdated),COUNT(CONVERT(DATE,LastUpdated)) FROM dbo.Teams
GROUP BY CONVERT(DATE,LastUpdated)
ORDER BY CONVERT(DATE,LastUpdated) DESC

SELECT  ( CONVERT(DECIMAL, ( SELECT COUNT(DISTINCT SteamID)
                             FROM   dbo.Players P
                                    JOIN dbo.MatchPlayer MP ON P.SteamID = MP.Player64
                             WHERE  SteamID64 != -1
                           ))
          / CONVERT(DECIMAL, ( SELECT   COUNT(*)
                               FROM     dbo.Players
                               WHERE    PersonaName IS NOT NULL
                             )) ) * 100 AS PercentageOfPlayersWithMatches