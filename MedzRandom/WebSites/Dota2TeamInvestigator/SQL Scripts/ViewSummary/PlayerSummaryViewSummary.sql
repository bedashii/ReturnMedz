SELECT 100-((CONVERT(Decimal,(SELECT COUNT(*) FROM dbo.Players WHERE PersonaName IS NULL))/
CONVERT(Decimal,(SELECT COUNT(*) FROM dbo.Players WHERE PersonaName IS NOT NULL)))*100) PlayerSummariesComplete


SELECT COUNT(*) UpdatedToday FROM dbo.Players
WHERE LastUpdated >= CONVERT(DATE,GETDATE())
SELECT COUNT(*) NotUpdatedToday FROM dbo.Players
WHERE LastUpdated < CONVERT(DATE,GETDATE())

SELECT 
(
CONVERT(Decimal,(SELECT COUNT(*) FROM dbo.Players))
-
CONVERT(Decimal,(SELECT COUNT(*) FROM dbo.Players WHERE PersonaName IS NOT NULL))
) UnknownPlayers