## Development Database Setup

### Unix Systems

1. Make `build.sh`, `start.sh`, and `migrate.sh` files executable with `chmod +x <filename>`.
2. Build docker images with `./build.sh`.
3. Run the docker image `./start.sh`.
4. Run database migrations to setup Xyz.Multitenancy databse with `./migrate.sh`
    1. You need dotnet 6 command tool and ef tools package installed to run migrations.
5. Connect to the database with `psql -h 127.0.0.1 -p 5545 -U xyz -W postgres` with password `password`. 
