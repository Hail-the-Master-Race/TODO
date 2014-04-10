[  -f data.db ] && rm data.db;

echo ".read data.sql" | sqlite3.exe data.db
