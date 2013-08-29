SELECT COUNT(*) Teams FROM dbo.Teams
SELECT COUNT(*) Players FROM dbo.Players
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