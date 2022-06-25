#!/bin/sh

docker run \
  --name xyz_project_database \
  -p 5432:5432 \
  -e POSTGRES_USER=postgresRoot \
  -e POSTGRES_PASSWORD=postgresRoot \
  -d \
  latest/xyz_project_database
