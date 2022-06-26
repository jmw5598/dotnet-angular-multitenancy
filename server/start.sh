#!/bin/sh

docker run \
    --name xyz_project_api \
    -p 5000:5000 \
    -p 5001:5001 \
    -e ASPNETCORE_ENVIRONMENT=Development \
    -e ASPNETCORE_HTTP_PORT="https://*:5001" \
    -e ASPNETCORE_URLS="http://*:5000" \
    -d \
    latest/xyz_project_api
