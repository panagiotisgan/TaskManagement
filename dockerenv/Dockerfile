FROM mcr.microsoft.com/mssql/server:2019-latest

# Create app directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Copy initialization scripts
COPY . /usr/config
             
# Set environment variables, not have to write them with the docker run command
# Note: make sure that your password matches what is in the run-initialization script 
ENV MSSQL_SA_PASSWORD test123!!
ENV ACCEPT_EULA Y

# Expose port 1433 in case accessing from other container
# Expose port externally from docker-compose.yml
EXPOSE 1433

# Run Microsoft SQL Server and initialization script (at the same time)
CMD /bin/bash ./entrypoint.sh