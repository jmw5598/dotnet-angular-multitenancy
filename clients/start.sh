#!/bin/sh

docker run \
    --name xyz_project_clients \
    -p 4200:80 \
    -d \
    latest/xyz_project_clients
    