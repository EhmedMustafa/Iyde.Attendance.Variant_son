Iyde.Attendance.Variant3 (FIXED)

- Employee, Store, WorkDay, Attendance
- Gecikmə / tez çıxma / gəlməyib / istirahət günü üçün analiz
- GET /api/analytics/daily?date=YYYY-MM-DD

Quraşdırma:
1. Visual Studio ilə aç
2. appsettings.json -> DefaultConnection düzəlt
3. `Add-Migration InitialCreate` + `Update-Database`
4. Run et, Swagger açılacaq.