#!/bin/sh

docker run \
    --name xyz_project_api \
    -p 8080:80 \
    -d \
    latest/xyz_project_api
