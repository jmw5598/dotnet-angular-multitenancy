#!/bin/sh

export ANGULAR_ENVIRONMENT=staging

docker build \
    --build-arg ANGULAR_ENVIRONMENT="$ANGULAR_ENVIRONMENT" \
    -t latest/xyz_project_clients \
    .

