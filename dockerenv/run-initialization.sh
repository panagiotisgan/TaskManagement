# Wait to be sure that SQL Server came up
echo "Initializing database..."

sleep 15s
# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i create-database.sql
echo "Database initialization completed!"